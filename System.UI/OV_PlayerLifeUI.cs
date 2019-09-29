using System;
using System.Reflection;
using SDG.Unturned;

namespace UndeadHacks
{
	// Token: 0x0200007E RID: 126
	public static class OV_PlayerLifeUI
	{
		// Token: 0x060001E2 RID: 482 RVA: 0x00004644 File Offset: 0x00002844
		[Override(typeof(PlayerLifeUI), "hasCompassInInventory", BindingFlags.Static | BindingFlags.NonPublic, 0)]
		public static bool OV_hasCompassInInventory()
		{
			return MiscOptions.Compass || (bool)OverrideUtilities.CallOriginal(null, Array.Empty<object>());
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x0000465F File Offset: 0x0000285F
		[OnSpy]
		public static void Disable()
		{
			if (!DrawUtilities.ShouldRun())
			{
				return;
			}
			OV_PlayerLifeUI.WasCompassEnabled = MiscOptions.Compass;
			MiscOptions.Compass = false;
			PlayerLifeUI.updateCompass();
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0000467E File Offset: 0x0000287E
		[OffSpy]
		public static void Enable()
		{
			if (!DrawUtilities.ShouldRun())
			{
				return;
			}
			MiscOptions.Compass = OV_PlayerLifeUI.WasCompassEnabled;
			PlayerLifeUI.updateCompass();
		}

		// Token: 0x040001CA RID: 458
		public static bool WasCompassEnabled;
	}
}
