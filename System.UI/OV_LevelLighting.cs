using System;
using System.Reflection;
using SDG.Unturned;

namespace UndeadHacks
{
	// Token: 0x02000078 RID: 120
	public static class OV_LevelLighting
	{
		// Token: 0x060001C0 RID: 448 RVA: 0x000044A7 File Offset: 0x000026A7
		[OnSpy]
		public static void Disable()
		{
			if (!DrawUtilities.ShouldRun())
			{
				return;
			}
			OV_LevelLighting.WasEnabled = MiscOptions.ShowPlayersOnMap;
			MiscOptions.ShowPlayersOnMap = false;
			OV_LevelLighting.OV_updateLighting();
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x000044C6 File Offset: 0x000026C6
		[OffSpy]
		public static void Enable()
		{
			if (!DrawUtilities.ShouldRun())
			{
				return;
			}
			MiscOptions.ShowPlayersOnMap = OV_LevelLighting.WasEnabled;
			OV_LevelLighting.OV_updateLighting();
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x00011018 File Offset: 0x0000F218
		[Override(typeof(LevelLighting), "updateLighting", BindingFlags.Static | BindingFlags.Public, 0)]
		public static void OV_updateLighting()
		{
			if (DrawUtilities.ShouldRun() && MiscOptions.SetTimeEnabled && !PlayerCoroutines.IsSpying && !MiscOptions.PanicMode)
			{
				float time = LevelLighting.time;
				OV_LevelLighting.Time.SetValue(null, MiscOptions.Time);
				OverrideUtilities.CallOriginal(null, Array.Empty<object>());
				OV_LevelLighting.Time.SetValue(null, time);
				return;
			}
			OverrideUtilities.CallOriginal(null, Array.Empty<object>());
		}

		// Token: 0x040001B9 RID: 441
		public static FieldInfo Time = typeof(LevelLighting).GetField(<Module>.smethod_4<string>(3576660816u), BindingFlags.Static | BindingFlags.NonPublic);

		// Token: 0x040001BA RID: 442
		public static bool WasEnabled;
	}
}
