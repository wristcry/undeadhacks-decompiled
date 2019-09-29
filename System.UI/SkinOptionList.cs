using System;
using System.Collections.Generic;

namespace UndeadHacks
{
	// Token: 0x0200009A RID: 154
	public class SkinOptionList
	{
		// Token: 0x0600024E RID: 590 RVA: 0x000049B7 File Offset: 0x00002BB7
		public SkinOptionList(ESkinType Type)
		{
			this.Type = Type;
		}

		// Token: 0x04000221 RID: 545
		public HashSet<Skin> Skins = new HashSet<Skin>();

		// Token: 0x04000222 RID: 546
		public ESkinType Type = ESkinType.WEAPONS;
	}
}
