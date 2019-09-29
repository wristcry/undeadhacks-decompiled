using System;
using System.Linq;

namespace UndeadHacks
{
	// Token: 0x02000035 RID: 53
	public static class ESPOptions
	{
		// Token: 0x040000A3 RID: 163
		[Save]
		public static bool Enabled = true;

		// Token: 0x040000A4 RID: 164
		[Save]
		public static bool TextStyle = true;

		// Token: 0x040000A5 RID: 165
		[Save]
		public static bool ChamsEnabled;

		// Token: 0x040000A6 RID: 166
		[Save]
		public static int ChamsMode = 0;

		// Token: 0x040000A7 RID: 167
		[Save]
		public static ESPVisual[] VisualOptions = Enumerable.Repeat<ESPVisual>(new ESPVisual
		{
			Labels = true,
			Boxes = false,
			ShowName = true,
			ShowDistance = true,
			Glow = true,
			Distance = 1000f,
			Location = LabelLocation.BottomMiddle,
			FixedTextSize = 11,
			MinTextSize = 8,
			MaxTextSize = 11,
			MinTextSizeDistance = 800f,
			BorderStrength = 0,
			ObjectCap = 24
		}, Enum.GetValues(typeof(ESPTarget)).Length).ToArray<ESPVisual>();

		// Token: 0x040000A8 RID: 168
		[Save]
		public static bool ShowPlayerWeapon = true;

		// Token: 0x040000A9 RID: 169
		[Save]
		public static bool FullName;

		// Token: 0x040000AA RID: 170
		[Save]
		public static bool ShowPlayerVehicle;

		// Token: 0x040000AB RID: 171
		[Save]
		public static bool FilterItems;

		// Token: 0x040000AC RID: 172
		[Save]
		public static bool ShowVehicleFuel;

		// Token: 0x040000AD RID: 173
		[Save]
		public static bool ShowVehicleHealth;

		// Token: 0x040000AE RID: 174
		[Save]
		public static bool ShowVehicleLocked;

		// Token: 0x040000AF RID: 175
		[Save]
		public static bool FilterVehicleLocked;

		// Token: 0x040000B0 RID: 176
		[Save]
		public static bool ShowSentryItem;

		// Token: 0x040000B1 RID: 177
		[Save]
		public static bool ShowClaimed;

		// Token: 0x040000B2 RID: 178
		[Save]
		public static bool ShowGeneratorFuel;

		// Token: 0x040000B3 RID: 179
		[Save]
		public static bool ShowGeneratorPowered;

		// Token: 0x040000B4 RID: 180
		[Save]
		public static bool ShowVanishPlayers;
	}
}
