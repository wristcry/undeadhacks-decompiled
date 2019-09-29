using System;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000063 RID: 99
	public static class MoreMiscTab
	{
		// Token: 0x06000184 RID: 388 RVA: 0x00010400 File Offset: 0x0000E600
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
				Prefab.Toggle("Авто подбор растений", ref ItemOptions.AutoFarmPickup);
				Prefab.Toggle("Авто подбор кустов", ref ItemOptions.AutoForagePickup);
				GUILayout.Space(5f);
				GUILayout.Label("Расстояние: " + ItemOptions.FarmPickupRange, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
				GUILayout.Space(2f);
				ItemOptions.FarmPickupRange = (float)((int)Prefab.Slider(0f, 1000f, ItemOptions.FarmPickupRange, 175));
				if (ItemOptions.EnablePickupFilter)
				{
					ItemUtilities.DrawFilterTab(ItemOptions.ItemFilterOptions);
				}
				Prefab.Toggle("Фильтр предметов", ref ItemOptions.EnablePickupFilter);
				GUILayout.Space(2f);
				Prefab.Toggle("Авто подбор предметов", ref ItemOptions.AutoItemPickup);
				GUILayout.Space(5f);
				GUILayout.Label("Задержка: " + ItemOptions.ItemPickupDelay + "ms", Prefab._TextStyle, Array.Empty<GUILayoutOption>());
				GUILayout.Space(2f);
				ItemOptions.ItemPickupDelay = (int)Prefab.Slider(200f, 1000f, (float)ItemOptions.ItemPickupDelay, 175);
				Prefab.Toggle("Нет таймера на выход", ref MiscOptions.Disconnect);
				GUILayout.Space(5f);
				if (Prefab.Button("Отключится от сервера", 200f, 25f))
				{
					Provider.disconnect();
				}
				GUILayout.Space(5f);
				if (Prefab.Button("Убрать воду", 200f, 25f))
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
					if (Prefab.Button("Включить 3 лицо", 200f, 25f))
					{
						Provider.cameraMode = ECameraMode.BOTH;
						goto IL_218;
					}
				}
				if (Provider.cameraMode == ECameraMode.BOTH && Prefab.Button("Выключить 3 лицо", 200f, 25f))
				{
					Provider.cameraMode = ECameraMode.VEHICLE;
				}
				IL_218:
				GUILayout.EndVertical();
				GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
				GUILayout.Label(string.Format("Метод краша сервера: {0}", MiscOptions.SCrashMethod), Prefab._TextStyle, Array.Empty<GUILayoutOption>());
				GUILayout.Space(2f);
				MiscOptions.SCrashMethod = (int)Prefab.Slider(1f, 3f, (float)MiscOptions.SCrashMethod, 175);
				Prefab.Toggle("Краш сервера", ref ServerCrashThread.ServerCrashEnabled);
				Prefab.Toggle("Предупреждать при Spy", ref MiscOptions.AlertOnSpy);
				GUILayout.Space(5f);
				Prefab.Toggle("Дальность поднятия в инвентаре", ref MiscOptions.IncreaseNearbyItemDistance);
				Prefab.Toggle("Быстрая покупка", ref MiscOptions.FastBuy);
				Prefab.Toggle("Быстрая продажа", ref MiscOptions.FastSell);
				if (MiscOptions.FastSell || MiscOptions.FastBuy)
				{
					GUILayout.Space(5f);
					GUILayout.Label("Количество: " + MiscOptions.FastSellCount, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
					GUILayout.Space(2f);
					MiscOptions.FastSellCount = (int)Prefab.Slider(1f, 20f, (float)MiscOptions.FastSellCount, 175);
				}
				GUILayout.Space(10f);
				if (Prefab.Button("Сменить HWID", 200f, 25f))
				{
					byte[] array = new byte[20];
					for (int i = 0; i < 20; i++)
					{
						array[i] = (byte)UnityEngine.Random.Range(0, 256);
					}
					MoreMiscTab.hwidfield.SetValue(null, array);
				}
				GUILayout.Space(10f);
				if (Prefab.Button("Отключить чит полностью", 200f, 25f))
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
