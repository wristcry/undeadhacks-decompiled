using System;
using System.Collections.Generic;

namespace UndeadHacks
{
	// Token: 0x02000099 RID: 153
	public class SkinConfig
	{
		// Token: 0x04000219 RID: 537
		public int BackpackID;

		// Token: 0x0400021A RID: 538
		public int GlassesID;

		// Token: 0x0400021B RID: 539
		public int HatID;

		// Token: 0x0400021C RID: 540
		public int MaskID;

		// Token: 0x0400021D RID: 541
		public int PantsID;

		// Token: 0x0400021E RID: 542
		public int ShirtID;

		// Token: 0x0400021F RID: 543
		public int VestID;

		// Token: 0x04000220 RID: 544
		public HashSet<WeaponSave> WeaponSkins = new HashSet<WeaponSave>();
	}
}
