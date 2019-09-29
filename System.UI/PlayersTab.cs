using System;
using System.Linq;
using SDG.Unturned;
using Steamworks;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000086 RID: 134
	public static class PlayersTab
	{
		// Token: 0x060001FF RID: 511 RVA: 0x00013334 File Offset: 0x00011534
		public static void Tab()
		{
			Prefab.ScrollView(new Rect(0f, 0f, 611f, 275f), <Module>.smethod_4<string>(3301307694u), ref PlayersTab.PlayersScroll, delegate()
			{
				for (int i = 0; i < Provider.clients.Count; i++)
				{
					Player player = Provider.clients[i].player;
					if (!(player == OptimizationVariables.MainPlayer) && !(player == null))
					{
						bool flag = FriendUtilities.IsFriendly(player);
						bool flag2 = MiscOptions.SpectatedPlayer == player;
						bool flag3 = false;
						bool flag4 = player == PlayersTab.SelectedPlayer;
						string text = flag ? <Module>.smethod_8<string>(4166463673u) : string.Empty;
						if (Prefab.Button(string.Concat(new string[]
						{
							flag4 ? <Module>.smethod_6<string>(2195033597u) : string.Empty,
							flag2 ? <Module>.smethod_4<string>(3696811310u) : string.Empty,
							text,
							string.Format(<Module>.smethod_5<string>(1117104513u), player.name),
							(flag || flag3) ? <Module>.smethod_8<string>(3685355732u) : string.Empty,
							flag4 ? <Module>.smethod_8<string>(3224675796u) : string.Empty
						}), 560f, 25f))
						{
							PlayersTab.SelectedPlayer = player;
						}
						GUILayout.Space(2f);
					}
				}
			}, 20);
			Prefab.MenuArea(new Rect(0f, 280f, 190f, 126f), <Module>.smethod_4<string>(4241352632u), delegate
			{
				if (PlayersTab.SelectedPlayer == null)
				{
					return;
				}
				CSteamID steamID = PlayersTab.SelectedPlayer.channel.owner.playerID.steamID;
				GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
				GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
				if (!PlayersTab.SelectedPlayer.quests.isMemberOfSameGroupAs(Player.player))
				{
					if (!FriendUtilities.IsFriendly(PlayersTab.SelectedPlayer) || !Prefab.Button(<Module>.smethod_7<string>(1255989687u), 150f, 25f))
					{
						if (Prefab.Button(<Module>.smethod_4<string>(3959284102u), 150f, 25f))
						{
							FriendUtilities.AddFriend(PlayersTab.SelectedPlayer);
						}
					}
					else
					{
						FriendUtilities.RemoveFriend(PlayersTab.SelectedPlayer);
					}
				}
				if (MiscOptions.SpectatedPlayer != PlayersTab.SelectedPlayer && Prefab.Button(<Module>.smethod_8<string>(4065336127u), 150f, 25f))
				{
					MiscOptions.SpectatedPlayer = PlayersTab.SelectedPlayer;
				}
				if (MiscOptions.SpectatedPlayer == PlayersTab.SelectedPlayer && Prefab.Button(<Module>.smethod_5<string>(655868470u), 150f, 25f))
				{
					MiscOptions.SpectatedPlayer = null;
				}
				GUILayout.EndVertical();
				GUILayout.EndHorizontal();
			});
			Prefab.MenuArea(new Rect(196f, 280f, 415f, 126f), <Module>.smethod_8<string>(16679200u), delegate
			{
				if (PlayersTab.SelectedPlayer == null)
				{
					return;
				}
				GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
				GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
				GUILayout.Label(<Module>.smethod_6<string>(1235531009u), Array.Empty<GUILayoutOption>());
				GUILayout.TextField(PlayersTab.SelectedPlayer.channel.owner.playerID.steamID.ToString(), Prefab._TextStyle, Array.Empty<GUILayoutOption>());
				GUILayout.Space(2f);
				GUILayout.TextField(<Module>.smethod_6<string>(852566950u) + LocationUtilities.GetClosestLocation(PlayersTab.SelectedPlayer.transform.position).name, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
				GUILayout.Label(<Module>.smethod_7<string>(4294773308u) + ((PlayersTab.SelectedPlayer.equipment.asset != null) ? PlayersTab.SelectedPlayer.equipment.asset.itemName : <Module>.smethod_7<string>(2304575930u)), Prefab._TextStyle, Array.Empty<GUILayoutOption>());
				GUILayout.Label(<Module>.smethod_8<string>(2779063744u) + ((PlayersTab.SelectedPlayer.movement.getVehicle() != null) ? PlayersTab.SelectedPlayer.movement.getVehicle().asset.name : <Module>.smethod_4<string>(1580009302u)), Prefab._TextStyle, Array.Empty<GUILayoutOption>());
				GUILayout.Label(<Module>.smethod_7<string>(1069907404u) + Provider.clients.Count((SteamPlayer c) => c.player != PlayersTab.SelectedPlayer && c.player.quests.isMemberOfSameGroupAs(PlayersTab.SelectedPlayer)), Prefab._TextStyle, Array.Empty<GUILayoutOption>());
				GUILayout.EndVertical();
				GUILayout.EndHorizontal();
			});
		}

		// Token: 0x040001D6 RID: 470
		public static Vector2 PlayersScroll;

		// Token: 0x040001D7 RID: 471
		public static Player SelectedPlayer;
	}
}
