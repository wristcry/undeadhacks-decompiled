using System;

namespace UndeadHacks
{
	// Token: 0x02000047 RID: 71
	public static class InteractionOptions
	{
		// Token: 0x040000FC RID: 252
		[Save]
		public static bool InteractThroughWalls;

		// Token: 0x040000FD RID: 253
		[Save]
		public static bool NoHitStructures = true;

		// Token: 0x040000FE RID: 254
		[Save]
		public static bool NoHitBarricades;

		// Token: 0x040000FF RID: 255
		[Save]
		public static bool NoHitItems;

		// Token: 0x04000100 RID: 256
		[Save]
		public static bool NoHitVehicles;

		// Token: 0x04000101 RID: 257
		[Save]
		public static bool NoHitResources = true;

		// Token: 0x04000102 RID: 258
		[Save]
		public static bool NoHitEnvironment = true;
	}
}
