using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200005E RID: 94
	[Component]
	public class MiscComponent : MonoBehaviour
	{
		// Token: 0x0600016C RID: 364 RVA: 0x0000418D File Offset: 0x0000238D
		[OnSpy]
		public static void Disable()
		{
			if (MiscOptions.WasNightVision)
			{
				MiscComponent.NightvisionBeforeSpy = true;
				MiscOptions.NightVision = false;
			}
			if (MiscOptions.Freecam)
			{
				MiscComponent.FreecamBeforeSpy = true;
				MiscOptions.Freecam = false;
			}
		}

		// Token: 0x0600016D RID: 365 RVA: 0x000041B5 File Offset: 0x000023B5
		[OffSpy]
		public static void Enable()
		{
			if (MiscComponent.NightvisionBeforeSpy)
			{
				MiscComponent.NightvisionBeforeSpy = false;
				MiscOptions.NightVision = true;
			}
			if (MiscComponent.FreecamBeforeSpy)
			{
				MiscComponent.FreecamBeforeSpy = false;
				MiscOptions.Freecam = true;
			}
		}

		// Token: 0x0600016E RID: 366 RVA: 0x0000F818 File Offset: 0x0000DA18
		private void Start()
		{
			MiscComponent.Instance = this;
			new Thread(new ThreadStart(DrawUtilities.Min)).Start();
			HotkeyComponent.ActionDict.Add(<Module>.smethod_6<string>(662732370u), delegate
			{
				MiscOptions.VehicleFly = !MiscOptions.VehicleFly;
			});
			HotkeyComponent.ActionDict.Add(<Module>.smethod_6<string>(3129426899u), delegate
			{
				RaycastOptions.Enabled = !RaycastOptions.Enabled;
			});
			HotkeyComponent.ActionDict.Add(<Module>.smethod_7<string>(245816211u), delegate
			{
				AimbotOptions.Enabled = !AimbotOptions.Enabled;
			});
			HotkeyComponent.ActionDict.Add(<Module>.smethod_7<string>(260377939u), delegate
			{
				MiscOptions.Freecam = !MiscOptions.Freecam;
			});
			HotkeyComponent.ActionDict.Add(<Module>.smethod_8<string>(1659550564u), delegate
			{
				MiscOptions.PanicMode = !MiscOptions.PanicMode;
				if (MiscOptions.PanicMode)
				{
					MenuComponent.IsInMenu = false;
					PlayerCoroutines.DisableAllVisuals();
					return;
				}
				PlayerCoroutines.EnableAllVisuals();
			});
			HotkeyComponent.ActionDict.Add(<Module>.smethod_5<string>(798668341u), delegate
			{
				ItemOptions.AutoItemPickup = !ItemOptions.AutoItemPickup;
			});
			HotkeyComponent.ActionDict.Add(<Module>.smethod_4<string>(2138994230u), delegate
			{
				MiscOptions.SlowFall = !MiscOptions.SlowFall;
			});
			SkinsUtilities.RefreshEconInfo();
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000F9AC File Offset: 0x0000DBAC
		public void Update()
		{
			OptimizationVariables.MainCam = Camera.main;
			if (!DrawUtilities.ShouldRun())
			{
				return;
			}
			if (!MenuComponent.IsInMenu && !MiscOptions.PanicMode)
			{
				foreach (KeyValuePair<string, Hotkey> keyValuePair in HotkeyOptions.ChatKeys)
				{
					KeyCode[] keys = keyValuePair.Value.Keys;
					if (keys.Any(new Func<KeyCode, bool>(Input.GetKeyDown)) && keys.All(new Func<KeyCode, bool>(Input.GetKey)))
					{
						ChatManager.sendChat(EChatMode.GLOBAL, keyValuePair.Key);
					}
				}
			}
			if (MiscComponent.fall != MiscOptions.SlowFall)
			{
				MiscComponent.fall = MiscOptions.SlowFall;
				Player.player.movement.pluginGravityMultiplier = (MiscComponent.fall ? 0f : 1f);
			}
			if (!MiscOptions.NightVision)
			{
				if (MiscOptions.WasNightVision)
				{
					LevelLighting.vision = ELightingVision.NONE;
					LevelLighting.updateLighting();
					PlayerLifeUI.updateGrayscale();
					MiscOptions.WasNightVision = false;
				}
				return;
			}
			LevelLighting.vision = ELightingVision.MILITARY;
			LevelLighting.updateLighting();
			PlayerLifeUI.updateGrayscale();
			MiscOptions.WasNightVision = true;
		}

		// Token: 0x06000170 RID: 368 RVA: 0x000041DD File Offset: 0x000023DD
		public void FixedUpdate()
		{
			if (!OptimizationVariables.MainPlayer)
			{
				return;
			}
			MiscComponent.VehicleFlight();
		}

		// Token: 0x06000171 RID: 369 RVA: 0x0000FAD0 File Offset: 0x0000DCD0
		public static void VehicleFlight()
		{
			InteractableVehicle vehicle = OptimizationVariables.MainPlayer.movement.getVehicle();
			if (vehicle == null)
			{
				return;
			}
			Rigidbody component = vehicle.GetComponent<Rigidbody>();
			if (component == null)
			{
				return;
			}
			if (!vehicle.isDriver)
			{
				return;
			}
			if (!MiscOptions.VehicleFly)
			{
				if (MiscComponent.fly)
				{
					MiscComponent.fly = false;
					component.isKinematic = false;
				}
				return;
			}
			MiscComponent.fly = true;
			component.isKinematic = true;
			float num = MiscOptions.VehicleUseMaxSpeed ? (vehicle.asset.speedMax * Time.fixedDeltaTime) : (MiscOptions.SpeedMultiplier / 3f);
			num *= 0.98f;
			Transform transform = component.transform;
			Vector3 zero = Vector3.zero;
			Vector3 vector = Vector3.zero;
			if (HotkeyUtilities.IsHotkeyHeld(<Module>.smethod_4<string>(3519943273u)))
			{
				zero.y += 2f;
			}
			if (HotkeyUtilities.IsHotkeyHeld(<Module>.smethod_5<string>(2557098160u)))
			{
				zero.y += -2f;
			}
			if (HotkeyUtilities.IsHotkeyHeld(<Module>.smethod_4<string>(3007371624u)))
			{
				zero.z += 2f;
			}
			if (HotkeyUtilities.IsHotkeyHeld(<Module>.smethod_6<string>(1206681833u)))
			{
				zero.z += -2f;
			}
			if (HotkeyUtilities.IsHotkeyHeld(<Module>.smethod_6<string>(386795253u)))
			{
				zero.x += -1.5f;
			}
			if (HotkeyUtilities.IsHotkeyHeld(<Module>.smethod_8<string>(3967161990u)))
			{
				zero.x += 1.5f;
			}
			if (HotkeyUtilities.IsHotkeyHeld(<Module>.smethod_7<string>(1909215211u)))
			{
				vector.y += 0.6f;
			}
			if (HotkeyUtilities.IsHotkeyHeld(<Module>.smethod_4<string>(2994997689u)))
			{
				vector.y -= 0.6f;
			}
			if (HotkeyUtilities.IsHotkeyHeld(<Module>.smethod_8<string>(2076776901u)))
			{
				vector -= transform.right;
			}
			if (HotkeyUtilities.IsHotkeyHeld(<Module>.smethod_8<string>(3758097563u)))
			{
				vector += transform.right;
			}
			if (HotkeyUtilities.IsHotkeyHeld(<Module>.smethod_4<string>(3711254916u)))
			{
				vector += transform.forward;
			}
			if (HotkeyUtilities.IsHotkeyHeld(<Module>.smethod_6<string>(2631066136u)))
			{
				vector -= transform.forward;
			}
			vector = vector * num + transform.position;
			if (!MiscOptions.VehicleRigibody)
			{
				transform.position = vector;
				transform.Rotate(zero);
				return;
			}
			component.MovePosition(vector);
			component.MoveRotation(transform.localRotation * Quaternion.Euler(zero));
		}

		// Token: 0x0400014C RID: 332
		private static bool fly;

		// Token: 0x0400014D RID: 333
		private static bool fall;

		// Token: 0x0400014E RID: 334
		public static MiscComponent Instance;

		// Token: 0x0400014F RID: 335
		public static float LastMovementCheck;

		// Token: 0x04000150 RID: 336
		public static bool FreecamBeforeSpy;

		// Token: 0x04000151 RID: 337
		public static bool NightvisionBeforeSpy;

		// Token: 0x04000152 RID: 338
		public static FieldInfo Primary = typeof(PlayerEquipment).GetField(<Module>.smethod_5<string>(3106413113u), BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x04000153 RID: 339
		public static FieldInfo Sequence = typeof(PlayerInput).GetField(<Module>.smethod_5<string>(1271197540u), BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x04000154 RID: 340
		public static FieldInfo CPField = typeof(PlayerInput).GetField(<Module>.smethod_4<string>(377997967u), BindingFlags.Instance | BindingFlags.NonPublic);
	}
}
