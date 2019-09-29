using System;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200003A RID: 58
	public static class Fonts
	{
		// Token: 0x060000F7 RID: 247 RVA: 0x0000CB40 File Offset: 0x0000AD40
		public static void Apply()
		{
			if (string.IsNullOrEmpty(MiscOptions.TabFont))
			{
				MiscOptions.TabFont = <Module>.smethod_7<string>(1999292701u);
			}
			if (string.IsNullOrEmpty(MiscOptions.TextFont))
			{
				MiscOptions.TextFont = <Module>.smethod_8<string>(1163374739u);
			}
			if (string.IsNullOrEmpty(MiscOptions.EspFont))
			{
				MiscOptions.EspFont = <Module>.smethod_6<string>(1296969251u);
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
