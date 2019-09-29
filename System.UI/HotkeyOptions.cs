using System;
using System.Collections.Generic;

namespace UndeadHacks
{
	// Token: 0x0200003E RID: 62
	public static class HotkeyOptions
	{
		// Token: 0x040000E5 RID: 229
		[Save]
		public static Dictionary<string, Dictionary<string, Hotkey>> HotkeyDict = new Dictionary<string, Dictionary<string, Hotkey>>();

		// Token: 0x040000E6 RID: 230
		[Save]
		public static Dictionary<string, Hotkey> UnorganizedHotkeys = new Dictionary<string, Hotkey>();

		// Token: 0x040000E7 RID: 231
		[Save]
		public static Dictionary<string, Hotkey> ChatKeys = new Dictionary<string, Hotkey>();
	}
}
