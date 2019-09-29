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
		// Token: 0x060001FE RID: 510 RVA: 0x000130F0 File Offset: 0x000112F0
		public static void Tab()
		{
			Prefab.ScrollView(new Rect(0f, 0f, 611f, 275f), "Игроки", ref PlayersTab.PlayersScroll, delegate()
			{
				for (int i = 0; i < Provider.clients.Count; i++)
				{
					Player player = Provider.clients[i].player;
					if (!(player == Player.player) && !(player == null))
					{
						bool flag = FriendUtilities.IsFriendly(player);
						bool flag2 = MiscOptions.SpectatedPlayer == player;
						bool flag3 = false;
						bool flag4 = player == PlayersTab.SelectedPlayer;
						string text = flag ? "<color=#00ff00ff>" : string.Empty;
						if (Prefab.Button(string.Concat(new string[]
						{
							flag4 ? "<b>" : string.Empty,
							flag2 ? "<color=#0000ffff>[НАБЛЮДЕНИЕ]</color> " : string.Empty,
							text,
							string.Format("{0}", player.name),
							(flag || flag3) ? "</color>" : string.Empty,
							flag4 ? "</b>" : string.Empty
						}), 560f, 25f))
						{
							PlayersTab.SelectedPlayer = player;
						}
						GUILayout.Space(2f);
					}
				}
			}, 20);
			Prefab.MenuArea(new Rect(0f, 280f, 190f, 126f), "ОПЦИИ", delegate
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
					if (FriendUtilities.IsFriendly(PlayersTab.SelectedPlayer) && Prefab.Button("Убрать друга", 150f, 25f))
					{
						FriendUtilities.RemoveFriend(PlayersTab.SelectedPlayer);
					}
					else if (Prefab.Button("Добавить друга", 150f, 25f))
					{
						FriendUtilities.AddFriend(PlayersTab.SelectedPlayer);
					}
				}
				if (MiscOptions.SpectatedPlayer != PlayersTab.SelectedPlayer && Prefab.Button("Наблюдать", 150f, 25f))
				{
					MiscOptions.SpectatedPlayer = PlayersTab.SelectedPlayer;
				}
				if (MiscOptions.SpectatedPlayer == PlayersTab.SelectedPlayer && Prefab.Button("Прекратить наблюдение", 150f, 25f))
				{
					MiscOptions.SpectatedPlayer = null;
				}
				GUILayout.EndVertical();
				GUILayout.EndHorizontal();
			});
			Prefab.MenuArea(new Rect(196f, 280f, 415f, 126f), "ИНФО", delegate
			{
				if (PlayersTab.SelectedPlayer == null)
				{
					return;
				}
				GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
				GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
				GUILayout.Label("SteamID:", Array.Empty<GUILayoutOption>());
				GUILayout.TextField(PlayersTab.SelectedPlayer.channel.owner.playerID.steamID.ToString(), Prefab._TextStyle, Array.Empty<GUILayoutOption>());
				GUILayout.Space(2f);
				GUILayout.TextField("Местонахождение: " + LocationUtilities.GetClosestLocation(PlayersTab.SelectedPlayer.transform.position).name, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
				GUILayout.Label("Оружие: " + ((PlayersTab.SelectedPlayer.equipment.asset != null) ? PlayersTab.SelectedPlayer.equipment.asset.itemName : "Нет оружия"), Prefab._TextStyle, Array.Empty<GUILayoutOption>());
				GUILayout.Label("Машина: " + ((PlayersTab.SelectedPlayer.movement.getVehicle() != null) ? PlayersTab.SelectedPlayer.movement.getVehicle().asset.name : "Нет машины"), Prefab._TextStyle, Array.Empty<GUILayoutOption>());
				GUILayout.Label("Члены группы: " + Provider.clients.Count((SteamPlayer c) => c.player != PlayersTab.SelectedPlayer && c.player.quests.isMemberOfSameGroupAs(PlayersTab.SelectedPlayer)), Prefab._TextStyle, Array.Empty<GUILayoutOption>());
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
