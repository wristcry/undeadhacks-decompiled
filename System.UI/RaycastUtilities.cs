using System;
using System.Collections.Generic;
using SDG.Framework.Utilities;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000090 RID: 144
	public static class RaycastUtilities
	{
		// Token: 0x06000236 RID: 566 RVA: 0x0001526C File Offset: 0x0001346C
		public static bool WallCheck(Transform transform)
		{
			Vector3 direction = AimbotCoroutines.GetAimPosition(transform, "Skull") - Player.player.look.aim.position;
			RaycastHit raycastHit;
			return PhysicsUtility.raycast(new Ray(Player.player.look.aim.position, direction), out raycastHit, direction.magnitude + 1f, RayMasks.DAMAGE_CLIENT, QueryTriggerInteraction.UseGlobal) && raycastHit.transform.IsChildOf(transform);
		}

		// Token: 0x06000237 RID: 567 RVA: 0x000152E4 File Offset: 0x000134E4
		public static RaycastInfo GenerateOriginalRaycast(Ray ray, float range, int mask, Player ignorePlayer = null)
		{
			RaycastHit hit;
			PhysicsUtility.raycast(ray, out hit, range, mask, QueryTriggerInteraction.UseGlobal);
			RaycastInfo raycastInfo = new RaycastInfo(hit)
			{
				direction = ray.direction
			};
			if (!(raycastInfo.transform == null))
			{
				if (!raycastInfo.transform.CompareTag("Barricade"))
				{
					if (raycastInfo.transform.CompareTag("Structure"))
					{
						raycastInfo.transform = DamageTool.getStructureRootTransform(raycastInfo.transform);
					}
				}
				else
				{
					raycastInfo.transform = DamageTool.getBarricadeRootTransform(raycastInfo.transform);
				}
				if (raycastInfo.transform.CompareTag("Enemy"))
				{
					raycastInfo.player = DamageTool.getPlayer(raycastInfo.transform);
					if (raycastInfo.player == ignorePlayer)
					{
						raycastInfo.player = null;
					}
				}
				if (raycastInfo.transform.CompareTag("Zombie"))
				{
					raycastInfo.zombie = DamageTool.getZombie(raycastInfo.transform);
				}
				if (raycastInfo.transform.CompareTag("Animal"))
				{
					raycastInfo.animal = DamageTool.getAnimal(raycastInfo.transform);
				}
				raycastInfo.limb = DamageTool.getLimb(raycastInfo.transform);
				if (!RaycastOptions.UseRandomLimb)
				{
					if (RaycastOptions.UseCustomLimb)
					{
						raycastInfo.limb = RaycastOptions.TargetLimb;
					}
				}
				else
				{
					raycastInfo.limb = MathUtilities.RandomEnumValue<ELimb>();
				}
				if (raycastInfo.transform.CompareTag("Vehicle"))
				{
					raycastInfo.vehicle = DamageTool.getVehicle(raycastInfo.transform);
				}
				if (raycastInfo.zombie != null && raycastInfo.zombie.isRadioactive)
				{
					raycastInfo.material = EPhysicsMaterial.ALIEN_DYNAMIC;
				}
				else
				{
					raycastInfo.material = DamageTool.getMaterial(hit.point, raycastInfo.transform, raycastInfo.collider);
				}
				return raycastInfo;
			}
			return raycastInfo;
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00015488 File Offset: 0x00013688
		public static bool GenerateRaycast(out RaycastInfo info)
		{
			ItemWeaponAsset itemWeaponAsset = Player.player.equipment.asset as ItemWeaponAsset;
			float range = (itemWeaponAsset != null) ? Mathf.Max(itemWeaponAsset.range, 20f) : 20f;
			GameObject @object;
			Vector3 point;
			if (!RaycastUtilities.GetTargetObject(out @object, out point, range))
			{
				info = RaycastUtilities.GenerateOriginalRaycast(new Ray(Player.player.look.aim.position, Player.player.look.aim.forward), range, RayMasks.DAMAGE_CLIENT, null);
				return false;
			}
			info = RaycastUtilities.GenerateRaycast(@object, point);
			return true;
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00015518 File Offset: 0x00013718
		public static RaycastInfo GenerateRaycast(GameObject Object, Vector3 Point)
		{
			ELimb limb = RaycastOptions.TargetLimb;
			if (RaycastOptions.UseRandomLimb)
			{
				limb = MathUtilities.RandomEnumValue<ELimb>();
			}
			Collider component = Object.GetComponent<Collider>();
			EPhysicsMaterial material = (component == null) ? EPhysicsMaterial.NONE : DamageTool.getMaterial(Point, Object.transform, component);
			return new RaycastInfo(Object.transform)
			{
				point = Point,
				direction = Player.player.look.aim.forward,
				limb = limb,
				material = material,
				player = Object.GetComponent<Player>(),
				zombie = Object.GetComponentInParent<Zombie>(),
				vehicle = Object.GetComponent<InteractableVehicle>(),
				animal = Object.GetComponentInParent<Animal>()
			};
		}

		// Token: 0x0600023A RID: 570 RVA: 0x000155C4 File Offset: 0x000137C4
		public static bool GetTargetObject(out GameObject Object, out Vector3 Point, float Range)
		{
			float num = Range + 1f;
			float num2 = RaycastOptions.SilentAimFOV;
			Object = null;
			Point = Vector3.zero;
			Vector3 position = Player.player.look.aim.position;
			Vector3 forward = Player.player.look.aim.forward;
			foreach (GameObject gameObject in RaycastUtilities.Objects)
			{
				if (gameObject)
				{
					Player component = gameObject.GetComponent<Player>();
					if (!component || (!component.life.isDead && !FriendUtilities.IsFriendly(component) && (!RaycastOptions.WallCheck || RaycastUtilities.WallCheck(gameObject.transform))))
					{
						Zombie componentInParent = gameObject.GetComponentInParent<Zombie>();
						Animal componentInParent2 = gameObject.GetComponentInParent<Animal>();
						if ((!componentInParent || !componentInParent.isDead) && (!componentInParent2 || !componentInParent2.isDead))
						{
							if (!gameObject.GetComponent<RaycastComponent>())
							{
								gameObject.AddComponent<RaycastComponent>();
							}
							Transform transform = gameObject.transform;
							Vector3 vector = transform.position;
							float num3 = Vector3.Distance(position, vector);
							if (num3 <= Range)
							{
								if (RaycastOptions.SilentAimUseFOV)
								{
									if (transform.CompareTag("Player") || transform.CompareTag("Enemy") || transform.CompareTag("Zombie") || transform.CompareTag("Animal"))
									{
										foreach (Transform transform2 in transform.GetComponentsInChildren<Transform>())
										{
											if (transform2.name.Equals("Skull"))
											{
												vector = transform2.position + new Vector3(0f, 0.4f, 0f);
												break;
											}
										}
									}
									float angleDelta = VectorUtilities.GetAngleDelta(position, forward, vector);
									if (angleDelta > num2)
									{
										continue;
									}
									num2 = angleDelta;
								}
								else if (num3 > num)
								{
									continue;
								}
								if (SphereUtilities.GetRaycast(gameObject, position, out Point))
								{
									Object = gameObject;
									num = num3;
								}
							}
						}
					}
				}
			}
			return Object != null;
		}

		// Token: 0x04000204 RID: 516
		public static List<GameObject> Objects = new List<GameObject>();
	}
}
