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
		// Token: 0x0600008C RID: 140 RVA: 0x000038DC File Offset: 0x00001ADC
		public static void addColor(ColorVariable ColorVariable)
		{
			if (!ColorOptions.ColorDict2.ContainsKey(ColorVariable.identity))
			{
				ColorOptions.ColorDict2.Add(ColorVariable.identity, ColorVariable);
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000093D4 File Offset: 0x000075D4
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
				<Module>.smethod_7<string>(3947998958u),
				<Module>.smethod_4<string>(1748642746u),
				<Module>.smethod_7<string>(2269525171u),
				<Module>.smethod_7<string>(4282405643u),
				<Module>.smethod_4<string>(2111670294u),
				<Module>.smethod_6<string>(497562085u),
				<Module>.smethod_5<string>(626161154u),
				<Module>.smethod_8<string>(4241858074u),
				<Module>.smethod_6<string>(1996829255u),
				<Module>.smethod_8<string>(4039602982u),
				<Module>.smethod_5<string>(3672056150u),
				<Module>.smethod_5<string>(1711933347u),
				<Module>.smethod_5<string>(2000140684u)
			};
			for (int i = 0; i < ESPOptions.VisualOptions.Length; i++)
			{
				string arg = array2[i];
				ColorUtilities.addColor(new ColorVariable(string.Format(<Module>.smethod_4<string>(2325153741u), (ESPTarget)i), string.Format(<Module>.smethod_4<string>(1317030115u), arg), array[i], false));
				ColorUtilities.addColor(new ColorVariable(string.Format(<Module>.smethod_7<string>(3740914585u), (ESPTarget)i), string.Format(<Module>.smethod_8<string>(1817449540u), arg), Color.white, false));
				ColorUtilities.addColor(new ColorVariable(string.Format(<Module>.smethod_7<string>(783574029u), (ESPTarget)i), string.Format(<Module>.smethod_8<string>(237256424u), arg), Color.yellow, false));
			}
			ColorUtilities.addColor(new ColorVariable(<Module>.smethod_6<string>(2186218844u), <Module>.smethod_4<string>(853447811u), Color.green, false));
			ColorUtilities.addColor(new ColorVariable(<Module>.smethod_8<string>(1270709942u), <Module>.smethod_7<string>(2952900269u), Color.green, false));
			ColorUtilities.addColor(new ColorVariable(<Module>.smethod_6<string>(1939130903u), <Module>.smethod_4<string>(389865507u), Color.blue, false));
			ColorUtilities.addColor(new ColorVariable(<Module>.smethod_7<string>(1466949127u), <Module>.smethod_8<string>(3438744524u), new Color32(byte.MaxValue, 165, 0, byte.MaxValue), false));
			ColorUtilities.addColor(new ColorVariable(<Module>.smethod_5<string>(2807434139u), <Module>.smethod_4<string>(1883743241u), Color.red, false));
			ColorUtilities.addColor(new ColorVariable(<Module>.smethod_4<string>(58807632u), <Module>.smethod_6<string>(2157369668u), new Color32(0, byte.MaxValue, 0, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable(<Module>.smethod_8<string>(1555168770u), <Module>.smethod_8<string>(1109556718u), Color.black, false));
			ColorUtilities.addColor(new ColorVariable(<Module>.smethod_8<string>(2000780822u), <Module>.smethod_5<string>(4056506439u), new Color32(3, 3, 3, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable(<Module>.smethod_8<string>(1008429172u), <Module>.smethod_8<string>(1747961957u), new Color32(75, 75, 75, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable(<Module>.smethod_5<string>(3470363166u), <Module>.smethod_7<string>(3383311747u), new Color32(55, 55, 55, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable(<Module>.smethod_5<string>(2134776513u), <Module>.smethod_6<string>(2947962081u), new Color32(30, 30, 30, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable(<Module>.smethod_4<string>(1864147503u), <Module>.smethod_4<string>(4152665416u), new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable(<Module>.smethod_6<string>(732540374u), <Module>.smethod_4<string>(39211894u), new Color32(244, 244, 244, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable(<Module>.smethod_4<string>(3556558683u), <Module>.smethod_4<string>(2003893735u), new Color32(160, 160, 160, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable(<Module>.smethod_7<string>(1658958713u), <Module>.smethod_5<string>(2154233711u), new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable(<Module>.smethod_8<string>(360562028u), <Module>.smethod_6<string>(2783236787u), new Color32(210, 210, 210, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable(<Module>.smethod_8<string>(2478032837u), <Module>.smethod_7<string>(3799161497u), new Color32(160, 160, 160, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable(<Module>.smethod_5<string>(232503785u), <Module>.smethod_7<string>(975583615u), new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable(<Module>.smethod_5<string>(1020340042u), <Module>.smethod_5<string>(3355184535u), new Color32(210, 210, 210, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable(<Module>.smethod_5<string>(2106112235u), <Module>.smethod_4<string>(3819031475u), new Color32(210, 210, 210, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable(<Module>.smethod_6<string>(427754081u), <Module>.smethod_8<string>(2964746757u), new Color32(71, 70, 71, byte.MaxValue), true));
			ColorUtilities.addColor(new ColorVariable(<Module>.smethod_5<string>(3854813455u), <Module>.smethod_5<string>(4104627915u), new Color32(130, 130, 130, byte.MaxValue), true));
			MenuComponent.UpdateColors();
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00009AB4 File Offset: 0x00007CB4
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

		// Token: 0x0600008F RID: 143 RVA: 0x00009B2C File Offset: 0x00007D2C
		public static ColorVariable getColor(string identifier)
		{
			ColorVariable result;
			if (ColorOptions.ColorDict2.TryGetValue(identifier, out result))
			{
				return result;
			}
			return ColorOptions.errorColor;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00009B50 File Offset: 0x00007D50
		public static string getHex(string identifier)
		{
			ColorVariable color;
			if (ColorOptions.ColorDict2.TryGetValue(identifier, out color))
			{
				return ColorUtilities.ColorToHex(color);
			}
			return ColorUtilities.ColorToHex(ColorOptions.errorColor);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00009B88 File Offset: 0x00007D88
		public static void setColor(string identifier, Color32 color)
		{
			ColorVariable colorVariable;
			if (ColorOptions.ColorDict2.TryGetValue(identifier, out colorVariable))
			{
				colorVariable.color = color.ToSerializableColor();
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00009BB0 File Offset: 0x00007DB0
		public static string ColorToHex(Color32 color)
		{
			return color.r.ToString(<Module>.smethod_8<string>(1485681187u)) + color.g.ToString(<Module>.smethod_4<string>(340876162u)) + color.b.ToString(<Module>.smethod_7<string>(655738658u));
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00003901 File Offset: 0x00001B01
		public static ColorVariable[] getArray()
		{
			return ColorOptions.ColorDict2.Values.ToList<ColorVariable>().ToArray();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00009C04 File Offset: 0x00007E04
		public static Color32 HexToColor(string hex)
		{
			byte r = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
			byte g = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
			byte b = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
			return new Color32(r, g, b, byte.MaxValue);
		}
	}
}
