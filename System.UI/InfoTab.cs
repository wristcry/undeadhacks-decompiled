using System;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000044 RID: 68
	public static class InfoTab
	{
		// Token: 0x06000111 RID: 273 RVA: 0x0000DBC4 File Offset: 0x0000BDC4
		public static void Tab()
		{
			Prefab.MenuArea(new Rect(0f, 0f, 611f, 406f), <Module>.smethod_6<string>(877231245u), delegate
			{
				Prefab.MenuArea(new Rect(15f, 15f, 145f, 125f), "КОНФИГ", delegate
				{
					GUILayout.Space(5f);
					if (Prefab.Button("Сохранить", 115f, 25f))
					{
						ConfigManager.ConfigPath = ConfigManager.appdata + ConfigManager.current + ".txt";
						ConfigManager.SaveConfig();
					}
					GUILayout.Space(10f);
					if (Prefab.Button("Загрузить", 115f, 25f))
					{
						ConfigManager.ConfigPath = ConfigManager.appdata + ConfigManager.current + ".txt";
						ConfigManager.Init();
						SkinsUtilities.ApplyFromConfig();
					}
					GUILayout.Space(10f);
					ConfigManager.current = Prefab.TextField(ConfigManager.current, string.Empty, 115f);
				});
				Prefab.MenuArea(new Rect(170f, 15f, 426f, 125f), "СЕРВЕР", delegate
				{
					if (Provider.isConnected)
					{
						GUILayout.Label("IP текущего сервера: ", Prefab._TextStyle, Array.Empty<GUILayoutOption>());
						GUILayout.Space(2f);
						GUILayout.TextField(string.Format("{0}:{1}", Parser.getIPFromUInt32(Provider.currentServerInfo.ip), Provider.currentServerInfo.port), Prefab._TextStyle, Array.Empty<GUILayoutOption>());
						GUILayout.Space(4f);
						GUILayout.Label("SteamID сервера: ", Prefab._TextStyle, Array.Empty<GUILayoutOption>());
						GUILayout.Space(2f);
						GUILayout.TextField(Provider.server.ToString(), Prefab._TextStyle, Array.Empty<GUILayoutOption>());
					}
				});
				Prefab.MenuArea(new Rect(15f, 150f, 145f, 130f), "ЯЗЫК", delegate
				{
					GUILayout.Space(5f);
					if (Prefab.Button("Русский", 115f, 25f))
					{
						Names.RU();
					}
					GUILayout.Space(10f);
					if (Prefab.Button("English", 115f, 25f))
					{
						Names.EN();
					}
				});
				Prefab.MenuArea(new Rect(170f, 150f, 216f, 130f), "ШРИФТЫ", delegate
				{
					MiscOptions.TabFont = Prefab.TextField(MiscOptions.TabFont, "Окна:", 135f, 50f);
					GUILayout.Space(5f);
					MiscOptions.TextFont = Prefab.TextField(MiscOptions.TextFont, "Текст:", 135f, 50f);
					GUILayout.Space(5f);
					MiscOptions.EspFont = Prefab.TextField(MiscOptions.EspFont, "ESP:", 135f, 50f);
					GUILayout.Space(15f);
					if (Prefab.Button("Применить", 185f, 25f))
					{
						Fonts.Apply();
					}
				});
				Prefab.MenuArea(new Rect(396f, 150f, 200f, 130f), "ИНФО", delegate
				{
					GUILayout.Space(5f);
					GUILayout.Label("Создатель: Gazzi", Prefab._TextStyle, Array.Empty<GUILayoutOption>());
					GUILayout.Space(2f);
					if (Prefab.Button("Группа в ВК", 170f, 25f))
					{
						Application.OpenURL("http://vk.com/undeadhacks");
					}
				});
			});
		}

		// Token: 0x040000F4 RID: 244
		public static string groupid;
	}
}
