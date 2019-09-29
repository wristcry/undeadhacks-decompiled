using System;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000061 RID: 97
	public static class MiscTab
	{
		// Token: 0x0600017E RID: 382 RVA: 0x0000FE28 File Offset: 0x0000E028
		public static void Tab()
		{
			Prefab.MenuArea(new Rect(0f, 0f, 611f, 406f), <Module>.smethod_5<string>(2232062503u), delegate
			{
				GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
				GUILayout.BeginVertical(new GUILayoutOption[]
				{
					GUILayout.Width(260f)
				});
				Prefab.Toggle("Медленное падение", ref MiscOptions.SlowFall);
				Prefab.Toggle("Полёт на машине", ref MiscOptions.VehicleFly);
				if (MiscOptions.VehicleFly)
				{
					Prefab.Toggle("Использовать Rigibody", ref MiscOptions.VehicleRigibody);
					Prefab.Toggle("Использовать макс скорость", ref MiscOptions.VehicleUseMaxSpeed);
					if (!MiscOptions.VehicleUseMaxSpeed)
					{
						GUILayout.Space(2f);
						GUILayout.Label("Скорость: " + MiscOptions.SpeedMultiplier + "x", Prefab._TextStyle, Array.Empty<GUILayoutOption>());
						GUILayout.Space(2f);
						MiscOptions.SpeedMultiplier = (float)Math.Round((double)Prefab.Slider(0f, 10f, MiscOptions.SpeedMultiplier, 175), 2);
						GUILayout.Space(4f);
					}
				}
				Prefab.Toggle("Изменить время", ref MiscOptions.SetTimeEnabled);
				if (MiscOptions.SetTimeEnabled)
				{
					GUILayout.Label("Время: " + MiscOptions.Time, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
					GUILayout.Space(2f);
					MiscOptions.Time = (float)Math.Round((double)Prefab.Slider(0f, 0.9f, MiscOptions.Time, 175), 2);
					GUILayout.Space(8f);
				}
				Prefab.Toggle("Дальность удара", ref MiscOptions.ExtendMeleeRange);
				if (MiscOptions.ExtendMeleeRange)
				{
					Prefab.Toggle("Режим совместимости", ref MiscOptions.ExtendRangeBypass);
				}
				GUILayout.EndVertical();
				GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
				Prefab.Toggle("Свободная камера", ref MiscOptions.Freecam);
				if (Provider.isConnected && Player.player != null)
				{
					if (!Player.player.look.isOrbiting)
					{
						Player.player.look.orbitPosition = Vector3.zero;
					}
					if (Player.player.look.isOrbiting && Prefab.Button("Вернуть камеру", 150f, 25f))
					{
						Player.player.look.orbitPosition = Vector3.zero;
					}
				}
				Prefab.Toggle("Время забирания построек", ref MiscOptions.CustomSalvageTime);
				if (MiscOptions.CustomSalvageTime)
				{
					GUILayout.Label("Время: " + MiscOptions.SalvageTime + " секунд", Prefab._TextStyle, Array.Empty<GUILayoutOption>());
					GUILayout.Space(2f);
					MiscOptions.SalvageTime = (float)Math.Round((double)Prefab.Slider(0.2f, 10f, MiscOptions.SalvageTime, 175), 1);
					GUILayout.Space(8f);
				}
				Prefab.Toggle("Ставить в текстуры", ref MiscOptions.BuildObs);
				if (MiscOptions.BuildObs)
				{
					Prefab.Toggle("Смещение", ref MiscOptions.epos);
					if (MiscOptions.epos)
					{
						GUILayout.Label("Y: " + MiscOptions.pos.y, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
						MiscOptions.pos.y = (float)Math.Round((double)Prefab.Slider(-3f, 3f, MiscOptions.pos.y, 175), 1);
						GUILayout.Label("X: " + MiscOptions.pos.x, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
						MiscOptions.pos.x = (float)Math.Round((double)Prefab.Slider(-3f, 3f, MiscOptions.pos.x, 175), 1);
						GUILayout.Label("Z: " + MiscOptions.pos.z, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
						MiscOptions.pos.z = (float)Math.Round((double)Prefab.Slider(-3f, 3f, MiscOptions.pos.z, 175), 1);
					}
				}
				GUILayout.EndVertical();
				GUILayout.EndHorizontal();
				Prefab.MenuArea(new Rect(10f, 281f, 250f, 115f), "СПАМ", delegate
				{
					Prefab.Toggle("Включить", ref MiscOptions.SpammerEnabled);
					GUILayout.Space(5f);
					MiscOptions.SpamText = Prefab.TextField(MiscOptions.SpamText, "Текст: ", 160f);
					GUILayout.Space(10f);
					GUILayout.Label("Задержка: " + MiscOptions.SpammerDelay + "ms", Prefab._TextStyle, Array.Empty<GUILayoutOption>());
					GUILayout.Space(5f);
					MiscOptions.SpammerDelay = (int)Prefab.Slider(5f, 10000f, (float)MiscOptions.SpammerDelay, 190);
				});
				Prefab.MenuArea(new Rect(265f, 241f, 256f, 155f), "ВЗАИМОДЕЙСТВИЕ", delegate
				{
					Prefab.Toggle("Включить", ref InteractionOptions.InteractThroughWalls);
					if (InteractionOptions.InteractThroughWalls)
					{
						Prefab.Toggle("Через Стены/Полы/и тп", ref InteractionOptions.NoHitStructures);
						Prefab.Toggle("Через Ящики/Двери/и тп", ref InteractionOptions.NoHitBarricades);
						Prefab.Toggle("Через Предметы", ref InteractionOptions.NoHitItems);
						Prefab.Toggle("Через Транспорт", ref InteractionOptions.NoHitVehicles);
						Prefab.Toggle("Через Ресурсы", ref InteractionOptions.NoHitResources);
						Prefab.Toggle("Через Земля/Постройки", ref InteractionOptions.NoHitEnvironment);
						return;
					}
				});
			});
		}
	}
}
