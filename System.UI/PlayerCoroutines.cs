using System;
using System.Collections;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000083 RID: 131
	public static class PlayerCoroutines
	{
		// Token: 0x060001EE RID: 494 RVA: 0x00004708 File Offset: 0x00002908
		public static IEnumerator TakeScreenshot()
		{
			Player player = Player.player;
			SteamChannel channel = player.channel;
			if (Time.realtimeSinceStartup - PlayerCoroutines.LastSpy >= 0.5f && !PlayerCoroutines.IsSpying)
			{
				PlayerCoroutines.IsSpying = true;
				PlayerCoroutines.LastSpy = Time.realtimeSinceStartup;
				if (!MiscOptions.PanicMode)
				{
					PlayerCoroutines.DisableAllVisuals();
				}
				yield return new WaitForEndOfFrame();
				yield return new WaitForEndOfFrame();
				Texture2D texture2D = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false)
				{
					name = "Screenshot_Raw",
					hideFlags = HideFlags.HideAndDontSave
				};
				texture2D.ReadPixels(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), 0, 0, false);
				Texture2D texture2D2 = new Texture2D(640, 480, TextureFormat.RGB24, false)
				{
					name = "Screenshot_Final",
					hideFlags = HideFlags.HideAndDontSave
				};
				Color[] pixels = texture2D.GetPixels();
				Color[] array = new Color[texture2D2.width * texture2D2.height];
				float num = (float)texture2D.width / (float)texture2D2.width;
				float num2 = (float)texture2D.height / (float)texture2D2.height;
				for (int i = 0; i < texture2D2.height; i++)
				{
					int num3 = (int)((float)i * num2) * texture2D.width;
					int num4 = i * texture2D2.width;
					for (int j = 0; j < texture2D2.width; j++)
					{
						int num5 = (int)((float)j * num);
						array[num4 + j] = pixels[num3 + num5];
					}
				}
				texture2D2.SetPixels(array);
				byte[] array2 = texture2D2.EncodeToJPG(33);
				if (array2.Length < 35000)
				{
					channel.longBinaryData = true;
					channel.openWrite();
					channel.write(array2);
					channel.closeWrite("tellScreenshotRelay", ESteamCall.SERVER, ESteamPacket.UPDATE_RELIABLE_CHUNK_BUFFER);
					channel.longBinaryData = false;
				}
				PlayerCoroutines.IsSpying = false;
				if (!MiscOptions.PanicMode)
				{
					PlayerCoroutines.EnableAllVisuals();
				}
				if (MiscOptions.AlertOnSpy && !MiscOptions.PanicMode)
				{
					Player.player.StartCoroutine(PlayerCoroutines.ScreenShotMessageCoroutine());
				}
				yield break;
			}
			yield break;
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00004710 File Offset: 0x00002910
		public static IEnumerator ScreenShotMessageCoroutine()
		{
			return new PlayerCoroutines.<ScreenShotMessageCoroutine>d__4(0);
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00012D1C File Offset: 0x00010F1C
		public static void DisableAllVisuals()
		{
			try
			{
				SpyManager.InvokePre();
				SpyManager.DestroyComponents();
			}
			catch
			{
			}
			if (LevelLighting.seaLevel == 0f)
			{
				LevelLighting.seaLevel = MiscOptions.Altitude;
			}
			try
			{
				UseableGun useableGun = Player.player.equipment.useable as UseableGun;
				if (useableGun != null)
				{
					WeaponComponent.UpdateCrosshair.Invoke(useableGun, null);
				}
				foreach (ItemGunAsset itemGunAsset in WeaponComponent.AssetBackups.Keys)
				{
					if (itemGunAsset != null)
					{
						WeaponComponent.DisableHacks(itemGunAsset);
					}
				}
				WeaponComponent.AssetBackups.Clear();
			}
			catch
			{
			}
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x00012DF0 File Offset: 0x00010FF0
		public static void EnableAllVisuals()
		{
			try
			{
				SpyManager.AddComponents();
				SpyManager.InvokePost();
			}
			catch
			{
			}
		}

		// Token: 0x040001CD RID: 461
		public static float LastSpy;

		// Token: 0x040001CE RID: 462
		public static bool IsSpying;

		// Token: 0x040001CF RID: 463
		public static Player SpecPlayer;
	}
}
