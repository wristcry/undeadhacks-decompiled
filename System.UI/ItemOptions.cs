using System;

namespace UndeadHacks
{
	// Token: 0x0200004D RID: 77
	public static class ItemOptions
	{
		// Token: 0x04000116 RID: 278
		[Save]
		public static bool AutoItemPickup;

		// Token: 0x04000117 RID: 279
		[Save]
		public static bool AutoForagePickup;

		// Token: 0x04000118 RID: 280
		[Save]
		public static bool AutoFarmPickup;

		// Token: 0x04000119 RID: 281
		[Save]
		public static float FarmPickupRange = 300f;

		// Token: 0x0400011A RID: 282
		[Save]
		public static int ItemPickupDelay = 600;

		// Token: 0x0400011B RID: 283
		[Save]
		public static ItemOptionList ItemFilterOptions = new ItemOptionList();

		// Token: 0x0400011C RID: 284
		[Save]
		public static bool EnablePickupFilter;

		// Token: 0x0400011D RID: 285
		[Save]
		public static ItemOptionList ItemESPOptions = new ItemOptionList();
	}
}
