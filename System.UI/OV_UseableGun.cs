using System;
using System.Collections.Generic;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000082 RID: 130
	public class OV_UseableGun
	{
		// Token: 0x060001EA RID: 490 RVA: 0x0001297C File Offset: 0x00010B7C
		public static bool IsRaycastInvalid(RaycastInfo info)
		{
			return info.player == null && info.zombie == null && info.animal == null && info.vehicle == null && info.transform == null;
		}

		// Token: 0x060001EB RID: 491 RVA: 0x000129D0 File Offset: 0x00010BD0
		[Override(typeof(UseableGun), "ballistics", BindingFlags.Instance | BindingFlags.NonPublic, 0)]
		public void OV_ballistics()
		{
			if (Provider.isServer || MiscOptions.PanicMode)
			{
				OverrideUtilities.CallOriginal(this, Array.Empty<object>());
				return;
			}
			if (Time.realtimeSinceStartup - PlayerLifeUI.hitmarkers[0].lastHit > PlayerUI.HIT_TIME)
			{
				PlayerLifeUI.hitmarkers[0].hitBuildImage.isVisible = false;
				PlayerLifeUI.hitmarkers[0].hitCriticalImage.isVisible = false;
				PlayerLifeUI.hitmarkers[0].hitEntitiyImage.isVisible = false;
			}
			ItemGunAsset itemGunAsset = (ItemGunAsset)OptimizationVariables.MainPlayer.equipment.asset;
			PlayerLook look = OptimizationVariables.MainPlayer.look;
			if (itemGunAsset.projectile != null)
			{
				return;
			}
			List<BulletInfo> list = (List<BulletInfo>)OV_UseableGun.BulletsField.GetValue(this);
			if (list.Count == 0)
			{
				return;
			}
			RaycastInfo raycastInfo = null;
			if (RaycastOptions.Enabled)
			{
				RaycastUtilities.GenerateRaycast(out raycastInfo);
			}
			if (Provider.modeConfigData.Gameplay.Ballistics)
			{
				if (raycastInfo == null)
				{
					if (AimbotCoroutines.IsAiming && AimbotCoroutines.LockedObject != null)
					{
						Vector3 aimPosition = AimbotCoroutines.GetAimPosition(AimbotCoroutines.LockedObject.transform, <Module>.smethod_5<string>(221210629u));
						Ray aimRay = VectorUtilities.GetAimRay(look.aim.position, aimPosition);
						float maxDistance = Vector3.Distance(look.aim.position, aimPosition);
						RaycastHit raycastHit;
						if (!Physics.Raycast(aimRay, out raycastHit, maxDistance, RayMasks.DAMAGE_SERVER))
						{
							raycastInfo = RaycastUtilities.GenerateOriginalRaycast(aimRay, itemGunAsset.range, RayMasks.ENEMY, null);
						}
					}
					if (raycastInfo == null)
					{
						OverrideUtilities.CallOriginal(this, Array.Empty<object>());
						return;
					}
				}
				for (int i = 0; i < list.Count; i++)
				{
					BulletInfo bulletInfo = list[i];
					float num = Vector3.Distance(OptimizationVariables.MainPlayer.transform.position, raycastInfo.point);
					if ((float)bulletInfo.steps * itemGunAsset.ballisticTravel >= num)
					{
						EPlayerHit newHit = OV_UseableGun.CalcHitMarker(itemGunAsset, ref raycastInfo);
						PlayerUI.hitmark(0, Vector3.zero, false, newHit);
						OptimizationVariables.MainPlayer.input.sendRaycast(raycastInfo);
						bulletInfo.steps = 254;
					}
				}
				for (int j = list.Count - 1; j >= 0; j--)
				{
					BulletInfo bulletInfo2 = list[j];
					bulletInfo2.steps += 1;
					if (bulletInfo2.steps >= itemGunAsset.ballisticSteps)
					{
						list.RemoveAt(j);
					}
				}
				return;
			}
			if (raycastInfo == null)
			{
				OverrideUtilities.CallOriginal(this, Array.Empty<object>());
				return;
			}
			for (int k = 0; k < list.Count; k++)
			{
				EPlayerHit newHit2 = OV_UseableGun.CalcHitMarker(itemGunAsset, ref raycastInfo);
				PlayerUI.hitmark(0, Vector3.zero, false, newHit2);
				OptimizationVariables.MainPlayer.input.sendRaycast(raycastInfo);
			}
			list.Clear();
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00012C74 File Offset: 0x00010E74
		public static EPlayerHit CalcHitMarker(ItemGunAsset PAsset, ref RaycastInfo ri)
		{
			EPlayerHit eplayerHit = EPlayerHit.NONE;
			if (ri != null && PAsset != null)
			{
				if (!ri.animal && !ri.player && !ri.zombie)
				{
					if (!ri.transform)
					{
						if (ri.vehicle && !ri.vehicle.isDead && PAsset.vehicleDamage > 1f && ri.vehicle.asset != null && (ri.vehicle.asset.isVulnerable || PAsset.isInvulnerable) && eplayerHit == EPlayerHit.NONE)
						{
							eplayerHit = EPlayerHit.BUILD;
						}
					}
					else if (ri.transform.CompareTag(<Module>.smethod_8<string>(620491067u)) && PAsset.barricadeDamage > 1f)
					{
						InteractableDoorHinge component = ri.transform.GetComponent<InteractableDoorHinge>();
						if (component != null)
						{
							ri.transform = component.transform.parent.parent;
						}
						ushort id;
						if (!ushort.TryParse(ri.transform.name, out id))
						{
							return eplayerHit;
						}
						ItemBarricadeAsset itemBarricadeAsset = (ItemBarricadeAsset)Assets.find(EAssetType.ITEM, id);
						if (itemBarricadeAsset == null || (!itemBarricadeAsset.isVulnerable && !PAsset.isInvulnerable))
						{
							return eplayerHit;
						}
						if (eplayerHit == EPlayerHit.NONE)
						{
							eplayerHit = EPlayerHit.BUILD;
						}
					}
					else if (ri.transform.CompareTag(<Module>.smethod_7<string>(3864361830u)) && PAsset.structureDamage > 1f)
					{
						ushort id2;
						if (!ushort.TryParse(ri.transform.name, out id2))
						{
							return eplayerHit;
						}
						ItemStructureAsset itemStructureAsset = (ItemStructureAsset)Assets.find(EAssetType.ITEM, id2);
						if (itemStructureAsset == null || (!itemStructureAsset.isVulnerable && !PAsset.isInvulnerable))
						{
							return eplayerHit;
						}
						if (eplayerHit == EPlayerHit.NONE)
						{
							eplayerHit = EPlayerHit.BUILD;
						}
					}
					else if (!ri.transform.CompareTag(<Module>.smethod_5<string>(2433233968u)) || PAsset.resourceDamage <= 1f)
					{
						if (PAsset.objectDamage > 1f)
						{
							InteractableObjectRubble component2 = ri.transform.GetComponent<InteractableObjectRubble>();
							if (component2 == null)
							{
								return eplayerHit;
							}
							ri.section = component2.getSection(ri.collider.transform);
							if (component2.isSectionDead(ri.section) || (!component2.asset.rubbleIsVulnerable && !PAsset.isInvulnerable))
							{
								return eplayerHit;
							}
							if (eplayerHit == EPlayerHit.NONE)
							{
								eplayerHit = EPlayerHit.BUILD;
							}
						}
					}
					else
					{
						byte x;
						byte y;
						ushort index;
						if (!ResourceManager.tryGetRegion(ri.transform, out x, out y, out index))
						{
							return eplayerHit;
						}
						ResourceSpawnpoint resourceSpawnpoint = ResourceManager.getResourceSpawnpoint(x, y, index);
						if (resourceSpawnpoint == null || resourceSpawnpoint.isDead || resourceSpawnpoint.asset.bladeID != PAsset.bladeID)
						{
							return eplayerHit;
						}
						if (eplayerHit == EPlayerHit.NONE)
						{
							eplayerHit = EPlayerHit.BUILD;
						}
					}
				}
				else
				{
					eplayerHit = EPlayerHit.ENTITIY;
					if (ri.limb == ELimb.SKULL)
					{
						eplayerHit = EPlayerHit.CRITICAL;
					}
				}
				return eplayerHit;
			}
			return eplayerHit;
		}

		// Token: 0x040001CC RID: 460
		private static FieldInfo BulletsField = typeof(UseableGun).GetField(<Module>.smethod_6<string>(745540008u), ReflectionVariables.PrivateInstance);
	}
}
