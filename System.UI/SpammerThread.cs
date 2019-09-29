using System;
using System.Threading;
using SDG.Unturned;

namespace UndeadHacks
{
	// Token: 0x0200009F RID: 159
	public static class SpammerThread
	{
		// Token: 0x06000261 RID: 609 RVA: 0x000167EC File Offset: 0x000149EC
		[Thread]
		public static void Spammer()
		{
			for (;;)
			{
				Thread.Sleep(MiscOptions.SpammerDelay);
				if (MiscOptions.SpammerEnabled)
				{
					ChatManager.instance.channel.send(<Module>.smethod_4<string>(1965208654u), ESteamCall.SERVER, ESteamPacket.UPDATE_RELIABLE_BUFFER, new object[]
					{
						0,
						MiscOptions.SpamText
					});
				}
			}
		}
	}
}
