using System;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000029 RID: 41
	public static class Drawing
	{
		// Token: 0x060000AB RID: 171 RVA: 0x00003A4A File Offset: 0x00001C4A
		public static void DrawRect(Rect position, Color color)
		{
			Color backgroundColor = GUI.backgroundColor;
			GUI.backgroundColor = color;
			GUI.Box(position, GUIContent.none, Drawing.textureStyle);
			GUI.backgroundColor = backgroundColor;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00003A6C File Offset: 0x00001C6C
		public static void LayoutBox(Color color, GUIContent content = null)
		{
			Color backgroundColor = GUI.backgroundColor;
			GUI.backgroundColor = color;
			GUILayout.Box(content ?? GUIContent.none, Drawing.textureStyle, Array.Empty<GUILayoutOption>());
			GUI.backgroundColor = backgroundColor;
		}

		// Token: 0x0400007A RID: 122
		private static readonly Texture2D backgroundTexture = Texture2D.whiteTexture;

		// Token: 0x0400007B RID: 123
		private static readonly GUIStyle textureStyle = new GUIStyle
		{
			normal = new GUIStyleState
			{
				background = Drawing.backgroundTexture
			}
		};
	}
}
