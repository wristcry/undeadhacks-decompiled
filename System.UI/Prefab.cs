using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000088 RID: 136
	public static class Prefab
	{
		// Token: 0x06000206 RID: 518 RVA: 0x00013840 File Offset: 0x00011A40
		static Prefab()
		{
			Prefab._None = new GUIStyle();
			Prefab._None.normal.background = null;
			Prefab._MenuTabStyle = new GUIStyle
			{
				font = MenuComponent._TabFont,
				fontSize = 29
			};
			Prefab._HeaderStyle = new GUIStyle
			{
				font = MenuComponent._TabFont,
				fontSize = 15,
				alignment = TextAnchor.MiddleCenter
			};
			Prefab._TextStyle = new GUIStyle
			{
				font = MenuComponent._TextFont,
				fontSize = 16
			};
			Prefab._sliderStyle = new GUIStyle();
			Prefab._sliderThumbStyle = new GUIStyle(GUI.skin.horizontalSliderThumb)
			{
				fixedWidth = 7f
			};
			Prefab._sliderVThumbStyle = new GUIStyle(GUI.skin.verticalSliderThumb)
			{
				fixedHeight = 7f
			};
			Prefab._listStyle = new GUIStyle
			{
				alignment = TextAnchor.MiddleCenter,
				font = MenuComponent._TextFont,
				fontSize = 15
			};
			RectOffset padding = Prefab._listStyle.padding;
			RectOffset padding2 = Prefab._listStyle.padding;
			RectOffset padding3 = Prefab._listStyle.padding;
			Prefab._listStyle.padding.bottom = 4;
			padding3.top = 4;
			padding2.right = 4;
			padding.left = 4;
			Prefab._ButtonStyle = new GUIStyle
			{
				alignment = TextAnchor.MiddleLeft,
				font = MenuComponent._TextFont,
				fontSize = 15
			};
			RectOffset padding4 = Prefab._ButtonStyle.padding;
			RectOffset padding5 = Prefab._ButtonStyle.padding;
			RectOffset padding6 = Prefab._ButtonStyle.padding;
			Prefab._ButtonStyle.padding.bottom = 4;
			padding6.top = 4;
			padding5.right = 4;
			padding4.left = 4;
			MenuUtilities.FixGUIStyleColor(Prefab._sliderStyle);
			MenuUtilities.FixGUIStyleColor(Prefab._MenuTabStyle);
			MenuUtilities.FixGUIStyleColor(Prefab._TextStyle);
			Prefab.UpdateColors();
			Fonts.Apply();
		}

		// Token: 0x06000207 RID: 519 RVA: 0x00013A14 File Offset: 0x00011C14
		public static void UpdateColors()
		{
			Prefab._MenuTabStyle.normal.textColor = ColorUtilities.getColor(<Module>.smethod_6<string>(4232730376u));
			Prefab._MenuTabStyle.onNormal.textColor = ColorUtilities.getColor(<Module>.smethod_6<string>(1469619316u));
			Prefab._MenuTabStyle.hover.textColor = ColorUtilities.getColor(<Module>.smethod_6<string>(1169017904u));
			Prefab._MenuTabStyle.onHover.textColor = ColorUtilities.getColor(<Module>.smethod_7<string>(1658958713u));
			Prefab._MenuTabStyle.active.textColor = ColorUtilities.getColor(<Module>.smethod_8<string>(4209917272u));
			Prefab._MenuTabStyle.onActive.textColor = ColorUtilities.getColor(<Module>.smethod_6<string>(1469619316u));
			Prefab._MenuTabStyle.focused.textColor = ColorUtilities.getColor(<Module>.smethod_8<string>(1495143092u));
			Prefab._MenuTabStyle.onFocused.textColor = ColorUtilities.getColor(<Module>.smethod_5<string>(3153491551u));
			Prefab._TextStyle.normal.textColor = ColorUtilities.getColor(<Module>.smethod_7<string>(3999805508u));
			Prefab._TextStyle.onNormal.textColor = ColorUtilities.getColor(<Module>.smethod_6<string>(3767403670u));
			Prefab._TextStyle.hover.textColor = ColorUtilities.getColor(<Module>.smethod_6<string>(1057806081u));
			Prefab._TextStyle.onHover.textColor = ColorUtilities.getColor(<Module>.smethod_5<string>(232503785u));
			Prefab._TextStyle.active.textColor = ColorUtilities.getColor(<Module>.smethod_6<string>(3767403670u));
			Prefab._TextStyle.onActive.textColor = ColorUtilities.getColor(<Module>.smethod_6<string>(3767403670u));
			Prefab._TextStyle.focused.textColor = ColorUtilities.getColor(<Module>.smethod_6<string>(1988459493u));
			Prefab._TextStyle.onFocused.textColor = ColorUtilities.getColor(<Module>.smethod_7<string>(3999805508u));
			Prefab._HeaderStyle.normal.textColor = ColorUtilities.getColor(<Module>.smethod_7<string>(3278672529u));
			Prefab._listStyle.normal.textColor = ColorUtilities.getColor(<Module>.smethod_5<string>(232503785u));
			Prefab._listStyle.onNormal.textColor = ColorUtilities.getColor(<Module>.smethod_4<string>(995770109u));
			Prefab._listStyle.hover.textColor = ColorUtilities.getColor(<Module>.smethod_5<string>(3681784749u));
			Prefab._ButtonStyle.normal.textColor = ColorUtilities.getColor(<Module>.smethod_7<string>(1243108963u));
			Prefab._ButtonStyle.onNormal.textColor = ColorUtilities.getColor(<Module>.smethod_8<string>(259434482u));
			Prefab._ButtonStyle.hover.textColor = ColorUtilities.getColor(<Module>.smethod_4<string>(694105841u));
			Prefab._ButtonStyle.onHover.textColor = ColorUtilities.getColor(<Module>.smethod_6<string>(3524500610u));
			Texture2D texture2D = new Texture2D(1, 1);
			texture2D.SetPixel(0, 0, ColorUtilities.getColor(<Module>.smethod_8<string>(3167001849u)));
			texture2D.Apply();
			Prefab._ButtonStyle.hover.background = texture2D;
			Texture2D texture2D2 = new Texture2D(1, 1);
			texture2D2.SetPixel(0, 0, ColorUtilities.getColor(<Module>.smethod_6<string>(510116728u)));
			texture2D2.Apply();
			Prefab._ButtonStyle.normal.background = texture2D2;
			Texture2D texture2D3 = new Texture2D(1, 1);
			texture2D3.SetPixel(0, 0, ColorUtilities.getColor(<Module>.smethod_8<string>(259434482u)));
			texture2D3.Apply();
			Prefab._ButtonStyle.active.background = texture2D3;
			Prefab._listStyle.hover.background = texture2D3;
			Prefab._listStyle.onHover.background = texture2D3;
			Prefab._listStyle.normal.background = texture2D2;
			Prefab._listStyle.onNormal.background = texture2D2;
			Prefab._ToggleBoxBG = ColorUtilities.getColor(<Module>.smethod_8<string>(3410358809u));
		}

		// Token: 0x06000208 RID: 520 RVA: 0x00013E70 File Offset: 0x00012070
		public static bool MenuTab(string text, ref bool state, int fontsize = 29)
		{
			bool result = false;
			int fontSize = Prefab._MenuTabStyle.fontSize;
			Prefab._MenuTabStyle.fontSize = fontsize;
			bool flag = GUILayout.Toggle(state, text.ToUpper(), Prefab._MenuTabStyle, Array.Empty<GUILayoutOption>());
			if (state != flag)
			{
				state = !state;
				result = true;
			}
			Prefab._MenuTabStyle.fontSize = fontSize;
			return result;
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00013EC8 File Offset: 0x000120C8
		public static bool IMenuTab(int i, ref bool state)
		{
			GUI.color = (state ? Prefab._MenuTabStyle.active.textColor : Prefab._MenuTabStyle.normal.textColor);
			if (!GUILayout.Button(MenuComponent.Icons[i], Prefab._None, Array.Empty<GUILayoutOption>()))
			{
				GUI.color = Color.white;
				return false;
			}
			state = !state;
			GUI.color = Color.white;
			return true;
		}

		// Token: 0x0600020A RID: 522 RVA: 0x00013F34 File Offset: 0x00012134
		public static bool MenuTabAbsolute(Vector2 pos, string text, ref bool state, int fontsize = 29)
		{
			bool result = false;
			bool flag = state;
			int fontSize = Prefab._MenuTabStyle.fontSize;
			Prefab._MenuTabStyle.fontSize = fontsize;
			Vector2 size = Prefab._MenuTabStyle.CalcSize(new GUIContent(text));
			bool flag2 = GUI.Toggle(new Rect(pos, size), flag, text.ToUpper(), Prefab._MenuTabStyle);
			if (flag != flag2)
			{
				state = !state;
				result = true;
			}
			Prefab._MenuTabStyle.fontSize = fontSize;
			return result;
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00013FA4 File Offset: 0x000121A4
		public static void MenuArea(Rect area, string header, Action code)
		{
			Rect rect = new Rect(area.x, area.y + 5f, area.width, area.height - 5f);
			Rect rect2 = MenuUtilities.Inline(rect, 1f);
			Drawing.DrawRect(rect, MenuComponent._OutlineBorderBlack);
			Drawing.DrawRect(rect2, MenuComponent._OutlineBorderLightGray);
			Drawing.DrawRect(MenuUtilities.Inline(rect2, 1f), MenuComponent._FillLightBlack);
			Vector2 vector = Prefab._HeaderStyle.CalcSize(new GUIContent(header));
			Drawing.DrawRect(new Rect(area.x + 19f, area.y, vector.x + 2f, vector.y), MenuComponent._FillLightBlack);
			GUI.Label(new Rect(area.x + 20f, area.y - 3f, vector.x, vector.y), header, Prefab._HeaderStyle);
			GUILayout.BeginArea(area);
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			GUILayout.Space(15f);
			GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
			GUILayout.Space(20f);
			try
			{
				code();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			GUILayout.EndVertical();
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00014100 File Offset: 0x00012300
		public static void SectionTabButton(string text, Action code, float space = 0f, int fontsize = 20)
		{
			bool flag = false;
			GUILayout.Space(space);
			if (Prefab.MenuTab(text, ref flag, fontsize))
			{
				SectionTab.CurrentSectionTab = new SectionTab(text, code);
			}
			GUILayout.Space(space);
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00014134 File Offset: 0x00012334
		public static bool Toggle(string text, ref bool state)
		{
			bool result = false;
			int num = 15;
			int fontSize = Prefab._TextStyle.fontSize;
			Prefab._TextStyle.fontSize = 17;
			float x = Prefab._TextStyle.CalcSize(new GUIContent(text)).x;
			GUILayout.Space(3f);
			Rect rect = GUILayoutUtility.GetRect(x, 15f);
			Rect rect2 = new Rect(rect.x + 1f, rect.y + 1f, 13f, 13f);
			Rect position = MenuUtilities.Inline(rect2, 1f);
			Drawing.DrawRect(rect2, MenuComponent._OutlineBorderBlack);
			Drawing.DrawRect(position, Prefab._ToggleBoxBG);
			if (GUI.Button(rect, GUIContent.none, Prefab._TextStyle))
			{
				state = !state;
				result = true;
			}
			if (Event.current.type == EventType.Repaint)
			{
				bool isHover;
				bool isActive = (isHover = rect.Contains(Event.current.mousePosition)) && Input.GetMouseButton(0);
				Prefab._TextStyle.Draw(new Rect(rect.x + 20f, rect.y, x, (float)num), text, isHover, isActive, false, false);
			}
			Prefab._TextStyle.fontSize = fontSize;
			if (state)
			{
				Drawing.DrawRect(position, MenuComponent._Accent2);
			}
			return result;
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0001427C File Offset: 0x0001247C
		public static void ToggleLast(ref bool state)
		{
			Rect lastRect = GUILayoutUtility.GetLastRect();
			lastRect = new Rect(lastRect.x + 161f, lastRect.y - 14f, 13f, 13f);
			Rect position = MenuUtilities.Inline(lastRect, 1f);
			Drawing.DrawRect(lastRect, MenuComponent._OutlineBorderBlack);
			Drawing.DrawRect(position, Prefab._ToggleBoxBG);
			if (GUI.Button(lastRect, GUIContent.none, Prefab._TextStyle))
			{
				state = !state;
			}
			if (state)
			{
				Drawing.DrawRect(position, MenuComponent._Accent2);
			}
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00014314 File Offset: 0x00012514
		public static float Slider(float left, float right, float value, int size)
		{
			GUIStyle sliderThumbStyle = Prefab._sliderThumbStyle;
			GUIStyle sliderStyle = Prefab._sliderStyle;
			float num = (sliderThumbStyle.fixedWidth != 0f) ? sliderThumbStyle.fixedWidth : ((float)sliderThumbStyle.padding.horizontal);
			value = GUILayout.HorizontalSlider(value, left, right, GUI.skin.horizontalSlider, GUI.skin.horizontalSliderThumb, new GUILayoutOption[]
			{
				GUILayout.Width((float)size)
			});
			Rect lastRect = GUILayoutUtility.GetLastRect();
			float num2 = (lastRect.width - (float)sliderStyle.padding.horizontal - num) / (right - left);
			Rect rect = new Rect((value - left) * num2 + lastRect.x + (float)sliderStyle.padding.left, lastRect.y + (float)sliderStyle.padding.top, num, lastRect.height - (float)sliderStyle.padding.vertical);
			Drawing.DrawRect(lastRect, MenuComponent._FillLightBlack);
			Drawing.DrawRect(new Rect(lastRect.x, lastRect.y + lastRect.height / 2f - 2f, lastRect.width, 4f), Prefab._ToggleBoxBG);
			Drawing.DrawRect(rect, MenuComponent._OutlineBorderBlack);
			Drawing.DrawRect(MenuUtilities.Inline(rect, 1f), Prefab._MenuTabStyle.onNormal.textColor);
			return value;
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0001446C File Offset: 0x0001266C
		public static void VerticalSlider(Rect pos, float top, float bottom, ref float value)
		{
			GUIStyle sliderVThumbStyle = Prefab._sliderVThumbStyle;
			GUIStyle sliderStyle = Prefab._sliderStyle;
			float num = (sliderVThumbStyle.fixedHeight != 0f) ? sliderVThumbStyle.fixedHeight : ((float)sliderVThumbStyle.padding.vertical);
			value = GUI.VerticalSlider(pos, value, top, bottom, Prefab._sliderStyle, GUI.skin.verticalSliderThumb);
			Rect position = pos;
			float num2 = (position.height - (float)sliderStyle.padding.vertical - num) / (bottom - top);
			Rect rect = new Rect(position.x + (float)sliderStyle.padding.left, (value - top) * num2 + position.y + (float)sliderStyle.padding.top, position.width - (float)sliderStyle.padding.horizontal, num);
			Drawing.DrawRect(position, MenuComponent._FillLightBlack);
			Drawing.DrawRect(new Rect(position.x + position.width / 2f - 2f, position.y, 4f, position.height), Prefab._ToggleBoxBG);
			Drawing.DrawRect(rect, MenuComponent._OutlineBorderBlack);
			Drawing.DrawRect(MenuUtilities.Inline(rect, 1f), Prefab._MenuTabStyle.onNormal.textColor);
		}

		// Token: 0x06000211 RID: 529 RVA: 0x000145AC File Offset: 0x000127AC
		public static void ScrollView(Rect area, string title, ref Vector2 scrollpos, Action code, int padding = 20)
		{
			Drawing.DrawRect(area, MenuComponent._OutlineBorderBlack);
			Drawing.DrawRect(MenuUtilities.Inline(area, 1f), MenuComponent._OutlineBorderLightGray);
			Rect rect = MenuUtilities.Inline(area, 2f);
			Drawing.DrawRect(rect, MenuComponent._FillLightBlack);
			Color textColor = Prefab._MenuTabStyle.normal.textColor;
			int fontSize = Prefab._MenuTabStyle.fontSize;
			Prefab._MenuTabStyle.normal.textColor = Prefab._MenuTabStyle.onNormal.textColor;
			Prefab._MenuTabStyle.fontSize = 15;
			Drawing.DrawRect(new Rect(rect.x, rect.y, rect.width, Prefab._MenuTabStyle.CalcSize(new GUIContent(title)).y + 2f), MenuComponent._OutlineBorderLightGray);
			GUILayout.BeginArea(rect);
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			GUILayout.FlexibleSpace();
			GUILayout.Label(title, Prefab._MenuTabStyle, Array.Empty<GUILayoutOption>());
			Prefab._MenuTabStyle.normal.textColor = textColor;
			Prefab._MenuTabStyle.fontSize = fontSize;
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.Space(2f);
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			scrollpos = GUILayout.BeginScrollView(scrollpos, false, true, Array.Empty<GUILayoutOption>());
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			GUILayout.Space((float)padding);
			GUILayout.BeginVertical(new GUILayoutOption[]
			{
				GUILayout.MinHeight(rect.height)
			});
			try
			{
				code();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			GUILayout.EndVertical();
			Rect lastRect = GUILayoutUtility.GetLastRect();
			GUILayout.EndHorizontal();
			GUILayout.EndScrollView();
			Rect lastRect2 = GUILayoutUtility.GetLastRect();
			GUILayout.Space(1f);
			GUILayout.EndHorizontal();
			GUILayout.Space(1f);
			Drawing.DrawRect(new Rect(lastRect2.x + lastRect2.width - 16f, lastRect2.y, 16f, lastRect2.height), MenuComponent._FillLightBlack);
			if (lastRect.height - lastRect2.height > 0f)
			{
				Prefab.VerticalSlider(new Rect(lastRect2.x + 4f, lastRect2.y + 8f, 12f, lastRect2.height - 14f), 0f, lastRect.height - lastRect2.height, ref scrollpos.y);
			}
			GUILayout.EndArea();
		}

		// Token: 0x06000212 RID: 530 RVA: 0x00014828 File Offset: 0x00012A28
		public static int Arrows(float width, int listEntry, string content, int max)
		{
			Rect rect = GUILayoutUtility.GetRect(width, 25f, new GUILayoutOption[]
			{
				GUILayout.Height(25f),
				GUILayout.Width(width)
			});
			if (Prefab.Button(<Module>.smethod_7<string>(735500719u), new Rect(rect.x, rect.y, 25f, 25f)))
			{
				listEntry--;
			}
			GUI.Label(MenuUtilities.Inline(new Rect(rect.x + 25f, rect.y, rect.width - 50f, 25f), 1f), content, Prefab._listStyle);
			if (Prefab.Button(<Module>.smethod_6<string>(3541240134u), new Rect(rect.x + rect.width - 25f, rect.y, 25f, 25f)))
			{
				listEntry++;
			}
			if (listEntry >= 0)
			{
				if (listEntry > max)
				{
					listEntry = 0;
				}
			}
			else
			{
				listEntry = max;
			}
			return listEntry;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00014924 File Offset: 0x00012B24
		public static bool Button(string text, float width, float height = 25f)
		{
			Rect rect = GUILayoutUtility.GetRect(width, height, new GUILayoutOption[]
			{
				GUILayout.Height(height),
				GUILayout.Width(width)
			});
			Drawing.DrawRect(rect, MenuComponent._OutlineBorderBlack);
			return GUI.Button(MenuUtilities.Inline(rect, 1f), text, Prefab._ButtonStyle);
		}

		// Token: 0x06000214 RID: 532 RVA: 0x0000473D File Offset: 0x0000293D
		public static bool Button(string text, Rect rect)
		{
			Drawing.DrawRect(rect, MenuComponent._OutlineBorderBlack);
			return GUI.Button(MenuUtilities.Inline(rect, 1f), text, Prefab._ButtonStyle);
		}

		// Token: 0x06000215 RID: 533 RVA: 0x00014978 File Offset: 0x00012B78
		public static bool ColorButton(float width, ColorVariable color, float height = 25f)
		{
			Rect rect = GUILayoutUtility.GetRect(width, height, new GUILayoutOption[]
			{
				GUILayout.Height(height),
				GUILayout.Width(width)
			});
			Drawing.DrawRect(rect, MenuComponent._OutlineBorderBlack);
			Rect rect2 = new Rect(rect.x + 4f, rect.y + 4f, rect.height - 8f, rect.height - 8f);
			bool result = GUI.Button(MenuUtilities.Inline(rect, 1f), <Module>.smethod_6<string>(4052155540u) + color.name, Prefab._ButtonStyle);
			Drawing.DrawRect(rect2, MenuComponent._OutlineBorderBlack);
			Drawing.DrawRect(MenuUtilities.Inline(rect2, 1f), MenuComponent._OutlineBorderLightGray);
			Drawing.DrawRect(MenuUtilities.Inline(rect2, 2f), color.color);
			return result;
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00014A60 File Offset: 0x00012C60
		public static string TextField(string text, string label, float width)
		{
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			GUILayout.Label(label, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
			int fontSize = Prefab._TextStyle.fontSize;
			Prefab._TextStyle.fontSize = 13;
			float y = Prefab._TextStyle.CalcSize(new GUIContent(<Module>.smethod_5<string>(4153270910u))).y;
			Rect rect = GUILayoutUtility.GetRect(width, y);
			Drawing.DrawRect(new Rect(rect.x, rect.y + 2f, rect.width, rect.height + 1f), MenuComponent._OutlineBorderLightGray);
			Drawing.DrawRect(new Rect(rect.x, rect.y + 2f, rect.width, rect.height), MenuComponent._FillLightBlack);
			text = GUI.TextField(new Rect(rect.x + 4f, rect.y + 2f, rect.width, rect.height), text, Prefab._TextStyle);
			GUILayout.FlexibleSpace();
			Prefab._TextStyle.fontSize = fontSize;
			GUILayout.EndHorizontal();
			return text;
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00014B88 File Offset: 0x00012D88
		public static string TextField(string text, string label, float width, float spacer)
		{
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			GUILayout.Label(label, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
			int fontSize = Prefab._TextStyle.fontSize;
			Prefab._TextStyle.fontSize = 13;
			Rect lastRect = GUILayoutUtility.GetLastRect();
			lastRect.height = Prefab._TextStyle.CalcSize(new GUIContent(<Module>.smethod_4<string>(934913224u))).y;
			lastRect.x += spacer;
			lastRect.width = width;
			Drawing.DrawRect(new Rect(lastRect.x, lastRect.y + 2f, lastRect.width, lastRect.height + 1f), MenuComponent._OutlineBorderLightGray);
			Drawing.DrawRect(new Rect(lastRect.x, lastRect.y + 2f, lastRect.width, lastRect.height), MenuComponent._FillLightBlack);
			text = GUI.TextField(new Rect(lastRect.x + 4f, lastRect.y + 2f, lastRect.width, lastRect.height), text, Prefab._TextStyle);
			GUILayout.FlexibleSpace();
			Prefab._TextStyle.fontSize = fontSize;
			GUILayout.EndHorizontal();
			return text;
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00014CCC File Offset: 0x00012ECC
		public static int TextField(int text, string label, int width, int min = 0, int max = 255)
		{
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			GUILayout.Label(label, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
			int fontSize = Prefab._TextStyle.fontSize;
			Prefab._TextStyle.fontSize = 13;
			float y = Prefab._TextStyle.CalcSize(new GUIContent(<Module>.smethod_6<string>(304877597u))).y;
			Rect rect = GUILayoutUtility.GetRect((float)width, y);
			Drawing.DrawRect(new Rect(rect.x, rect.y + 2f, rect.width, rect.height + 1f), MenuComponent._OutlineBorderLightGray);
			Drawing.DrawRect(new Rect(rect.x, rect.y + 2f, rect.width, rect.height), MenuComponent._FillLightBlack);
			try
			{
				int num = int.Parse(Prefab.digitsOnly.Replace(GUI.TextField(new Rect(rect.x + 4f, rect.y + 2f, rect.width, rect.height), text.ToString(), Prefab._TextStyle), string.Empty));
				if (num >= min && num <= max)
				{
					text = num;
				}
			}
			catch
			{
			}
			GUILayout.FlexibleSpace();
			Prefab._TextStyle.fontSize = fontSize;
			GUILayout.EndHorizontal();
			return text;
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00014E30 File Offset: 0x00013030
		public static void ScrollView(Rect area, string title, ref SerializableVector2 scrollpos, Action code, int padding = 20)
		{
			Drawing.DrawRect(area, MenuComponent._OutlineBorderBlack);
			Drawing.DrawRect(MenuUtilities.Inline(area, 1f), MenuComponent._OutlineBorderLightGray);
			Rect rect = MenuUtilities.Inline(area, 2f);
			Drawing.DrawRect(rect, MenuComponent._FillLightBlack);
			Color textColor = Prefab._MenuTabStyle.normal.textColor;
			int fontSize = Prefab._MenuTabStyle.fontSize;
			Prefab._MenuTabStyle.normal.textColor = Prefab._MenuTabStyle.onNormal.textColor;
			Prefab._MenuTabStyle.fontSize = 15;
			Drawing.DrawRect(new Rect(rect.x, rect.y, rect.width, Prefab._MenuTabStyle.CalcSize(new GUIContent(title)).y + 2f), MenuComponent._OutlineBorderLightGray);
			GUILayout.BeginArea(rect);
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			GUILayout.FlexibleSpace();
			GUILayout.Label(title, Prefab._MenuTabStyle, Array.Empty<GUILayoutOption>());
			Prefab._MenuTabStyle.normal.textColor = textColor;
			Prefab._MenuTabStyle.fontSize = fontSize;
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.Space(2f);
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			scrollpos = GUILayout.BeginScrollView(scrollpos.ToVector2(), false, true, Array.Empty<GUILayoutOption>());
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			GUILayout.Space((float)padding);
			GUILayout.BeginVertical(new GUILayoutOption[]
			{
				GUILayout.MinHeight(rect.height)
			});
			try
			{
				code();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			GUILayout.EndVertical();
			Rect lastRect = GUILayoutUtility.GetLastRect();
			GUILayout.EndHorizontal();
			GUILayout.EndScrollView();
			Rect lastRect2 = GUILayoutUtility.GetLastRect();
			GUILayout.Space(1f);
			GUILayout.EndHorizontal();
			GUILayout.Space(1f);
			Drawing.DrawRect(new Rect(lastRect2.x + lastRect2.width - 16f, lastRect2.y, 16f, lastRect2.height), MenuComponent._FillLightBlack);
			if (lastRect.height - lastRect2.height > 0f)
			{
				Prefab.VerticalSlider(new Rect(lastRect2.x + 4f, lastRect2.y + 8f, 12f, lastRect2.height - 14f), 0f, lastRect.height - lastRect2.height, ref scrollpos.y);
			}
			GUILayout.EndArea();
		}

		// Token: 0x040001DD RID: 477
		public static GUIStyle _None;

		// Token: 0x040001DE RID: 478
		public static GUIStyle _MenuTabStyle;

		// Token: 0x040001DF RID: 479
		public static GUIStyle _HeaderStyle;

		// Token: 0x040001E0 RID: 480
		public static GUIStyle _TextStyle;

		// Token: 0x040001E1 RID: 481
		public static GUIStyle _sliderStyle;

		// Token: 0x040001E2 RID: 482
		public static GUIStyle _sliderThumbStyle;

		// Token: 0x040001E3 RID: 483
		public static GUIStyle _sliderVThumbStyle;

		// Token: 0x040001E4 RID: 484
		public static GUIStyle _listStyle;

		// Token: 0x040001E5 RID: 485
		public static GUIStyle _ButtonStyle;

		// Token: 0x040001E6 RID: 486
		public static Color32 _ToggleBoxBG;

		// Token: 0x040001E7 RID: 487
		public static Regex digitsOnly = new Regex(<Module>.smethod_8<string>(155955205u));
	}
}
