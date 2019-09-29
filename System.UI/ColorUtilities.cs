using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000023 RID: 35
	public static class ColorUtilities
	{
		// Token: 0x0600008C RID: 140 RVA: 0x000038D7 File Offset: 0x00001AD7
		public static void addColor(ColorVariable ColorVariable)
		{
			if (!ColorOptions.ColorDict2.ContainsKey(ColorVariable.identity))
			{
				ColorOptions.ColorDict2.Add(ColorVariable.identity, ColorVariable);
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00009278 File Offset: 0x00007478
		public static void Init()
		{
			Color[] array = new Color[]
			{
				Color.red,
				new Color(1f, 0.5f, 0f),
				new Color(0.3f, 0.5f, 1f),
				new Color(1f, 0.5f, 0f),
				Color.white,
				Color.white,
				Color.yellow,
				Color.green,
				Color.yellow,
				new Color(1f, 0.5f, 0f),
				Color.green,
				new Color(1f, 0.5f, 0f),
				new Color(0.5f, 0.9f, 0.3f)
			};
			string[] array2 = new string[]
			{
				"Игроки",
				"Зомби",
				"Предметы",
				"Турели",
				"Кровати",
				"Клейм Флаги",
				"Транспорт",
				"Ящики",
				"Генераторы",
				"Животные",
				"Растения",
				"Ловушки",
				"Аирдроп"
			};
			for (int i = 0; i < ESPOptions.VisualOptions.Length; i++)
			{
				string arg = array2[i];
				ColorUtilities.addColor(new ColorVariable(string.Format("_{0}", (ESPTarget)i), string.Format("ESP - {0}", arg), array[i], false));
				ColorUtilities.addColor(new ColorVariable(string.Format("_{0}_Info", (ESPTarget)i), string.Format("ESP - {0} (Доп инфа)", arg), Color.white, false));
				ColorUtilities.addColor(new ColorVariable(string.Format("_{0}_Glow", (ESPTarget)i), string.Format("ESP - {0} (Обводка)", arg), Color.yellow, false));
			}
			ColorUtilities.addColor(new ColorVariable("_ESPFriendly", "ESP - Игроки (Друзья)", Color.green, false));
			ColorUtilities.addColor(new ColorVariable("_ChamsFriendVisible", "Chams - Видимый друг", Color.green, false));
			ColorUtilities.addColor(new ColorVariable("_ChamsFriendInvisible", "Chams - Невидимый друг", Color.blue, false));
			ColorUtilities.addColor(new ColorVariable("_ChamsEnemyVisible", "Chams - Видимый противник", new Color32(byte.MaxValue, 165, 0, byte.MaxValue), false));
			ColorUtilities.addColor(new ColorVariable("_ChamsEnemyInvisible", "Chams - Невидимый противник", Color.red, false));
			ColorUtilities.addColor(new ColorVariable("_WeaponInfoColor", "Оружия - Информация", new Color32(0, byte.MaxValue, 0, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable("_OutlineText", "Текст - граница", Color.black, false));
			ColorUtilities.addColor(new ColorVariable("_OutlineBorderBlack", "Меню - граница 1", new Color32(3, 3, 3, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable("_OutlineBorderLightGray", "Меню - граница 2", new Color32(75, 75, 75, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable("_OutlineBorderDarkGray", "Меню - граница 3", new Color32(55, 55, 55, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable("_FillLightBlack", "Меню - заполнение", new Color32(30, 30, 30, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable("_Accent1", "Меню - цвет 1", new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable("_Accent2", "Меню - цвет 2", new Color32(244, 244, 244, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable("_MenuTabOff", "Меню Окно - Выкл", new Color32(160, 160, 160, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable("_MenuTabOn", "Меню Окно - Вкл", new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable("_MenuTabHover", "Меню Окно - Наведено", new Color32(210, 210, 210, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable("_TextStyleOff", "Меню Надписи - Выкл", new Color32(160, 160, 160, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable("_TextStyleOn", "Меню Надписи - Вкл", new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable("_TextStyleHover", "Меню Надписи - Наведено", new Color32(210, 210, 210, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable("_HeaderStyle", "Меню Зона - Заголовок", new Color32(210, 210, 210, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable("_ToggleBoxBG", "Меню Галочка - Фон", new Color32(71, 70, 71, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable("_ButtonBG", "Меню Кнопка - Фон", new Color32(130, 130, 130, byte.MaxValue), true));
			MenuComponent.UpdateColors();
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000981C File Offset: 0x00007A1C
		public static void LoadDict()
		{
			foreach (KeyValuePair<string, ColorVariable> keyValuePair in ColorOptions.ColorDict)
			{
				ColorVariable colorVariable;
				if (ColorOptions.ColorDict2.TryGetValue(keyValuePair.Key, out colorVariable))
				{
					ColorVariable value = keyValuePair.Value;
					colorVariable.color = value.color;
				}
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00009894 File Offset: 0x00007A94
		public static ColorVariable getColor(string identifier)
		{
			ColorVariable result;
			if (ColorOptions.ColorDict2.TryGetValue(identifier, out result))
			{
				return result;
			}
			return ColorOptions.errorColor;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000098B8 File Offset: 0x00007AB8
		public static string getHex(string identifier)
		{
			ColorVariable color;
			if (ColorOptions.ColorDict2.TryGetValue(identifier, out color))
			{
				return ColorUtilities.ColorToHex(color);
			}
			return ColorUtilities.ColorToHex(ColorOptions.errorColor);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000098F0 File Offset: 0x00007AF0
		public static void setColor(string identifier, Color32 color)
		{
			ColorVariable colorVariable;
			if (ColorOptions.ColorDict2.TryGetValue(identifier, out colorVariable))
			{
				colorVariable.color = color.ToSerializableColor();
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00009918 File Offset: 0x00007B18
		public static string ColorToHex(Color32 color)
		{
			return color.r.ToString(<Module>.smethod_8<string>(1485681187u)) + color.g.ToString(<Module>.smethod_4<string>(340876162u)) + color.b.ToString(<Module>.smethod_7<string>(655738658u));
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000038FC File Offset: 0x00001AFC
		public static ColorVariable[] getArray()
		{
			return ColorOptions.ColorDict2.Values.ToList<ColorVariable>().ToArray();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000996C File Offset: 0x00007B6C
		public static Color32 HexToColor(string hex)
		{
			byte r = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
			byte g = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
			byte b = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
			return new Color32(r, g, b, byte.MaxValue);
		}
	}
}
