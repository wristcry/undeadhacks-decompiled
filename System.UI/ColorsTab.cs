using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000020 RID: 32
	public static class ColorsTab
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000081 RID: 129 RVA: 0x00003887 File Offset: 0x00001A87
		// (set) Token: 0x06000082 RID: 130 RVA: 0x0000388E File Offset: 0x00001A8E
		public static Color LastColorPreview1 { get; set; } = ColorOptions.preview.color;

		// Token: 0x06000083 RID: 131 RVA: 0x00008BD8 File Offset: 0x00006DD8
		public static void Tab()
		{
			ColorOptions.errorColor = new ColorVariable("errorColor", "#ERROR.NOTFOUND", Color.magenta, true);
			ColorOptions.preview = new ColorVariable("preview", "Цвет не выбран", Color.white, true);
			if (ColorOptions.selectedOption == null)
			{
				ColorOptions.previewselected = ColorOptions.preview;
			}
			Prefab.ScrollView(new Rect(0f, 0f, 395f, 406f), "Цвета", ref ColorsTab.ColorScroll, delegate()
			{
				GUILayout.Space(10f);
				List<KeyValuePair<string, ColorVariable>> list = ColorOptions.ColorDict2.ToList<KeyValuePair<string, ColorVariable>>();
				list.Sort((KeyValuePair<string, ColorVariable> pair1, KeyValuePair<string, ColorVariable> pair2) => pair1.Value.name.CompareTo(pair2.Value.name));
				for (int i = 0; i < list.Count; i++)
				{
					ColorVariable color = ColorUtilities.getColor(list[i].Value.identity);
					if (Prefab.ColorButton(350f, color, 25f))
					{
						ColorOptions.selectedOption = color.identity;
						ColorOptions.previewselected = new ColorVariable(color);
						ColorsTab.LastColorPreview1 = color.color;
					}
					GUILayout.Space(3f);
				}
				if (Prefab.Button("Восстановить цвета", 350f, 25f))
				{
					for (int j = 0; j < list.Count; j++)
					{
						ColorVariable color2 = ColorUtilities.getColor(list[j].Value.identity);
						color2.color = color2.origColor;
						MenuComponent.SetGUIColors();
						ColorOptions.selectedOption = null;
						ColorsTab.LastColorPreview1 = ColorOptions.preview.color;
					}
				}
				GUILayout.Space(10f);
			}, 20);
			Rect previewRect = new Rect(400f, 0f, 211f, 120f);
			Prefab.MenuArea(previewRect, "Просмотр", delegate
			{
				Rect rect = new Rect(5f, 20f, previewRect.width - 10f, previewRect.height - 25f);
				Drawing.DrawRect(rect, MenuComponent._OutlineBorderBlack);
				Drawing.DrawRect(MenuUtilities.Inline(rect, 1f), MenuComponent._OutlineBorderLightGray);
				Rect rect2 = MenuUtilities.Inline(rect, 2f);
				Drawing.DrawRect(new Rect(rect2.x, rect2.y, rect2.width / 2f, rect2.height), ColorsTab.LastColorPreview1);
				Drawing.DrawRect(new Rect(rect2.x + rect2.width / 2f, rect2.y, rect2.width / 2f, rect2.height), ColorOptions.previewselected);
			});
			Prefab.MenuArea(new Rect(previewRect.x, previewRect.y + previewRect.height + 5f, previewRect.width, 406f - previewRect.height - 5f), ColorOptions.previewselected.name, delegate
			{
				GUILayout.BeginArea(new Rect(10f, 20f, previewRect.width - 10f, 205f));
				ColorOptions.previewselected.color.r = (int)((byte)Prefab.TextField(ColorOptions.previewselected.color.r, "R: ", 30, 0, 255));
				ColorOptions.previewselected.color.r = (int)((byte)Prefab.Slider(0f, 255f, (float)ColorOptions.previewselected.color.r, 185));
				GUILayout.FlexibleSpace();
				ColorOptions.previewselected.color.g = (int)((byte)Prefab.TextField(ColorOptions.previewselected.color.g, "G: ", 30, 0, 255));
				ColorOptions.previewselected.color.g = (int)((byte)Prefab.Slider(0f, 255f, (float)ColorOptions.previewselected.color.g, 185));
				GUILayout.FlexibleSpace();
				ColorOptions.previewselected.color.b = (int)((byte)Prefab.TextField(ColorOptions.previewselected.color.b, "B: ", 30, 0, 255));
				ColorOptions.previewselected.color.b = (int)((byte)Prefab.Slider(0f, 255f, (float)ColorOptions.previewselected.color.b, 185));
				GUILayout.FlexibleSpace();
				if (!ColorOptions.previewselected.disableAlpha)
				{
					ColorOptions.previewselected.color.a = (int)((byte)Prefab.TextField(ColorOptions.previewselected.color.a, "A: ", 30, 0, 255));
					ColorOptions.previewselected.color.a = (int)((byte)Prefab.Slider(0f, 255f, (float)ColorOptions.previewselected.color.a, 185));
				}
				else
				{
					Prefab.TextField(ColorOptions.previewselected.color.a, "A: ", 30, 0, 255);
					Prefab.Slider(0f, 255f, (float)ColorOptions.previewselected.color.a, 185);
				}
				GUILayout.Space(100f);
				GUILayout.EndArea();
				GUILayout.Space(160f);
				GUILayout.FlexibleSpace();
				if (Prefab.Button("Снять выделение", 180f, 25f))
				{
					ColorOptions.selectedOption = null;
					ColorsTab.LastColorPreview1 = ColorOptions.preview.color;
				}
				GUILayout.Space(3f);
				if (Prefab.Button("Восстановить", 180f, 25f))
				{
					ColorUtilities.setColor(ColorOptions.previewselected.identity, ColorOptions.previewselected.origColor.ToColor());
					ColorOptions.previewselected.color = ColorOptions.previewselected.origColor;
					MenuComponent.SetGUIColors();
				}
				GUILayout.Space(3f);
				if (Prefab.Button("Применить", 180f, 25f))
				{
					ColorUtilities.setColor(ColorOptions.previewselected.identity, ColorOptions.previewselected.color.ToColor());
					MenuComponent.SetGUIColors();
					ColorsTab.LastColorPreview1 = ColorOptions.previewselected.color;
				}
				GUILayout.Space(30f);
			});
		}

		// Token: 0x04000067 RID: 103
		private static Vector2 ColorScroll;
	}
}
