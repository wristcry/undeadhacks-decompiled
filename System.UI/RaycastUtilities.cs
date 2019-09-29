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
		// Token: 0x06000237 RID: 567 RVA: 0x00015578 File Offset: 0x00013778
		public static bool WallCheck(Transform transform)
		{
			Vector3 direction = AimbotCoroutines.GetAimPosition(transform, <Module>.smethod_8<string>(629351294u)) - Player.player.look.aim.position;
			RaycastHit raycastHit;
			return PhysicsUtility.raycast(new Ray(Player.player.look.aim.position, direction), out raycastHit, direction.magnitude + 1f, RayMasks.DAMAGE_CLIENT, QueryTriggerInteraction.UseGlobal) && raycastHit.transform.IsChildOf(transform);
		}

		// Token: 0x06000238 RID: 568 RVA: 0x000155F4 File Offset: 0x000137F4
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
				if (!raycastInfo.transform.CompareTag(<Module>.smethod_7<string>(4131887178u)))
				{
					if (raycastInfo.transform.CompareTag(<Module>.smethod_5<string>(2183419508u)))
					{
						raycastInfo.transform = DamageTool.getStructureRootTransform(raycastInfo.transform);
					}
				}
				else
				{
					raycastInfo.transform = DamageTool.getBarricadeRootTransform(raycastInfo.transform);
				}
				if (raycastInfo.transform.CompareTag(<Module>.smethod_8<string>(4226489351u)))
				{
					raycastInfo.player = DamageTool.getPlayer(raycastInfo.transform);
					if (raycastInfo.player == ignorePlayer)
					{
						raycastInfo.player = null;
					}
				}
				if (raycastInfo.transform.CompareTag(<Module>.smethod_7<string>(2006246122u)))
				{
					raycastInfo.zombie = DamageTool.getZombie(raycastInfo.transform);
				}
				if (raycastInfo.transform.CompareTag(<Module>.smethod_8<string>(2576808652u)))
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
				if (raycastInfo.transform.CompareTag(<Module>.smethod_4<string>(2487578172u)))
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

		// Token: 0x06000239 RID: 569 RVA: 0x000157B8 File Offset: 0x000139B8
		public static bool GenerateRaycast(out RaycastInfo info)
		{
			ItemWeaponAsset itemWeaponAsset = OptimizationVariables.MainPlayer.equipment.asset as ItemWeaponAsset;
			float range = (itemWeaponAsset != null) ? Mathf.Max(itemWeaponAsset.range, 20f) : 20f;
			GameObject @object;
			Vector3 point;
			if (!RaycastUtilities.GetTargetObject(out @object, out point, range))
			{
				info = RaycastUtilities.GenerateOriginalRaycast(new Ray(OptimizationVariables.MainPlayer.look.aim.position, OptimizationVariables.MainPlayer.look.aim.forward), range, RayMasks.DAMAGE_CLIENT, null);
				return false;
			}
			info = RaycastUtilities.GenerateRaycast(@object, point);
			return true;
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00015848 File Offset: 0x00013A48
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
				direction = OptimizationVariables.MainPlayer.look.aim.forward,
				limb = limb,
				material = material,
				player = Object.GetComponent<Player>(),
				zombie = Object.GetComponentInParent<Zombie>(),
				vehicle = Object.GetComponent<InteractableVehicle>(),
				animal = Object.GetComponentInParent<Animal>()
			};
		}

		// Token: 0x0600023B RID: 571 RVA: 0x000158F4 File Offset: 0x00013AF4
		public static bool GetTargetObject(out GameObject Object, out Vector3 Point, float Range)
		{
			float num = Range + 1f;
			float num2 = RaycastOptions.SilentAimFOV;
			Object = null;
			Point = Vector3.zero;
			Vector3 position = OptimizationVariables.MainPlayer.look.aim.position;
			Vector3 forward = OptimizationVariables.MainPlayer.look.aim.forward;
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
									if (transform.CompareTag(<Module>.smethod_7<string>(959340883u)) || transform.CompareTag(<Module>.smethod_8<string>(4226489351u)) || transform.CompareTag(<Module>.smethod_4<string>(753399450u)) || transform.CompareTag(<Module>.smethod_4<string>(2578335059u)))
									{
										foreach (Transform transform2 in transform.GetComponentsInChildren<Transform>())
										{
											if (transform2.name.Equals(<Module>.smethod_7<string>(3290527135u)))
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
