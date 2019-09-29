using System;
using System.Collections.Generic;

namespace UndeadHacks
{
	// Token: 0x0200009A RID: 154
	public class SkinOptionList
	{
		// Token: 0x06000251 RID: 593 RVA: 0x00004987 File Offset: 0x00002B87
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
