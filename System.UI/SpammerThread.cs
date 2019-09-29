using System;
using System.Threading;
using SDG.Unturned;

namespace UndeadHacks
{
	// Token: 0x0200009F RID: 159
	public static class SpammerThread
	{
		// Token: 0x0600025E RID: 606 RVA: 0x0001654C File Offset: 0x0001474C
		[Thread]
		public static void Spammer()
		{
			for (;;)
			{
				Thread.Sleep(MiscOptions.SpammerDelay);
				if (MiscOptions.SpammerEnabled)
				{
					ChatManager.instance.channel.send("askChat", ESteamCall.SERVER, ESteamPacket.UPDATE_RELIABLE_BUFFER, new object[]
					{
						0,
						MiscOptions.SpamText
					});
				}
			}
		}
	}
}
