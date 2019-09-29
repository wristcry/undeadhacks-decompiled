using System;
using SDG.Unturned;

namespace UndeadHacks
{
	// Token: 0x0200008F RID: 143
	public static class RaycastOptions
	{
		// Token: 0x040001F4 RID: 500
		[Save]
		public static bool Enabled;

		// Token: 0x040001F5 RID: 501
		[Save]
		public static bool TargetPlayers = true;

		// Token: 0x040001F6 RID: 502
		[Save]
		public static bool TargetZombies;

		// Token: 0x040001F7 RID: 503
		[Save]
		public static bool TargetAnimals;

		// Token: 0x040001F8 RID: 504
		[Save]
		public static bool TargetSentries;

		// Token: 0x040001F9 RID: 505
		[Save]
		public static bool TargetBeds;

		// Token: 0x040001FA RID: 506
		[Save]
		public static bool TargetClaimFlags;

		// Token: 0x040001FB RID: 507
		[Save]
		public static bool TargetStorage;

		// Token: 0x040001FC RID: 508
		[Save]
		public static bool TargetVehicles;

		// Token: 0x040001FD RID: 509
		[Save]
		public static bool UseRandomLimb;

		// Token: 0x040001FE RID: 510
		[Save]
		public static bool UseCustomLimb;

		// Token: 0x040001FF RID: 511
		[Save]
		public static bool SilentAimUseFOV = true;

		// Token: 0x04000200 RID: 512
		[Save]
		public static bool WallCheck;

		// Token: 0x04000201 RID: 513
		[Save]
		public static float SilentAimFOV = 10f;

		// Token: 0x04000202 RID: 514
		[Save]
		public static EPhysicsMaterial TargetMaterial = EPhysicsMaterial.ALIEN_DYNAMIC;

		// Token: 0x04000203 RID: 515
		[Save]
		public static ELimb TargetLimb = ELimb.SKULL;
	}
}
