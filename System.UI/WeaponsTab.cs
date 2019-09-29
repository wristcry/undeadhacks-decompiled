using System;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x020000B5 RID: 181
	public static class WeaponsTab
	{
		// Token: 0x0600029F RID: 671 RVA: 0x00017F84 File Offset: 0x00016184
		public static void Tab()
		{
			Prefab.MenuArea(new Rect(0f, 0f, 611f, 406f), <Module>.smethod_7<string>(208571389u), delegate
			{
				GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
				GUILayout.BeginVertical(new GUILayoutOption[]
				{
					GUILayout.Width(260f)
				});
				Prefab.Toggle("Нет отдачи", ref WeaponOptions.NoRecoil);
				Prefab.Toggle("Нет разброса", ref WeaponOptions.NoSpread);
				Prefab.Toggle("Нет увода", ref WeaponOptions.NoSway);
				Prefab.Toggle("Нет падения пули", ref WeaponOptions.NoDrop);
				Prefab.Toggle("Триггербот", ref TriggerbotOptions.Enabled);
				Prefab.Toggle("Информация об оружии", ref WeaponOptions.ShowWeaponInfo);
				GUILayout.Space(2f);
				GUILayout.EndVertical();
				GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
				Prefab.Toggle("Изменить зум прицела", ref WeaponOptions.Zoom);
				if (WeaponOptions.Zoom)
				{
					GUILayout.Space(2f);
					GUILayout.Label("Зум: " + WeaponOptions.ZoomValue, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
					WeaponOptions.ZoomValue = (float)((int)Prefab.Slider(2f, 30f, WeaponOptions.ZoomValue, 200));
				}
				GUILayout.EndVertical();
				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
			});
		}
	}
}
