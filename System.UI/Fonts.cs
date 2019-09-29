using System;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200003A RID: 58
	public static class Fonts
	{
		// Token: 0x060000F7 RID: 247 RVA: 0x0000CD2C File Offset: 0x0000AF2C
		public static void Apply()
		{
			if (string.IsNullOrEmpty(MiscOptions.TabFont))
			{
				MiscOptions.TabFont = "Comic Sans MS";
			}
			if (string.IsNullOrEmpty(MiscOptions.TextFont))
			{
				MiscOptions.TextFont = "Arial";
			}
			if (string.IsNullOrEmpty(MiscOptions.EspFont))
			{
				MiscOptions.EspFont = "Arial";
			}
			Fonts.tab = Font.CreateDynamicFontFromOSFont(MiscOptions.TabFont, 29);
			Fonts.text = Font.CreateDynamicFontFromOSFont(MiscOptions.TextFont, 15);
			Fonts.esp = Font.CreateDynamicFontFromOSFont(MiscOptions.EspFont, 11);
			Prefab._MenuTabStyle.font = Fonts.tab;
			Prefab._HeaderStyle.font = Fonts.tab;
			Prefab._TextStyle.font = Fonts.text;
			Prefab._listStyle.font = Fonts.text;
			Prefab._ButtonStyle.font = Fonts.text;
			ESPComponent.ESPFont = Fonts.esp;
		}

		// Token: 0x040000DA RID: 218
		public static Font tab;

		// Token: 0x040000DB RID: 219
		public static Font text;

		// Token: 0x040000DC RID: 220
		public static Font esp;
	}
}
