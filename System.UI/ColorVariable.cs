using System;
using Newtonsoft.Json;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000024 RID: 36
	public class ColorVariable
	{
		// Token: 0x06000095 RID: 149 RVA: 0x00003912 File Offset: 0x00001B12
		[JsonConstructor]
		public ColorVariable(string identity, string name, Color32 color, Color32 origColor, bool disableAlpha)
		{
			this.identity = identity;
			this.name = name;
			this.color = color.ToSerializableColor();
			this.origColor = origColor.ToSerializableColor();
			this.disableAlpha = disableAlpha;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00003949 File Offset: 0x00001B49
		public ColorVariable(string identity, string name, Color32 color, bool disableAlpha = true)
		{
			this.identity = identity;
			this.name = name;
			this.color = color.ToSerializableColor();
			this.origColor = color.ToSerializableColor();
			this.disableAlpha = disableAlpha;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000099C0 File Offset: 0x00007BC0
		public ColorVariable(ColorVariable option)
		{
			this.identity = option.identity;
			this.name = option.name;
			this.color = option.color;
			this.origColor = option.origColor;
			this.disableAlpha = option.disableAlpha;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000397F File Offset: 0x00001B7F
		public static implicit operator Color(ColorVariable color)
		{
			return color.color.ToColor();
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00003991 File Offset: 0x00001B91
		public static implicit operator Color32(ColorVariable color)
		{
			return color.color.ToColor();
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
