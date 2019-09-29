using System;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000018 RID: 24
	public static class AimbotTab
	{
		// Token: 0x0600006D RID: 109 RVA: 0x00007DE8 File Offset: 0x00005FE8
		public static void Tab()
		{
			Prefab.MenuArea(new Rect(0f, 0f, 611f, 406f), <Module>.smethod_7<string>(3665911882u), delegate
			{
				Prefab.MenuArea(new Rect(10f, 291f, 230f, 105f), <Module>.smethod_5<string>(1239404148u), delegate
				{
					Prefab.Toggle(<Module>.smethod_8<string>(3989039209u), ref RaycastOptions.UseRandomLimb);
					if (!RaycastOptions.UseRandomLimb)
					{
						Prefab.Toggle(<Module>.smethod_7<string>(3226865979u), ref RaycastOptions.UseCustomLimb);
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
				Prefab.Toggle(<Module>.smethod_7<string>(3063979849u), ref RaycastOptions.Enabled);
				GUILayout.Space(2f);
				if (RaycastOptions.Enabled)
				{
					Prefab.Toggle(<Module>.smethod_6<string>(2605956850u), ref RaycastOptions.SilentAimUseFOV);
					if (RaycastOptions.SilentAimUseFOV)
					{
						GUILayout.Space(2f);
						GUILayout.Label(<Module>.smethod_7<string>(240401967u) + RaycastOptions.SilentAimFOV, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
						RaycastOptions.SilentAimFOV = (float)((int)Prefab.Slider(1f, 90f, RaycastOptions.SilentAimFOV, 200));
						Prefab.Toggle(<Module>.smethod_4<string>(3524589010u), ref MiscOptions.ShowSilentFOV);
					}
					GUILayout.Space(2f);
					Prefab.Toggle(<Module>.smethod_6<string>(7571084u), ref RaycastOptions.WallCheck);
					GUILayout.Space(2f);
					if (!RaycastOptions.WallCheck)
					{
						Prefab.Toggle(<Module>.smethod_4<string>(2383940955u), ref SphereOptions.SpherePrediction);
						GUILayout.Space(5f);
						if (!SphereOptions.SpherePrediction)
						{
							GUILayout.Label(<Module>.smethod_6<string>(1127614085u) + Math.Round((double)SphereOptions.SphereRadius, 1) + <Module>.smethod_6<string>(526411261u), Prefab._TextStyle, Array.Empty<GUILayoutOption>());
							SphereOptions.SphereRadius = Prefab.Slider(1f, 16f, SphereOptions.SphereRadius, 200);
						}
					}
					GUILayout.Space(2f);
					GUILayout.BeginHorizontal(new GUILayoutOption[]
					{
						GUILayout.Width(230f)
					});
					GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
					Prefab.Toggle(<Module>.smethod_5<string>(1633583036u), ref RaycastOptions.TargetPlayers);
					Prefab.Toggle(<Module>.smethod_6<string>(2523594203u), ref RaycastOptions.TargetZombies);
					Prefab.Toggle(<Module>.smethod_6<string>(2824195615u), ref RaycastOptions.TargetBeds);
					Prefab.Toggle(<Module>.smethod_4<string>(3392064581u), ref RaycastOptions.TargetStorage);
					GUILayout.EndVertical();
					GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
					Prefab.Toggle(<Module>.smethod_5<string>(2421419293u), ref RaycastOptions.TargetAnimals);
					Prefab.Toggle(<Module>.smethod_8<string>(1274265029u), ref RaycastOptions.TargetClaimFlags);
					Prefab.Toggle(<Module>.smethod_7<string>(4282405643u), ref RaycastOptions.TargetSentries);
					Prefab.Toggle(<Module>.smethod_7<string>(1860115783u), ref RaycastOptions.TargetVehicles);
					GUILayout.EndVertical();
					GUILayout.EndHorizontal();
				}
				GUILayout.EndVertical();
				GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
				Prefab.Toggle(<Module>.smethod_5<string>(1671975913u), ref AimbotOptions.Enabled);
				if (AimbotOptions.Enabled)
				{
					GUILayout.Space(2f);
					Prefab.Toggle(<Module>.smethod_7<string>(1325065087u), ref AimbotOptions.OnKey);
					Prefab.Toggle(<Module>.smethod_6<string>(1481728968u), ref AimbotOptions.Smooth);
					GUILayout.Space(3f);
					if (AimbotOptions.Smooth)
					{
						GUILayout.Label(<Module>.smethod_5<string>(374782137u) + AimbotOptions.AimSpeed, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
						AimbotOptions.AimSpeed = (float)((int)Prefab.Slider(1f, AimbotOptions.MaxSpeed, AimbotOptions.AimSpeed, 200));
					}
					GUILayout.Label(<Module>.smethod_4<string>(3615345897u) + AimbotOptions.FOV, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
					AimbotOptions.FOV = (float)((int)Prefab.Slider(1f, 90f, AimbotOptions.FOV, 200));
					Prefab.Toggle(<Module>.smethod_4<string>(3524589010u), ref MiscOptions.ShowAimFOV);
					GUILayout.Space(10f);
					string[] array = new string[]
					{
						<Module>.smethod_6<string>(270953558u),
						<Module>.smethod_8<string>(3492863384u)
					};
					AimbotOptions.TargetMode = (TargetMode)Prefab.Arrows(200f, (int)AimbotOptions.TargetMode, <Module>.smethod_4<string>(85625173u) + array[(int)AimbotOptions.TargetMode], array.Length - 1);
				}
				GUILayout.EndVertical();
				GUILayout.EndHorizontal();
			});
		}
	}
}
