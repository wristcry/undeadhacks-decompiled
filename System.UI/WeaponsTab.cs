using System;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x020000B5 RID: 181
	public static class WeaponsTab
	{
		// Token: 0x060002A2 RID: 674 RVA: 0x00018284 File Offset: 0x00016484
		public static void Tab()
		{
			Prefab.MenuArea(new Rect(0f, 0f, 611f, 406f), <Module>.smethod_7<string>(208571389u), delegate
			{
				GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
				GUILayout.BeginVertical(new GUILayoutOption[]
				{
					GUILayout.Width(260f)
				});
				Prefab.Toggle(<Module>.smethod_5<string>(1954626803u), ref WeaponOptions.NoRecoil);
				Prefab.Toggle(<Module>.smethod_7<string>(1947486151u), ref WeaponOptions.NoSpread);
				Prefab.Toggle(<Module>.smethod_5<string>(2499248085u), ref WeaponOptions.NoSway);
				Prefab.Toggle(<Module>.smethod_4<string>(1361880118u), ref WeaponOptions.NoDrop);
				Prefab.Toggle(<Module>.smethod_6<string>(1074545605u), ref TriggerbotOptions.Enabled);
				Prefab.Toggle(<Module>.smethod_5<string>(3328606333u), ref WeaponOptions.ShowWeaponInfo);
				GUILayout.Space(2f);
				GUILayout.EndVertical();
				GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
				Prefab.Toggle(<Module>.smethod_8<string>(933034771u), ref WeaponOptions.Zoom);
				if (WeaponOptions.Zoom)
				{
					GUILayout.Space(2f);
					GUILayout.Label(<Module>.smethod_7<string>(3447999021u) + WeaponOptions.ZoomValue, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
					WeaponOptions.ZoomValue = (float)((int)Prefab.Slider(2f, 30f, WeaponOptions.ZoomValue, 200));
				}
				GUILayout.EndVertical();
				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
			});
		}
	}
}
