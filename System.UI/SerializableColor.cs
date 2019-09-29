using System;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000094 RID: 148
	public class SerializableColor
	{
		// Token: 0x06000240 RID: 576 RVA: 0x000034FB File Offset: 0x000016FB
		public SerializableColor()
		{
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00004879 File Offset: 0x00002A79
		public SerializableColor(int nr, int ng, int nb, int na)
		{
			this.r = nr;
			this.g = ng;
			this.b = nb;
			this.a = na;
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0000489E File Offset: 0x00002A9E
		public SerializableColor(int nr, int ng, int nb)
		{
			this.r = nr;
			this.g = ng;
			this.b = nb;
			this.a = 255;
		}

		// Token: 0x06000243 RID: 579 RVA: 0x000048C6 File Offset: 0x00002AC6
		public static implicit operator Color32(SerializableColor color)
		{
			return color.ToColor();
		}

		// Token: 0x06000244 RID: 580 RVA: 0x000048CE File Offset: 0x00002ACE
		public static implicit operator Color(SerializableColor color)
		{
			return color.ToColor();
		}

		// Token: 0x06000245 RID: 581 RVA: 0x000048DB File Offset: 0x00002ADB
		public static implicit operator SerializableColor(Color32 color)
		{
			return color.ToSerializableColor();
		}

		// Token: 0x06000246 RID: 582 RVA: 0x000048E3 File Offset: 0x00002AE3
		public Color32 ToColor()
		{
			return new Color32((byte)this.r, (byte)this.g, (byte)this.b, (byte)this.a);
		}

		// Token: 0x0400020D RID: 525
		public int a;

		// Token: 0x0400020E RID: 526
		public int b;

		// Token: 0x0400020F RID: 527
		public int g;

		// Token: 0x04000210 RID: 528
		public int r;
	}
}
