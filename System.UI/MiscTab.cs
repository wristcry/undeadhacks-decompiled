using System;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000061 RID: 97
	public static class MiscTab
	{
		// Token: 0x0600017E RID: 382 RVA: 0x0000FE60 File Offset: 0x0000E060
		public static void Tab()
		{
			Prefab.MenuArea(new Rect(0f, 0f, 611f, 406f), <Module>.smethod_5<string>(2232062503u), delegate
			{
				GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
				GUILayout.BeginVertical(new GUILayoutOption[]
				{
					GUILayout.Width(260f)
				});
				Prefab.Toggle(<Module>.smethod_8<string>(3341472904u), ref MiscOptions.SlowFall);
				Prefab.Toggle(<Module>.smethod_5<string>(1499990245u), ref MiscOptions.VehicleFly);
				if (MiscOptions.VehicleFly)
				{
					Prefab.Toggle(<Module>.smethod_5<string>(809961497u), ref MiscOptions.VehicleRigibody);
					Prefab.Toggle(<Module>.smethod_8<string>(870055684u), ref MiscOptions.VehicleUseMaxSpeed);
					if (!MiscOptions.VehicleUseMaxSpeed)
					{
						GUILayout.Space(2f);
						GUILayout.Label(<Module>.smethod_5<string>(374782137u) + MiscOptions.SpeedMultiplier + <Module>.smethod_6<string>(2483080366u), Prefab._TextStyle, Array.Empty<GUILayoutOption>());
						GUILayout.Space(2f);
						MiscOptions.SpeedMultiplier = (float)Math.Round((double)Prefab.Slider(0f, 10f, MiscOptions.SpeedMultiplier, 175), 2);
						GUILayout.Space(4f);
					}
				}
				Prefab.Toggle(<Module>.smethod_7<string>(3160497701u), ref MiscOptions.SetTimeEnabled);
				if (MiscOptions.SetTimeEnabled)
				{
					GUILayout.Label(<Module>.smethod_7<string>(2625447005u) + MiscOptions.Time, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
					GUILayout.Space(2f);
					MiscOptions.Time = (float)Math.Round((double)Prefab.Slider(0f, 0.9f, MiscOptions.Time, 175), 2);
					GUILayout.Space(8f);
				}
				Prefab.Toggle(<Module>.smethod_4<string>(3159491791u), ref MiscOptions.ExtendMeleeRange);
				if (MiscOptions.ExtendMeleeRange)
				{
					Prefab.Toggle(<Module>.smethod_6<string>(2701319131u), ref MiscOptions.ExtendRangeBypass);
				}
				GUILayout.EndVertical();
				GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
				Prefab.Toggle(<Module>.smethod_7<string>(2883311810u), ref MiscOptions.Freecam);
				if (Provider.isConnected && OptimizationVariables.MainPlayer != null)
				{
					if (!OptimizationVariables.MainPlayer.look.isOrbiting)
					{
						OptimizationVariables.MainPlayer.look.orbitPosition = Vector3.zero;
					}
					if (OptimizationVariables.MainPlayer.look.isOrbiting && Prefab.Button(<Module>.smethod_8<string>(3625931732u), 150f, 25f))
					{
						OptimizationVariables.MainPlayer.look.orbitPosition = Vector3.zero;
					}
				}
				Prefab.Toggle(<Module>.smethod_7<string>(470682493u), ref MiscOptions.CustomSalvageTime);
				if (MiscOptions.CustomSalvageTime)
				{
					GUILayout.Label(<Module>.smethod_6<string>(1688303072u) + MiscOptions.SalvageTime + <Module>.smethod_8<string>(1751817883u), Prefab._TextStyle, Array.Empty<GUILayoutOption>());
					GUILayout.Space(2f);
					MiscOptions.SalvageTime = (float)Math.Round((double)Prefab.Slider(0.2f, 10f, MiscOptions.SalvageTime, 175), 1);
					GUILayout.Space(8f);
				}
				Prefab.Toggle(<Module>.smethod_8<string>(1701254110u), ref MiscOptions.BuildObs);
				if (MiscOptions.BuildObs)
				{
					Prefab.Toggle(<Module>.smethod_4<string>(3421964583u), ref MiscOptions.epos);
					if (MiscOptions.epos)
					{
						GUILayout.Label(<Module>.smethod_5<string>(1867069412u) + MiscOptions.pos.y, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
						MiscOptions.pos.y = (float)Math.Round((double)Prefab.Slider(-3f, 3f, MiscOptions.pos.y, 175), 1);
						GUILayout.Label(<Module>.smethod_6<string>(2808346073u) + MiscOptions.pos.x, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
						MiscOptions.pos.x = (float)Math.Round((double)Prefab.Slider(-3f, 3f, MiscOptions.pos.x, 175), 1);
						GUILayout.Label(<Module>.smethod_6<string>(2042417955u) + MiscOptions.pos.z, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
						MiscOptions.pos.z = (float)Math.Round((double)Prefab.Slider(-3f, 3f, MiscOptions.pos.z, 175), 1);
					}
				}
				GUILayout.EndVertical();
				GUILayout.EndHorizontal();
				Prefab.MenuArea(new Rect(10f, 281f, 250f, 115f), <Module>.smethod_5<string>(243275422u), delegate
				{
					Prefab.Toggle(<Module>.smethod_7<string>(3843872799u), ref MiscOptions.SpammerEnabled);
					GUILayout.Space(5f);
					MiscOptions.SpamText = Prefab.TextField(MiscOptions.SpamText, <Module>.smethod_6<string>(958703910u), 160f);
					GUILayout.Space(10f);
					GUILayout.Label(<Module>.smethod_7<string>(953413580u) + MiscOptions.SpammerDelay + <Module>.smethod_4<string>(1496474218u), Prefab._TextStyle, Array.Empty<GUILayoutOption>());
					GUILayout.Space(5f);
					MiscOptions.SpammerDelay = (int)Prefab.Slider(5f, 10000f, (float)MiscOptions.SpammerDelay, 190);
				});
				Prefab.MenuArea(new Rect(265f, 241f, 256f, 155f), <Module>.smethod_7<string>(83956199u), delegate
				{
					Prefab.Toggle(<Module>.smethod_4<string>(3240450809u), ref InteractionOptions.InteractThroughWalls);
					if (InteractionOptions.InteractThroughWalls)
					{
						Prefab.Toggle(<Module>.smethod_4<string>(488350592u), ref InteractionOptions.NoHitStructures);
						Prefab.Toggle(<Module>.smethod_4<string>(3966505905u), ref InteractionOptions.NoHitBarricades);
						Prefab.Toggle(<Module>.smethod_5<string>(3116141712u), ref InteractionOptions.NoHitItems);
						Prefab.Toggle(<Module>.smethod_7<string>(2988977146u), ref InteractionOptions.NoHitVehicles);
						Prefab.Toggle(<Module>.smethod_5<string>(328746737u), ref InteractionOptions.NoHitResources);
						Prefab.Toggle(<Module>.smethod_7<string>(4125959875u), ref InteractionOptions.NoHitEnvironment);
						return;
					}
				});
			});
		}
	}
}
