using System;

namespace UndeadHacks
{
	// Token: 0x020000B3 RID: 179
	public static class WeaponOptions
	{
		// Token: 0x0400025F RID: 607
		[Save]
		public static bool Zoom;

		// Token: 0x04000260 RID: 608
		[Save]
		public static float ZoomValue = 16f;

		// Token: 0x04000261 RID: 609
		[Save]
		public static bool ShowWeaponInfo = true;

		// Token: 0x04000262 RID: 610
		[Save]
		public static SerializableColor CrosshairColor = new SerializableColor(255, 0, 0);

		// Token: 0x04000263 RID: 611
		[Save]
		public static bool NoRecoil;

		// Token: 0x04000264 RID: 612
		[Save]
		public static bool NoSpread;

		// Token: 0x04000265 RID: 613
		[Save]
		public static bool NoSway;

		// Token: 0x04000266 RID: 614
		[Save]
		public static bool NoDrop;
	}
}
