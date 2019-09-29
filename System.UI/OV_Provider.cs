using System;
using System.Diagnostics;
using System.Reflection;
using SDG.Unturned;
using Steamworks;

namespace UndeadHacks
{
	// Token: 0x02000081 RID: 129
	public static class OV_Provider
	{
		// Token: 0x060001E8 RID: 488 RVA: 0x00012904 File Offset: 0x00010B04
		public static void OV_receiveClient(CSteamID steamID, byte[] packet, int offset, int size, int channel)
		{
			if (!OV_Provider.IsConnected)
			{
				OV_Provider.IsConnected = true;
			}
			if (ServerCrashThread.ServerCrashEnabled)
			{
				if (packet[0] == 1)
				{
					return;
				}
			}
			if (steamID != Provider.server && packet[0] != 23)
			{
				return;
			}
			OverrideUtilities.CallOriginal(null, new object[]
			{
				steamID,
				packet,
				offset,
				size,
				channel
			});
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00004697 File Offset: 0x00002897
		[Override(typeof(Provider), "OnApplicationQuit", BindingFlags.Instance | BindingFlags.NonPublic, 0)]
		public static void OV_OnApplicationQuit()
		{
			Process.GetCurrentProcess().Kill();
		}

		// Token: 0x040001CB RID: 459
		public static bool IsConnected;
	}
}
