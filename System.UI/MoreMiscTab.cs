using System;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000063 RID: 99
	public static class MoreMiscTab
	{
		// Token: 0x06000184 RID: 388 RVA: 0x000104D8 File Offset: 0x0000E6D8
		public static void Tab()
		{
			Prefab.MenuArea(new Rect(0f, 0f, 611f, 406f), <Module>.smethod_8<string>(3414214735u), delegate
			{
				GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
				GUILayout.BeginVertical(new GUILayoutOption[]
				{
					GUILayout.Width(260f)
				});
				GUILayout.Space(2f);
				Prefab.Toggle(<Module>.smethod_6<string>(753909770u), ref ItemOptions.AutoFarmPickup);
				Prefab.Toggle(<Module>.smethod_8<string>(2725245723u), ref ItemOptions.AutoForagePickup);
				GUILayout.Space(5f);
				GUILayout.Label(<Module>.smethod_5<string>(1366397454u) + ItemOptions.FarmPickupRange, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
				GUILayout.Space(2f);
				ItemOptions.FarmPickupRange = (float)((int)Prefab.Slider(0f, 1000f, ItemOptions.FarmPickupRange, 175));
				if (ItemOptions.EnablePickupFilter)
				{
					ItemUtilities.DrawFilterTab(ItemOptions.ItemFilterOptions);
				}
				Prefab.Toggle(<Module>.smethod_5<string>(172567634u), ref ItemOptions.EnablePickupFilter);
				GUILayout.Space(2f);
				Prefab.Toggle(<Module>.smethod_4<string>(3525095405u), ref ItemOptions.AutoItemPickup);
				GUILayout.Space(5f);
				GUILayout.Label(<Module>.smethod_7<string>(953413580u) + ItemOptions.ItemPickupDelay + <Module>.smethod_5<string>(3615770632u), Prefab._TextStyle, Array.Empty<GUILayoutOption>());
				GUILayout.Space(2f);
				ItemOptions.ItemPickupDelay = (int)Prefab.Slider(200f, 1000f, (float)ItemOptions.ItemPickupDelay, 175);
				Prefab.Toggle(<Module>.smethod_4<string>(329008622u), ref MiscOptions.Disconnect);
				GUILayout.Space(5f);
				if (Prefab.Button(<Module>.smethod_4<string>(3343581631u), 200f, 25f))
				{
					Provider.disconnect();
				}
				GUILayout.Space(5f);
				if (Prefab.Button(<Module>.smethod_8<string>(1530638981u), 200f, 25f))
				{
					if (MiscOptions.Altitude == 0f)
					{
						MiscOptions.Altitude = LevelLighting.seaLevel;
					}
					LevelLighting.seaLevel = ((LevelLighting.seaLevel == 0f) ? MiscOptions.Altitude : 0f);
				}
				GUILayout.Space(5f);
				if (Provider.cameraMode != ECameraMode.BOTH)
				{
					if (Prefab.Button(<Module>.smethod_8<string>(2715783818u), 200f, 25f))
					{
						Provider.cameraMode = ECameraMode.BOTH;
						goto IL_254;
					}
				}
				if (Provider.cameraMode == ECameraMode.BOTH && Prefab.Button(<Module>.smethod_5<string>(530439721u), 200f, 25f))
				{
					Provider.cameraMode = ECameraMode.VEHICLE;
				}
				IL_254:
				GUILayout.EndVertical();
				GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
				GUILayout.Label(string.Format(<Module>.smethod_5<string>(2260205262u), MiscOptions.SCrashMethod), Prefab._TextStyle, Array.Empty<GUILayoutOption>());
				GUILayout.Space(2f);
				MiscOptions.SCrashMethod = (int)Prefab.Slider(1f, 3f, (float)MiscOptions.SCrashMethod, 175);
				Prefab.Toggle(<Module>.smethod_7<string>(2349287232u), ref ServerCrashThread.ServerCrashEnabled);
				Prefab.Toggle(<Module>.smethod_8<string>(2270171766u), ref MiscOptions.AlertOnSpy);
				GUILayout.Space(5f);
				Prefab.Toggle(<Module>.smethod_6<string>(3706410419u), ref MiscOptions.IncreaseNearbyItemDistance);
				Prefab.Toggle(<Module>.smethod_7<string>(328285394u), ref MiscOptions.FastBuy);
				Prefab.Toggle(<Module>.smethod_7<string>(2000318819u), ref MiscOptions.FastSell);
				if (MiscOptions.FastSell || MiscOptions.FastBuy)
				{
					GUILayout.Space(5f);
					GUILayout.Label(<Module>.smethod_5<string>(1962269326u) + MiscOptions.FastSellCount, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
					GUILayout.Space(2f);
					MiscOptions.FastSellCount = (int)Prefab.Slider(1f, 20f, (float)MiscOptions.FastSellCount, 175);
				}
				GUILayout.Space(10f);
				if (Prefab.Button(<Module>.smethod_6<string>(1598015654u), 200f, 25f))
				{
					byte[] array = new byte[20];
					for (int i = 0; i < 20; i++)
					{
						array[i] = (byte)UnityEngine.Random.Range(0, 256);
					}
					MoreMiscTab.hwidfield.SetValue(null, array);
				}
				GUILayout.Space(10f);
				if (Prefab.Button(<Module>.smethod_7<string>(2430730297u), 200f, 25f))
				{
					PlayerCoroutines.DisableAllVisuals();
					OverrideManager.RemoveOverrides();
					UnityEngine.Object.DestroyImmediate(abc.HookObject);
				}
				GUILayout.EndVertical();
				GUILayout.EndHorizontal();
			});
		}

		// Token: 0x0400018E RID: 398
		private static FieldInfo hwidfield = typeof(LocalHwid).GetField(<Module>.smethod_8<string>(1094488834u), BindingFlags.Static | BindingFlags.NonPublic);
	}
}
