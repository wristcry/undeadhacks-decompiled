using System;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000044 RID: 68
	public static class InfoTab
	{
		// Token: 0x06000111 RID: 273 RVA: 0x0000DB8C File Offset: 0x0000BD8C
		public static void Tab()
		{
			Prefab.MenuArea(new Rect(0f, 0f, 611f, 406f), <Module>.smethod_6<string>(877231245u), delegate
			{
				Prefab.MenuArea(new Rect(15f, 15f, 145f, 125f), <Module>.smethod_4<string>(4277968042u), delegate
				{
					GUILayout.Space(5f);
					if (Prefab.Button(<Module>.smethod_8<string>(3470986165u), 115f, 25f))
					{
						ConfigManager.ConfigPath = ConfigManager.appdata + ConfigManager.current + <Module>.smethod_7<string>(1252769506u);
						ConfigManager.SaveConfig();
					}
					GUILayout.Space(10f);
					if (Prefab.Button(<Module>.smethod_8<string>(553956893u), 115f, 25f))
					{
						ConfigManager.ConfigPath = ConfigManager.appdata + ConfigManager.current + <Module>.smethod_8<string>(4261082723u);
						ConfigManager.Init();
						SkinsUtilities.ApplyFromConfig();
					}
					GUILayout.Space(10f);
					ConfigManager.current = Prefab.TextField(ConfigManager.current, string.Empty, 115f);
				});
				Prefab.MenuArea(new Rect(170f, 15f, 426f, 125f), <Module>.smethod_6<string>(3175015599u), delegate
				{
					if (Provider.isConnected)
					{
						GUILayout.Label(<Module>.smethod_8<string>(1344053451u), Prefab._TextStyle, Array.Empty<GUILayoutOption>());
						GUILayout.Space(2f);
						GUILayout.TextField(string.Format(<Module>.smethod_5<string>(2750627102u), Parser.getIPFromUInt32(Provider.currentServerInfo.ip), Provider.currentServerInfo.port), Prefab._TextStyle, Array.Empty<GUILayoutOption>());
						GUILayout.Space(4f);
						GUILayout.Label(<Module>.smethod_4<string>(1989450129u), Prefab._TextStyle, Array.Empty<GUILayoutOption>());
						GUILayout.Space(2f);
						GUILayout.TextField(Provider.server.ToString(), Prefab._TextStyle, Array.Empty<GUILayoutOption>());
					}
				});
				Prefab.MenuArea(new Rect(15f, 150f, 145f, 130f), <Module>.smethod_8<string>(2235277555u), delegate
				{
					GUILayout.Space(5f);
					if (Prefab.Button(<Module>.smethod_4<string>(2261720790u), 115f, 25f))
					{
						Names.RU();
					}
					GUILayout.Space(10f);
					if (Prefab.Button(<Module>.smethod_8<string>(604520666u), 115f, 25f))
					{
						Names.EN();
					}
				});
				Prefab.MenuArea(new Rect(170f, 150f, 216f, 130f), <Module>.smethod_4<string>(1081881259u), delegate
				{
					MiscOptions.TabFont = Prefab.TextField(MiscOptions.TabFont, <Module>.smethod_4<string>(608501086u), 135f, 50f);
					GUILayout.Space(5f);
					MiscOptions.TextFont = Prefab.TextField(MiscOptions.TextFont, <Module>.smethod_7<string>(732280538u), 135f, 50f);
					GUILayout.Space(5f);
					MiscOptions.EspFont = Prefab.TextField(MiscOptions.EspFont, <Module>.smethod_5<string>(2077969476u), 135f, 50f);
					GUILayout.Space(15f);
					if (Prefab.Button(<Module>.smethod_5<string>(2490041005u), 185f, 25f))
					{
						Fonts.Apply();
					}
				});
				Prefab.MenuArea(new Rect(396f, 150f, 200f, 130f), <Module>.smethod_8<string>(16679200u), delegate
				{
					GUILayout.Space(5f);
					GUILayout.Label(<Module>.smethod_5<string>(2202876706u), Prefab._TextStyle, Array.Empty<GUILayoutOption>());
					GUILayout.Space(2f);
					if (Prefab.Button(<Module>.smethod_6<string>(547780657u), 170f, 25f))
					{
						Application.OpenURL(<Module>.smethod_6<string>(82453951u));
					}
				});
			});
		}

		// Token: 0x040000F4 RID: 244
		public static string groupid;
	}
}
