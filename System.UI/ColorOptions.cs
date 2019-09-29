using System;
using System.Collections.Generic;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200001D RID: 29
	public static class ColorOptions
	{
		// Token: 0x04000054 RID: 84
		[Save]
		public static Dictionary<string, ColorVariable> ColorDict = new Dictionary<string, ColorVariable>();

		// Token: 0x04000055 RID: 85
		public static Dictionary<string, ColorVariable> ColorDict2 = new Dictionary<string, ColorVariable>();

		// Token: 0x04000056 RID: 86
		public static ColorVariable errorColor = new ColorVariable("errorColor", "#ERROR.NOTFOUND", Color.magenta, true);

		// Token: 0x04000057 RID: 87
		public static string selectedOption;

		// Token: 0x04000058 RID: 88
		public static ColorVariable preview = new ColorVariable("preview", "No Color Selected", Color.white, true);

		// Token: 0x04000059 RID: 89
		public static ColorVariable previewselected;
	}
}
