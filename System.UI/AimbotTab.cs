using System;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000018 RID: 24
	public static class AimbotTab
	{
		// Token: 0x0600006D RID: 109 RVA: 0x00007DC4 File Offset: 0x00005FC4
		public static void Tab()
		{
			Prefab.MenuArea(new Rect(0f, 0f, 611f, 406f), <Module>.smethod_7<string>(3665911882u), delegate
			{
				Prefab.MenuArea(new Rect(10f, 291f, 230f, 105f), "УРОН", delegate
				{
					Prefab.Toggle("Случайная часть тела", ref RaycastOptions.UseRandomLimb);
					if (!RaycastOptions.UseRandomLimb)
					{
						Prefab.Toggle("Выбрать часть тела", ref RaycastOptions.UseCustomLimb);
					}
					if (RaycastOptions.UseCustomLimb && !RaycastOptions.UseRandomLimb)
					{
						GUILayout.Space(10f);
						RaycastOptions.TargetLimb = (ELimb)Prefab.Arrows(200f, (int)RaycastOptions.TargetLimb, RaycastOptions.TargetLimb.ToString().Replace('_', ' '), Enum.GetValues(typeof(ELimb)).Length - 1);
					}
				});
				GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
				GUILayout.BeginVertical(new GUILayoutOption[]
				{
					GUILayout.Width(260f)
				});
				Prefab.Toggle("Silent Аимбот", ref RaycastOptions.Enabled);
				GUILayout.Space(2f);
				if (RaycastOptions.Enabled)
				{
					Prefab.Toggle("Использовать FOV", ref RaycastOptions.SilentAimUseFOV);
					if (RaycastOptions.SilentAimUseFOV)
					{
						GUILayout.Space(2f);
						GUILayout.Label("FOV: " + RaycastOptions.SilentAimFOV, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
						RaycastOptions.SilentAimFOV = (float)((int)Prefab.Slider(1f, 90f, RaycastOptions.SilentAimFOV, 200));
						Prefab.Toggle("Показывать FOV", ref MiscOptions.ShowSilentFOV);
					}
					GUILayout.Space(2f);
					Prefab.Toggle("Не стрелять через стену", ref RaycastOptions.WallCheck);
					GUILayout.Space(2f);
					if (!RaycastOptions.WallCheck)
					{
						Prefab.Toggle("Авто радиус", ref SphereOptions.SpherePrediction);
						GUILayout.Space(5f);
						if (!SphereOptions.SpherePrediction)
						{
							GUILayout.Label("Радиус сферы: " + Math.Round((double)SphereOptions.SphereRadius, 1) + "m", Prefab._TextStyle, Array.Empty<GUILayoutOption>());
							SphereOptions.SphereRadius = Prefab.Slider(1f, 16f, SphereOptions.SphereRadius, 200);
						}
					}
					GUILayout.Space(2f);
					GUILayout.BeginHorizontal(new GUILayoutOption[]
					{
						GUILayout.Width(230f)
					});
					GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
					Prefab.Toggle("Игроки", ref RaycastOptions.TargetPlayers);
					Prefab.Toggle("Зомби", ref RaycastOptions.TargetZombies);
					Prefab.Toggle("Кровати", ref RaycastOptions.TargetBeds);
					Prefab.Toggle("Ящики", ref RaycastOptions.TargetStorage);
					GUILayout.EndVertical();
					GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
					Prefab.Toggle("Животные", ref RaycastOptions.TargetAnimals);
					Prefab.Toggle("Клейм Флаги", ref RaycastOptions.TargetClaimFlags);
					Prefab.Toggle("Турели", ref RaycastOptions.TargetSentries);
					Prefab.Toggle("Машины", ref RaycastOptions.TargetVehicles);
					GUILayout.EndVertical();
					GUILayout.EndHorizontal();
				}
				GUILayout.EndVertical();
				GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
				Prefab.Toggle("Аимбот", ref AimbotOptions.Enabled);
				if (AimbotOptions.Enabled)
				{
					GUILayout.Space(2f);
					Prefab.Toggle("По клавише", ref AimbotOptions.OnKey);
					Prefab.Toggle("Плавность", ref AimbotOptions.Smooth);
					GUILayout.Space(3f);
					if (AimbotOptions.Smooth)
					{
						GUILayout.Label("Скорость: " + AimbotOptions.AimSpeed, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
						AimbotOptions.AimSpeed = (float)((int)Prefab.Slider(1f, AimbotOptions.MaxSpeed, AimbotOptions.AimSpeed, 200));
					}
					GUILayout.Label("FOV: " + AimbotOptions.FOV, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
					AimbotOptions.FOV = (float)((int)Prefab.Slider(1f, 90f, AimbotOptions.FOV, 200));
					Prefab.Toggle("Показывать FOV", ref MiscOptions.ShowAimFOV);
					GUILayout.Space(10f);
					string[] array = new string[]
					{
						"Дистанция",
						"FOV"
					};
					AimbotOptions.TargetMode = (TargetMode)Prefab.Arrows(200f, (int)AimbotOptions.TargetMode, "Очередь: " + array[(int)AimbotOptions.TargetMode], array.Length - 1);
				}
				GUILayout.EndVertical();
				GUILayout.EndHorizontal();
			});
		}
	}
}
