using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x020000B1 RID: 177
	[SpyComponent]
	[Component]
	public class WeaponComponent : MonoBehaviour
	{
		// Token: 0x06000292 RID: 658 RVA: 0x00004B8B File Offset: 0x00002D8B
		public static byte Ammo()
		{
			return (byte)WeaponComponent.AmmoInfo.GetValue(OptimizationVariables.MainPlayer.equipment.useable);
		}

		// Token: 0x06000293 RID: 659 RVA: 0x00004BAB File Offset: 0x00002DAB
		public void Start()
		{
			base.StartCoroutine(WeaponComponent.UpdateWeapon());
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00017C20 File Offset: 0x00015E20
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
			if (WeaponOptions.NoSway && OptimizationVariables.MainPlayer.animator != null)
			{
				OptimizationVariables.MainPlayer.animator.viewSway = Vector3.zero;
			}
			if (Event.current.type == EventType.Repaint)
			{
				if (WeaponOptions.ShowWeaponInfo)
				{
					ItemAsset asset = OptimizationVariables.MainPlayer.equipment.asset;
					if (asset == null)
					{
						return;
					}
					string content = asset.itemName;
					GUI.depth = 0;
					if (asset is ItemWeaponAsset)
					{
						ItemWeaponAsset itemWeaponAsset = (ItemWeaponAsset)asset;
						content = string.Format(<Module>.smethod_4<string>(3015099822u), itemWeaponAsset.itemName, itemWeaponAsset.range, itemWeaponAsset.playerDamageMultiplier.damage);
					}
					DrawUtilities.DrawLabel(ESPComponent.ESPFont, LabelLocation.MiddleLeft, new Vector2((float)(Screen.width - 20), (float)(Screen.height / 2)), content, ColorUtilities.getColor(<Module>.smethod_5<string>(4267928022u)), 1, 15);
				}
				return;
			}
		}

		// Token: 0x06000295 RID: 661 RVA: 0x00017D30 File Offset: 0x00015F30
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

		// Token: 0x06000296 RID: 662 RVA: 0x00004BB9 File Offset: 0x00002DB9
		public static IEnumerator UpdateWeapon()
		{
			return new WeaponComponent.<UpdateWeapon>d__11(0);
		}

		// Token: 0x06000299 RID: 665 RVA: 0x000036F7 File Offset: 0x000018F7
		MethodInfo method_0(string string_0, BindingFlags bindingFlags_0)
		{
			return base.GetMethod(string_0, bindingFlags_0);
		}

		// Token: 0x04000256 RID: 598
		public static FieldInfo fov = typeof(PlayerLook).GetField(<Module>.smethod_6<string>(2677099827u), BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x04000257 RID: 599
		public static Dictionary<ItemGunAsset, float[]> AssetBackups = new Dictionary<ItemGunAsset, float[]>();

		// Token: 0x04000258 RID: 600
		public static FieldInfo AmmoInfo = typeof(UseableGun).GetField(<Module>.smethod_8<string>(3059967485u), BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x04000259 RID: 601
		public static FieldInfo ZoomInfo = typeof(UseableGun).GetField(<Module>.smethod_8<string>(2269870927u), BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x0400025A RID: 602
		public static List<TracerLine> Tracers = new List<TracerLine>();

		// Token: 0x0400025B RID: 603
		public static Camera MainCamera;

		// Token: 0x0400025C RID: 604
		public static MethodInfo UpdateCrosshair = typeof(UseableGun).method_0(<Module>.smethod_6<string>(1581721121u), BindingFlags.Instance | BindingFlags.NonPublic);
	}
}
