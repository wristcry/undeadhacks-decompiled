using System;
using System.Collections.Generic;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000060 RID: 96
	public static class MiscOptions
	{
		// Token: 0x0400015D RID: 349
		public static bool SpeedHack;

		// Token: 0x0400015E RID: 350
		public static float Altitude;

		// Token: 0x0400015F RID: 351
		public static bool PanicMode;

		// Token: 0x04000160 RID: 352
		[Save]
		public static bool ShowSilentFOV;

		// Token: 0x04000161 RID: 353
		[Save]
		public static bool ShowAimFOV;

		// Token: 0x04000162 RID: 354
		[Save]
		public static bool Disconnect;

		// Token: 0x04000163 RID: 355
		[Save]
		public static bool FastSell;

		// Token: 0x04000164 RID: 356
		[Save]
		public static bool FastBuy;

		// Token: 0x04000165 RID: 357
		[Save]
		public static int FastSellCount = 5;

		// Token: 0x04000166 RID: 358
		[Save]
		public static bool PunchAura;

		// Token: 0x04000167 RID: 359
		[Save]
		public static bool NoSnow;

		// Token: 0x04000168 RID: 360
		[Save]
		public static bool NoRain;

		// Token: 0x04000169 RID: 361
		[Save]
		public static bool BuildObs;

		// Token: 0x0400016A RID: 362
		[Save]
		public static bool CustomSalvageTime;

		// Token: 0x0400016B RID: 363
		[Save]
		public static float SalvageTime = 1f;

		// Token: 0x0400016C RID: 364
		public static Vector3 pos;

		// Token: 0x0400016D RID: 365
		public static bool epos;

		// Token: 0x0400016E RID: 366
		[Save]
		public static bool SetTimeEnabled;

		// Token: 0x0400016F RID: 367
		[Save]
		public static float Time = 0f;

		// Token: 0x04000170 RID: 368
		[Save]
		public static bool SlowFall;

		// Token: 0x04000171 RID: 369
		[Save]
		public static int TimeAcceleration = 1;

		// Token: 0x04000172 RID: 370
		[Save]
		public static bool Compass;

		// Token: 0x04000173 RID: 371
		[Save]
		public static bool GPS;

		// Token: 0x04000174 RID: 372
		[Save]
		public static bool ShowPlayersOnMap;

		// Token: 0x04000175 RID: 373
		[Save]
		public static bool NightVision;

		// Token: 0x04000176 RID: 374
		public static bool WasNightVision;

		// Token: 0x04000177 RID: 375
		[Save]
		public static string SpamText = <Module>.smethod_5<string>(1857340813u);

		// Token: 0x04000178 RID: 376
		[Save]
		public static string TabFont = <Module>.smethod_8<string>(768326460u);

		// Token: 0x04000179 RID: 377
		[Save]
		public static string TextFont = <Module>.smethod_4<string>(3306459826u);

		// Token: 0x0400017A RID: 378
		[Save]
		public static string EspFont = <Module>.smethod_4<string>(3306459826u);

		// Token: 0x0400017B RID: 379
		[Save]
		public static bool SpammerEnabled;

		// Token: 0x0400017C RID: 380
		[Save]
		public static int SpammerDelay = 1000;

		// Token: 0x0400017D RID: 381
		[Save]
		public static bool VehicleFly;

		// Token: 0x0400017E RID: 382
		[Save]
		public static bool VehicleUseMaxSpeed;

		// Token: 0x0400017F RID: 383
		[Save]
		public static bool VehicleRigibody;

		// Token: 0x04000180 RID: 384
		[Save]
		public static float SpeedMultiplier = 1f;

		// Token: 0x04000181 RID: 385
		[Save]
		public static bool ExtendMeleeRange;

		// Token: 0x04000182 RID: 386
		[Save]
		public static bool ExtendRangeBypass;

		// Token: 0x04000183 RID: 387
		[Save]
		public static bool IncreaseNearbyItemDistance;

		// Token: 0x04000184 RID: 388
		public static Player SpectatedPlayer;

		// Token: 0x04000185 RID: 389
		[Save]
		public static float FlightSpeedMultiplier = 1f;

		// Token: 0x04000186 RID: 390
		[Save]
		public static bool Freecam;

		// Token: 0x04000187 RID: 391
		[Save]
		public static HashSet<ulong> Friends = new HashSet<ulong>();

		// Token: 0x04000188 RID: 392
		[Save]
		public static int SCrashMethod = 1;

		// Token: 0x04000189 RID: 393
		[Save]
		public static bool AlertOnSpy;
	}
}
