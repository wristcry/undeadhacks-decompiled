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
		// Token: 0x0600016C RID: 364 RVA: 0x00004199 File Offset: 0x00002399
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

		// Token: 0x0600016D RID: 365 RVA: 0x000041C1 File Offset: 0x000023C1
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

		// Token: 0x0600016E RID: 366 RVA: 0x0000F864 File Offset: 0x0000DA64
		private void Start()
		{
			MiscComponent.Instance = this;
			new Thread(new ThreadStart(DrawUtilities.Min)).Start();
			HotkeyComponent.ActionDict.Add("_VFToggle", delegate
			{
				MiscOptions.VehicleFly = !MiscOptions.VehicleFly;
			});
			HotkeyComponent.ActionDict.Add("_ToggleSilent", delegate
			{
				RaycastOptions.Enabled = !RaycastOptions.Enabled;
			});
			HotkeyComponent.ActionDict.Add("_ToggleAimbot", delegate
			{
				AimbotOptions.Enabled = !AimbotOptions.Enabled;
			});
			HotkeyComponent.ActionDict.Add("_ToggleFreecam", delegate
			{
				MiscOptions.Freecam = !MiscOptions.Freecam;
			});
			HotkeyComponent.ActionDict.Add("_PanicButton", delegate
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
			HotkeyComponent.ActionDict.Add("_AutoPickup", delegate
			{
				ItemOptions.AutoItemPickup = !ItemOptions.AutoItemPickup;
			});
			HotkeyComponent.ActionDict.Add("_ToggleSlowFall", delegate
			{
				MiscOptions.SlowFall = !MiscOptions.SlowFall;
			});
			SkinsUtilities.RefreshEconInfo();
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000F9D4 File Offset: 0x0000DBD4
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

		// Token: 0x06000170 RID: 368 RVA: 0x000041E9 File Offset: 0x000023E9
		public void FixedUpdate()
		{
			if (!Player.player)
			{
				return;
			}
			MiscComponent.VehicleFlight();
		}

		// Token: 0x06000171 RID: 369 RVA: 0x0000FAF8 File Offset: 0x0000DCF8
		public static void VehicleFlight()
		{
			InteractableVehicle vehicle = Player.player.movement.getVehicle();
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
			if (HotkeyUtilities.IsHotkeyHeld("_VFRotateRight"))
			{
				zero.y += 2f;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_VFRotateLeft"))
			{
				zero.y += -2f;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_VFRollLeft"))
			{
				zero.z += 2f;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_VFRollRight"))
			{
				zero.z += -2f;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_VFRotateUp"))
			{
				zero.x += -1.5f;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_VFRotateDown"))
			{
				zero.x += 1.5f;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_VFStrafeUp"))
			{
				vector.y += 0.6f;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_VFStrafeDown"))
			{
				vector.y -= 0.6f;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_VFStrafeLeft"))
			{
				vector -= transform.right;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_VFStrafeRight"))
			{
				vector += transform.right;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_VFMoveForward"))
			{
				vector += transform.forward;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_VFMoveBackward"))
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
		public static FieldInfo Primary = typeof(PlayerEquipment).GetField("_primary", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x04000153 RID: 339
		public static FieldInfo Sequence = typeof(PlayerInput).GetField("sequence", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x04000154 RID: 340
		public static FieldInfo CPField = typeof(PlayerInput).GetField("clientsidePackets", BindingFlags.Instance | BindingFlags.NonPublic);
	}
}
