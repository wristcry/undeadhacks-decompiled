using System;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200005B RID: 91
	public static class MenuUtilities
	{
		// Token: 0x06000160 RID: 352 RVA: 0x0000409E File Offset: 0x0000229E
		static MenuUtilities()
		{
			MenuUtilities.TexClear.SetPixel(0, 0, new Color(0f, 0f, 0f, 0f));
			MenuUtilities.TexClear.Apply();
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0000F40C File Offset: 0x0000D60C
		public static void FixGUIStyleColor(GUIStyle style)
		{
			style.normal.background = MenuUtilities.TexClear;
			style.onNormal.background = MenuUtilities.TexClear;
			style.hover.background = MenuUtilities.TexClear;
			style.onHover.background = MenuUtilities.TexClear;
			style.active.background = MenuUtilities.TexClear;
			style.onActive.background = MenuUtilities.TexClear;
			style.focused.background = MenuUtilities.TexClear;
			style.onFocused.background = MenuUtilities.TexClear;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x000040DB File Offset: 0x000022DB
		public static Rect Inline(Rect rect, float border = 1f)
		{
			return new Rect(rect.x + border, rect.y + border, rect.width - border * 2f, rect.height - border * 2f);
		}

		// Token: 0x04000146 RID: 326
		public static Texture2D TexClear = new Texture2D(1, 1);
	}
}
