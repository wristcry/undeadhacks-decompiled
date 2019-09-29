using System;

namespace UndeadHacks
{
	// Token: 0x02000059 RID: 89
	public class MenuTabOption
	{
		// Token: 0x0600015A RID: 346 RVA: 0x0000407C File Offset: 0x0000227C
		public MenuTabOption(string name, MenuTabOption.MenuTab tab)
		{
			this.tab = tab;
			this.name = name;
		}

		// Token: 0x04000141 RID: 321
		public static MenuTabOption CurrentTab;

		// Token: 0x04000142 RID: 322
		public static MenuTabOption[] tabs = new MenuTabOption[]
		{
			new MenuTabOption(<Module>.smethod_5<string>(29246244u), new MenuTabOption.MenuTab(VisualsTab.Tab)),
			new MenuTabOption(<Module>.smethod_5<string>(2364090737u), new MenuTabOption.MenuTab(AimbotTab.Tab)),
			new MenuTabOption(<Module>.smethod_4<string>(80473041u), new MenuTabOption.MenuTab(WeaponsTab.Tab)),
			new MenuTabOption(<Module>.smethod_5<string>(865203977u), new MenuTabOption.MenuTab(PlayersTab.Tab)),
			new MenuTabOption(<Module>.smethod_6<string>(2461710970u), new MenuTabOption.MenuTab(StatsTab.Tab)),
			new MenuTabOption(<Module>.smethod_5<string>(1364832897u), new MenuTabOption.MenuTab(SkinsTab.Tab)),
			new MenuTabOption(<Module>.smethod_7<string>(615273655u), new MenuTabOption.MenuTab(MiscTab.Tab)),
			new MenuTabOption(<Module>.smethod_6<string>(3363515206u), new MenuTabOption.MenuTab(MoreMiscTab.Tab)),
			new MenuTabOption(<Module>.smethod_7<string>(3907020896u), new MenuTabOption.MenuTab(ColorsTab.Tab)),
			new MenuTabOption(<Module>.smethod_4<string>(4002614920u), new MenuTabOption.MenuTab(HotkeyTab.Tab)),
			new MenuTabOption(<Module>.smethod_8<string>(2200082505u), new MenuTabOption.MenuTab(InfoTab.Tab)),
			new MenuTabOption(<Module>.smethod_4<string>(2359193085u), new MenuTabOption.MenuTab(AttachTab.Tab))
		};

		// Token: 0x04000143 RID: 323
		public bool enabled;

		// Token: 0x04000144 RID: 324
		public string name;

		// Token: 0x04000145 RID: 325
		public MenuTabOption.MenuTab tab;

		// Token: 0x0200005A RID: 90
		// (Invoke) Token: 0x0600015D RID: 349
		public delegate void MenuTab();
	}
}
