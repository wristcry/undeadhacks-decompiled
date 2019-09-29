using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x020000B1 RID: 177
	[Component]
	[SpyComponent]
	public class WeaponComponent : MonoBehaviour
	{
		// Token: 0x0600028F RID: 655 RVA: 0x00004BBB File Offset: 0x00002DBB
		public static byte Ammo()
		{
			return (byte)WeaponComponent.AmmoInfo.GetValue(Player.player.equipment.useable);
		}

		// Token: 0x06000290 RID: 656 RVA: 0x00004BDB File Offset: 0x00002DDB
		public void Start()
		{
			base.StartCoroutine(WeaponComponent.UpdateWeapon());
		}

		// Token: 0x06000291 RID: 657 RVA: 0x00017940 File Offset: 0x00015B40
		public void OnGUI()
		{
			if (!DrawUtilities.ShouldRun())
			{
				return;
			}
			if (WeaponComponent.MainCamera == null)
			{
				WeaponComponent.MainCamera = Camera.main;
			}
			if (WeaponOptions.NoSway && Player.player.animator != null)
			{
				Player.player.animator.viewSway = Vector3.zero;
			}
			if (Event.current.type == EventType.Repaint)
			{
				if (WeaponOptions.ShowWeaponInfo)
				{
					ItemAsset asset = Player.player.equipment.asset;
					if (asset == null)
					{
						return;
					}
					string content = asset.itemName;
					GUI.depth = 0;
					if (asset is ItemWeaponAsset)
					{
						ItemWeaponAsset itemWeaponAsset = (ItemWeaponAsset)asset;
						content = string.Format("{0}\nДальность: {1}\nУрон: {2}", itemWeaponAsset.itemName, itemWeaponAsset.range, itemWeaponAsset.playerDamageMultiplier.damage);
					}
					DrawUtilities.DrawLabel(ESPComponent.ESPFont, LabelLocation.MiddleLeft, new Vector2((float)(Screen.width - 20), (float)(Screen.height / 2)), content, ColorUtilities.getColor("_WeaponInfoColor"), 1, 15);
				}
				return;
			}
		}

		// Token: 0x06000292 RID: 658 RVA: 0x00017A44 File Offset: 0x00015C44
		public static void DisableHacks(ItemGunAsset gun)
		{
			gun.recoilMax_x = WeaponComponent.AssetBackups[gun][0];
			gun.recoilMax_y = WeaponComponent.AssetBackups[gun][1];
			gun.recoilMin_x = WeaponComponent.AssetBackups[gun][2];
			gun.recoilMin_y = WeaponComponent.AssetBackups[gun][3];
			gun.shakeMax_z = WeaponComponent.AssetBackups[gun][4];
			gun.shakeMin_z = WeaponComponent.AssetBackups[gun][5];
			gun.shakeMax_x = WeaponComponent.AssetBackups[gun][6];
			gun.shakeMin_x = WeaponComponent.AssetBackups[gun][7];
			gun.shakeMax_y = WeaponComponent.AssetBackups[gun][8];
			gun.shakeMin_y = WeaponComponent.AssetBackups[gun][9];
			gun.spreadHip = WeaponComponent.AssetBackups[gun][10];
			gun.ballisticDrop = WeaponComponent.AssetBackups[gun][11];
		}

		// Token: 0x06000293 RID: 659 RVA: 0x00004BE9 File Offset: 0x00002DE9
		public static IEnumerator UpdateWeapon()
		{
			return new WeaponComponent.<UpdateWeapon>d__11(0);
		}

		// Token: 0x06000296 RID: 662 RVA: 0x000036F7 File Offset: 0x000018F7
		MethodInfo method_0(string string_0, BindingFlags bindingFlags_0)
		{
			return base.GetMethod(string_0, bindingFlags_0);
		}

		// Token: 0x04000256 RID: 598
		public static FieldInfo fov = typeof(PlayerLook).GetField("fov", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x04000257 RID: 599
		public static Dictionary<ItemGunAsset, float[]> AssetBackups = new Dictionary<ItemGunAsset, float[]>();

		// Token: 0x04000258 RID: 600
		public static FieldInfo AmmoInfo = typeof(UseableGun).GetField("ammo", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x04000259 RID: 601
		public static FieldInfo ZoomInfo = typeof(UseableGun).GetField("zoom", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x0400025A RID: 602
		public static List<TracerLine> Tracers = new List<TracerLine>();

		// Token: 0x0400025B RID: 603
		public static Camera MainCamera;

		// Token: 0x0400025C RID: 604
		public static MethodInfo UpdateCrosshair = typeof(UseableGun).method_0("updateCrosshair", BindingFlags.Instance | BindingFlags.NonPublic);
	}
}
