using System;
using Newtonsoft.Json;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000024 RID: 36
	public class ColorVariable
	{
		// Token: 0x06000095 RID: 149 RVA: 0x00003917 File Offset: 0x00001B17
		[JsonConstructor]
		public ColorVariable(string identity, string name, Color32 color, Color32 origColor, bool disableAlpha)
		{
			this.identity = identity;
			this.name = name;
			this.color = color;
			this.origColor = origColor;
			this.disableAlpha = disableAlpha;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000394E File Offset: 0x00001B4E
		public ColorVariable(string identity, string name, Color32 color, bool disableAlpha = true)
		{
			this.identity = identity;
			this.name = name;
			this.color = color;
			this.origColor = color;
			this.disableAlpha = disableAlpha;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00009C58 File Offset: 0x00007E58
		public ColorVariable(ColorVariable option)
		{
			this.identity = option.identity;
			this.name = option.name;
			this.color = option.color;
			this.origColor = option.origColor;
			this.disableAlpha = option.disableAlpha;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00003984 File Offset: 0x00001B84
		public static implicit operator Color(ColorVariable color)
		{
			return color.color.ToColor();
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00003996 File Offset: 0x00001B96
		public static implicit operator Color32(ColorVariable color)
		{
			return color.color;
		}

		// Token: 0x0400006D RID: 109
		public SerializableColor color;

		// Token: 0x0400006E RID: 110
		public bool disableAlpha;

		// Token: 0x0400006F RID: 111
		public string identity;

		// Token: 0x04000070 RID: 112
		public string name;

		// Token: 0x04000071 RID: 113
		public SerializableColor origColor;
	}
}
