using System;
using SDG.Unturned;

namespace UndeadHacks
{
	// Token: 0x02000016 RID: 22
	public static class AimbotOptions
	{
		// Token: 0x04000047 RID: 71
		[Save]
		public static bool Enabled;

		// Token: 0x04000048 RID: 72
		[Save]
		public static bool Smooth = true;

		// Token: 0x04000049 RID: 73
		[Save]
		public static bool OnKey;

		// Token: 0x0400004A RID: 74
		public static float MaxSpeed = 50f;

		// Token: 0x0400004B RID: 75
		[Save]
		public static float AimSpeed = 5f;

		// Token: 0x0400004C RID: 76
		[Save]
		public static float FOV = 15f;

		// Token: 0x0400004D RID: 77
		[Save]
		public static ELimb TargetLimb = ELimb.SKULL;

		// Token: 0x0400004E RID: 78
		[Save]
		public static TargetMode TargetMode = TargetMode.FOV;
	}
}
