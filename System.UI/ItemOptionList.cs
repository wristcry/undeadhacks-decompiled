using System;
using System.Collections.Generic;

namespace UndeadHacks
{
	// Token: 0x0200004C RID: 76
	public class ItemOptionList
	{
		// Token: 0x04000109 RID: 265
		public HashSet<ushort> AddedItems = new HashSet<ushort>();

		// Token: 0x0400010A RID: 266
		public SerializableVector2 additemscroll = new SerializableVector2(0f, 0f);

		// Token: 0x0400010B RID: 267
		public bool ItemfilterAmmo;

		// Token: 0x0400010C RID: 268
		public bool ItemfilterBackpack;

		// Token: 0x0400010D RID: 269
		public bool ItemfilterCharges;

		// Token: 0x0400010E RID: 270
		public bool ItemfilterClothing;

		// Token: 0x0400010F RID: 271
		public bool ItemfilterCustom = true;

		// Token: 0x04000110 RID: 272
		public bool ItemfilterFoodAndWater;

		// Token: 0x04000111 RID: 273
		public bool ItemfilterFuel;

		// Token: 0x04000112 RID: 274
		public bool ItemfilterGun;

		// Token: 0x04000113 RID: 275
		public bool ItemfilterMedical;

		// Token: 0x04000114 RID: 276
		public SerializableVector2 removeitemscroll = new SerializableVector2(0f, 0f);

		// Token: 0x04000115 RID: 277
		public string searchstring = string.Empty;
	}
}
