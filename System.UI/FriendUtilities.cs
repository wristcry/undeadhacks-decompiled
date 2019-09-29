using System;
using SDG.Unturned;

namespace UndeadHacks
{
	// Token: 0x0200003B RID: 59
	public static class FriendUtilities
	{
		// Token: 0x060000F8 RID: 248 RVA: 0x00003D82 File Offset: 0x00001F82
		public static bool IsFriendly(Player player)
		{
			return player.quests.isMemberOfSameGroupAs(Player.player) || MiscOptions.Friends.Contains(player.channel.owner.playerID.steamID.m_SteamID);
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0000CE04 File Offset: 0x0000B004
		public static void AddFriend(Player Friend)
		{
			ulong steamID = Friend.channel.owner.playerID.steamID.m_SteamID;
			if (!MiscOptions.Friends.Contains(steamID))
			{
				MiscOptions.Friends.Add(steamID);
			}
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0000CE48 File Offset: 0x0000B048
		public static void RemoveFriend(Player Friend)
		{
			ulong steamID = Friend.channel.owner.playerID.steamID.m_SteamID;
			if (MiscOptions.Friends.Contains(steamID))
			{
				MiscOptions.Friends.Remove(steamID);
			}
		}
	}
}
