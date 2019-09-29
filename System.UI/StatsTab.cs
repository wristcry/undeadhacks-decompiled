using System;
using Steamworks;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x020000A5 RID: 165
	public static class StatsTab
	{
		// Token: 0x06000269 RID: 617 RVA: 0x00016868 File Offset: 0x00014A68
		public static void Tab()
		{
			Prefab.ScrollView(new Rect(0f, 0f, 395f, 406f), "СТАТИСТИКА", ref StatsTab.ScrollPos, delegate()
			{
				for (int i = 0; i < StatsTab.StatLabels.Length; i++)
				{
					if (Prefab.Button(StatsTab.StatLabels[i], 350f, 25f))
					{
						StatsTab.Selected = i;
					}
					GUILayout.Space(3f);
				}
			}, 20);
			Prefab.MenuArea(new Rect(400f, 0f, 196f, 406f), "Изменить", delegate
			{
				if (StatsTab.Selected == 0)
				{
					return;
				}
				string text = StatsTab.StatLabels[StatsTab.Selected];
				int num;
				if (!SteamUserStats.GetStat(StatsTab.StatNames[StatsTab.Selected], out num))
				{
					return;
				}
				GUILayout.Label(text, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
				GUILayout.Space(4f);
				GUILayout.Label(string.Format("Текущее: {0}", num), Prefab._TextStyle, Array.Empty<GUILayoutOption>());
				GUILayout.Space(3f);
				StatsTab.Amount = Prefab.TextField(StatsTab.Amount, "Изменение: ", 50f);
				GUILayout.Space(2f);
				int num2;
				if (int.TryParse(StatsTab.Amount, out num2))
				{
					if (Prefab.Button("Добавить", 75f, 25f))
					{
						for (int i = 1; i <= num2; i++)
						{
							SteamUserStats.SetStat(StatsTab.StatNames[StatsTab.Selected], num + i);
						}
						SteamUserStats.StoreStats();
					}
					return;
				}
			});
		}

		// Token: 0x04000235 RID: 565
		public static int Selected;

		// Token: 0x04000236 RID: 566
		public static Vector2 ScrollPos;

		// Token: 0x04000237 RID: 567
		public static string Amount = string.Empty;

		// Token: 0x04000238 RID: 568
		public static string[] StatLabels = new string[]
		{
			<Module>.smethod_6<string>(3228974061u),
			<Module>.smethod_5<string>(51832556u),
			<Module>.smethod_7<string>(2252769380u),
			<Module>.smethod_6<string>(465863001u),
			<Module>.smethod_8<string>(3382273933u),
			<Module>.smethod_4<string>(1410869463u),
			<Module>.smethod_5<string>(3847170932u),
			<Module>.smethod_7<string>(633055564u),
			<Module>.smethod_8<string>(3575067120u),
			<Module>.smethod_4<string>(3226007203u),
			<Module>.smethod_5<string>(2799791616u),
			<Module>.smethod_8<string>(3230582614u),
			<Module>.smethod_8<string>(515808434u),
			<Module>.smethod_4<string>(4143373942u),
			<Module>.smethod_6<string>(2298320649u),
			<Module>.smethod_6<string>(1968870061u),
			<Module>.smethod_7<string>(2601737793u),
			<Module>.smethod_6<string>(4266654415u),
			<Module>.smethod_6<string>(2734798179u),
			<Module>.smethod_6<string>(4048415650u)
		};

		// Token: 0x04000239 RID: 569
		public static string[] StatNames = new string[]
		{
			<Module>.smethod_6<string>(3228974061u),
			<Module>.smethod_5<string>(2406134247u),
			<Module>.smethod_7<string>(3270551163u),
			<Module>.smethod_5<string>(3069063274u),
			<Module>.smethod_6<string>(107563237u),
			<Module>.smethod_5<string>(1358754931u),
			<Module>.smethod_8<string>(3322248255u),
			<Module>.smethod_5<string>(2319619894u),
			<Module>.smethod_5<string>(359497091u),
			<Module>.smethod_8<string>(1539800047u),
			<Module>.smethod_4<string>(3718983114u),
			<Module>.smethod_7<string>(2415655510u),
			<Module>.smethod_5<string>(1397147808u),
			<Module>.smethod_8<string>(3960653494u),
			<Module>.smethod_6<string>(2298320649u),
			<Module>.smethod_6<string>(1256455414u),
			<Module>.smethod_4<string>(704410105u),
			<Module>.smethod_4<string>(3436914584u),
			<Module>.smethod_8<string>(4153446681u),
			<Module>.smethod_6<string>(3525390592u)
		};
	}
}
