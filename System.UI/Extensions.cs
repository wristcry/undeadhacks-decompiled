using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000039 RID: 57
	public static class Extensions
	{
		// Token: 0x060000F4 RID: 244 RVA: 0x00003D1F File Offset: 0x00001F1F
		public static Color Invert(this Color32 color)
		{
			return new Color((float)(byte.MaxValue - color.r), (float)(byte.MaxValue - color.g), (float)(byte.MaxValue - color.b));
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00003D4D File Offset: 0x00001F4D
		public static SerializableColor ToSerializableColor(this Color32 c)
		{
			return new SerializableColor((int)c.r, (int)c.g, (int)c.b, (int)c.a);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00003D6C File Offset: 0x00001F6C
		public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int N)
		{
			return source.Skip(Math.Max(0, source.Count<T>() - N));
		}
	}
}
