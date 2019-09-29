using System;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x020000AE RID: 174
	public static class VisualsTab
	{
		// Token: 0x0600027F RID: 639 RVA: 0x00017050 File Offset: 0x00015250
		public static void Tab()
		{
			Prefab.MenuArea(new Rect(0f, 0f, 325f, 406f), <Module>.smethod_5<string>(3257898545u), delegate
			{
				GUILayout.BeginVertical(new GUILayoutOption[]
				{
					GUILayout.Width(150f)
				});
				VisualsTab.VisualTab(Names.All[0], ESPTarget.Players, delegate
				{
					Prefab.Toggle(Names.All[54], ref ESPOptions.FullName);
					Prefab.Toggle(Names.All[55], ref ESPOptions.ShowPlayerWeapon);
					Prefab.Toggle(Names.All[56], ref ESPOptions.ShowPlayerVehicle);
				});
				VisualsTab.VisualTab(Names.All[1], ESPTarget.Zombies, null);
				VisualsTab.VisualTab(Names.All[2], ESPTarget.Vehicles, delegate
				{
					Prefab.Toggle(Names.All[58], ref ESPOptions.ShowVehicleFuel);
					Prefab.Toggle(Names.All[59], ref ESPOptions.ShowVehicleHealth);
					Prefab.Toggle(Names.All[60], ref ESPOptions.ShowVehicleLocked);
					Prefab.Toggle(Names.All[61], ref ESPOptions.FilterVehicleLocked);
				});
				VisualsTab.VisualTab(Names.All[3], ESPTarget.Items, delegate
				{
					Prefab.Toggle(Names.All[62], ref ESPOptions.FilterItems);
					if (ESPOptions.FilterItems)
					{
						GUILayout.Space(5f);
						ItemUtilities.DrawFilterTab(ItemOptions.ItemESPOptions);
					}
				});
				VisualsTab.VisualTab(Names.All[4], ESPTarget.Storage, null);
				VisualsTab.VisualTab(Names.All[5], ESPTarget.Beds, delegate
				{
					Prefab.Toggle(Names.All[63], ref ESPOptions.ShowClaimed);
				});
				VisualsTab.VisualTab(Names.All[6], ESPTarget.Generators, delegate
				{
					Prefab.Toggle(Names.All[64], ref ESPOptions.ShowGeneratorFuel);
					Prefab.Toggle(Names.All[65], ref ESPOptions.ShowGeneratorPowered);
				});
				VisualsTab.VisualTab(Names.All[7], ESPTarget.Sentries, delegate
				{
					Prefab.Toggle(Names.All[66], ref ESPOptions.ShowSentryItem);
				});
				VisualsTab.VisualTab(Names.All[8], ESPTarget.ClaimFlags, null);
				VisualsTab.VisualTab(Names.All[9], ESPTarget.Animals, null);
				VisualsTab.VisualTab(Names.All[10], ESPTarget.Farm, null);
				VisualsTab.VisualTab("Ловушки", ESPTarget.Traps, null);
				VisualsTab.VisualTab("Аирдропы", ESPTarget.AirDrop, null);
				GUILayout.EndVertical();
			});
			Prefab.MenuArea(new Rect(330f, 0f, 281f, 140f), Names.All[40], delegate
			{
				Prefab.Toggle(Names.All[41], ref MirrorCameraOptions.Enabled);
				GUILayout.Space(5f);
				if (Prefab.Button(Names.All[42], 140f, 25f))
				{
					MirrorCameraComponent.FixCam();
				}
			});
			Prefab.MenuArea(new Rect(330f, 146f, 281f, 260f), Names.All[43], delegate
			{
				if (Prefab.Toggle(Names.All[44], ref ESPOptions.Enabled) && !ESPOptions.Enabled)
				{
					for (int i = 0; i < ESPOptions.VisualOptions.Length; i++)
					{
						ESPOptions.VisualOptions[i].Glow = false;
					}
					abc.HookObject.GetComponent<ESPComponent>().OnGUI();
				}
				Prefab.Toggle(Names.All[45], ref ESPOptions.TextStyle);
				Prefab.Toggle(Names.All[46], ref ESPOptions.ChamsEnabled);
				if (ESPOptions.ChamsEnabled)
				{
					GUILayout.Space(5f);
					ESPOptions.ChamsMode = Prefab.Arrows(200f, ESPOptions.ChamsMode, "Режим: " + ESPOptions.ChamsMode, 1);
				}
				Prefab.Toggle(Names.All[48], ref MiscOptions.NoRain);
				Prefab.Toggle(Names.All[49], ref MiscOptions.NoSnow);
				Prefab.Toggle(Names.All[50], ref MiscOptions.NightVision);
				Prefab.Toggle(Names.All[51], ref MiscOptions.Compass);
				Prefab.Toggle(Names.All[52], ref MiscOptions.GPS);
				Prefab.Toggle(Names.All[53], ref MiscOptions.ShowPlayersOnMap);
				Prefab.Toggle("Список игроков в ванише", ref ESPOptions.ShowVanishPlayers);
			});
		}

		// Token: 0x06000280 RID: 640 RVA: 0x00017130 File Offset: 0x00015330
		public static void VisualTab(string name, ESPTarget target, Action code = null)
		{
			Prefab.SectionTabButton(name, delegate
			{
				GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
				GUILayout.BeginVertical(new GUILayoutOption[]
				{
					GUILayout.Width(240f)
				});
				VisualsTab.BasicControls(target);
				GUILayout.EndVertical();
				if (code != null && ESPOptions.VisualOptions[(int)target].Enabled)
				{
					GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
					code();
					GUILayout.EndVertical();
					GUILayout.FlexibleSpace();
				}
				GUILayout.EndHorizontal();
			}, 0f, 20);
			Prefab.ToggleLast(ref ESPOptions.VisualOptions[(int)target].Enabled);
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00017180 File Offset: 0x00015380
		private static void BasicControls(ESPTarget esptarget)
		{
			ESPVisual espvisual = ESPOptions.VisualOptions[(int)esptarget];
			Prefab.Toggle(Names.All[11], ref espvisual.Enabled);
			if (!espvisual.Enabled)
			{
				return;
			}
			Prefab.Toggle(Names.All[12], ref espvisual.Labels);
			if (espvisual.Labels)
			{
				Prefab.Toggle(Names.All[13], ref espvisual.ShowName);
				Prefab.Toggle(Names.All[14], ref espvisual.ShowDistance);
				Prefab.Toggle(Names.All[15], ref espvisual.ShowAngle);
			}
			Prefab.Toggle(Names.All[16], ref espvisual.Boxes);
			if (espvisual.Boxes)
			{
				Prefab.Toggle(Names.All[17], ref espvisual.TwoDimensional);
			}
			Prefab.Toggle(Names.All[18], ref espvisual.Glow);
			Prefab.Toggle(Names.All[19], ref espvisual.LineToObject);
			Prefab.Toggle(Names.All[25], ref espvisual.InfiniteDistance);
			if (!espvisual.InfiniteDistance)
			{
				GUILayout.Label(Names.All[26] + (int)espvisual.Distance, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
				espvisual.Distance = Prefab.Slider(0f, 2000f, espvisual.Distance, 200);
				GUILayout.Space(3f);
			}
			Prefab.Toggle(Names.All[27], ref espvisual.UseObjectCap);
			if (espvisual.UseObjectCap)
			{
				GUILayout.Label(Names.All[28] + espvisual.ObjectCap, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
				espvisual.ObjectCap = (int)Prefab.Slider(1f, 50f, (float)espvisual.ObjectCap, 200);
			}
			Prefab.Toggle(Names.All[20], ref espvisual.TextScaling);
			GUILayout.Space(3f);
			if (espvisual.TextScaling)
			{
				GUILayout.Label(Names.All[21] + espvisual.MinTextSize, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
				espvisual.MinTextSize = (int)Prefab.Slider(8f, 16f, (float)espvisual.MinTextSize, 200);
				GUILayout.Label(Names.All[22] + espvisual.MaxTextSize, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
				espvisual.MaxTextSize = (int)Prefab.Slider(8f, 16f, (float)espvisual.MaxTextSize, 200);
				GUILayout.Space(3f);
				GUILayout.Label(Names.All[23] + (int)espvisual.MinTextSizeDistance, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
				espvisual.MinTextSizeDistance = Prefab.Slider(0f, 1000f, espvisual.MinTextSizeDistance, 200);
				GUILayout.Space(3f);
			}
			else
			{
				GUILayout.Label(Names.All[24] + espvisual.FixedTextSize, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
				espvisual.FixedTextSize = (int)Prefab.Slider(8f, 16f, (float)espvisual.FixedTextSize, 200);
			}
			GUILayout.Space(3f);
			GUILayout.Label(Names.All[29] + espvisual.BorderStrength, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
			espvisual.BorderStrength = (int)Prefab.Slider(0f, 2f, (float)espvisual.BorderStrength, 200);
			GUILayout.Space(3f);
			string[] array = new string[]
			{
				Names.All[30],
				Names.All[31],
				Names.All[32],
				Names.All[33],
				Names.All[34],
				Names.All[35],
				Names.All[36],
				Names.All[37],
				Names.All[38]
			};
			ESPOptions.VisualOptions[(int)esptarget].Location = (LabelLocation)Prefab.Arrows(220f, (int)ESPOptions.VisualOptions[(int)esptarget].Location, array[(int)ESPOptions.VisualOptions[(int)esptarget].Location], array.Length - 1);
		}
	}
}
