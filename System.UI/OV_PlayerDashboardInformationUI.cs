using System;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200007B RID: 123
	public static class OV_PlayerDashboardInformationUI
	{
		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x00004523 File Offset: 0x00002723
		private static Sleek mapDynamicContainer
		{
			get
			{
				return (Sleek)OV_PlayerDashboardInformationUI.DynamicContainerInfo.GetValue(null);
			}
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x000111E8 File Offset: 0x0000F3E8
		public static int GetMap()
		{
			PlayerInventory inventory = OptimizationVariables.MainPlayer.inventory;
			if (!MiscOptions.GPS && inventory.has(1176) == null)
			{
				return 0;
			}
			return 1;
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00011218 File Offset: 0x0000F418
		[OnSpy]
		public static void Disable()
		{
			if (!DrawUtilities.ShouldRun())
			{
				return;
			}
			OV_PlayerDashboardInformationUI.WasEnabled = MiscOptions.ShowPlayersOnMap;
			OV_PlayerDashboardInformationUI.WasGPSEnabled = MiscOptions.GPS;
			MiscOptions.ShowPlayersOnMap = false;
			MiscOptions.GPS = false;
			OV_PlayerDashboardInformationUI.RefreshStaticMap.Invoke(OptimizationVariables.MainPlayer.inventory, new object[]
			{
				OV_PlayerDashboardInformationUI.GetMap()
			});
			OV_PlayerDashboardInformationUI.OV_refreshDynamicMap();
		}

		// Token: 0x060001CB RID: 459 RVA: 0x0001127C File Offset: 0x0000F47C
		[OffSpy]
		public static void Enable()
		{
			if (!DrawUtilities.ShouldRun())
			{
				return;
			}
			MiscOptions.ShowPlayersOnMap = OV_PlayerDashboardInformationUI.WasEnabled;
			MiscOptions.GPS = OV_PlayerDashboardInformationUI.WasGPSEnabled;
			OV_PlayerDashboardInformationUI.RefreshStaticMap.Invoke(OptimizationVariables.MainPlayer.inventory, new object[]
			{
				OV_PlayerDashboardInformationUI.GetMap()
			});
			OV_PlayerDashboardInformationUI.OV_refreshDynamicMap();
		}

		// Token: 0x060001CC RID: 460 RVA: 0x000112D4 File Offset: 0x0000F4D4
		[Override(typeof(PlayerDashboardInformationUI), "searchForMapsInInventory", BindingFlags.Static | BindingFlags.NonPublic, 0)]
		public static void OV_searchForMapsInInventory(ref bool enableChart, ref bool enableMap)
		{
			if (MiscOptions.GPS)
			{
				enableMap = true;
				enableChart = true;
				return;
			}
			if (enableChart & enableMap)
			{
				return;
			}
			for (byte b = 0; b < PlayerInventory.PAGES - 2; b += 1)
			{
				Items items = Player.player.inventory.items[(int)b];
				if (items != null)
				{
					foreach (ItemJar itemJar in items.items)
					{
						if (itemJar != null)
						{
							ItemMapAsset itemMapAsset = Assets.find(EAssetType.ITEM, itemJar.item.id) as ItemMapAsset;
							if (itemMapAsset != null)
							{
								enableChart |= itemMapAsset.enablesChart;
								enableMap |= itemMapAsset.enablesMap;
							}
							if (enableChart & enableMap)
							{
								return;
							}
						}
					}
				}
			}
		}

		// Token: 0x060001CD RID: 461 RVA: 0x000113A8 File Offset: 0x0000F5A8
		[Override(typeof(PlayerDashboardInformationUI), "refreshDynamicMap", BindingFlags.Static | BindingFlags.Public, 0)]
		public static void OV_refreshDynamicMap()
		{
			OV_PlayerDashboardInformationUI.mapDynamicContainer.remove();
			if (!PlayerDashboardInformationUI.active)
			{
				return;
			}
			if (!PlayerDashboardInformationUI.noLabel.isVisible && Provider.modeConfigData.Gameplay.Group_Map)
			{
				if (LevelManager.levelType == ELevelType.ARENA)
				{
					Texture2D newTexture = PlayerDashboardInformationUI.icons.load<Texture2D>(<Module>.smethod_5<string>(271418181u));
					Texture2D newTexture2 = (Texture2D)Resources.Load(<Module>.smethod_5<string>(521232641u));
					if ((double)Mathf.Abs(LevelManager.arenaTargetRadius - 0.5f) > 0.01)
					{
						SleekImageTexture sleekImageTexture = new SleekImageTexture(newTexture);
						sleekImageTexture.positionScale_X = LevelManager.arenaTargetCenter.x / (float)(Level.size - Level.border * 2) + 0.5f - LevelManager.arenaTargetRadius / (float)(Level.size - Level.border * 2);
						sleekImageTexture.positionScale_Y = 0.5f - LevelManager.arenaTargetCenter.z / (float)(Level.size - Level.border * 2) - LevelManager.arenaTargetRadius / (float)(Level.size - Level.border * 2);
						sleekImageTexture.sizeScale_X = LevelManager.arenaTargetRadius * 2f / (float)(Level.size - Level.border * 2);
						sleekImageTexture.sizeScale_Y = LevelManager.arenaTargetRadius * 2f / (float)(Level.size - Level.border * 2);
						sleekImageTexture.backgroundColor = new Color(1f, 1f, 0f, 0.5f);
						OV_PlayerDashboardInformationUI.mapDynamicContainer.add(sleekImageTexture);
						SleekImageTexture sleekImageTexture2 = new SleekImageTexture(newTexture2);
						sleekImageTexture2.positionScale_Y = sleekImageTexture.positionScale_Y;
						sleekImageTexture2.sizeScale_X = sleekImageTexture.positionScale_X;
						sleekImageTexture2.sizeScale_Y = sleekImageTexture.sizeScale_Y;
						sleekImageTexture2.backgroundColor = new Color(1f, 1f, 0f, 0.5f);
						OV_PlayerDashboardInformationUI.mapDynamicContainer.add(sleekImageTexture2);
						SleekImageTexture sleekImageTexture3 = new SleekImageTexture(newTexture2);
						sleekImageTexture3.positionScale_X = sleekImageTexture.positionScale_X + sleekImageTexture.sizeScale_X;
						sleekImageTexture3.positionScale_Y = sleekImageTexture.positionScale_Y;
						sleekImageTexture3.sizeScale_X = 1f - sleekImageTexture.positionScale_X - sleekImageTexture.sizeScale_X;
						sleekImageTexture3.sizeScale_Y = sleekImageTexture.sizeScale_Y;
						sleekImageTexture3.backgroundColor = new Color(1f, 1f, 0f, 0.5f);
						OV_PlayerDashboardInformationUI.mapDynamicContainer.add(sleekImageTexture3);
						SleekImageTexture sleekImageTexture4 = new SleekImageTexture(newTexture2);
						sleekImageTexture4.sizeScale_X = 1f;
						sleekImageTexture4.sizeScale_Y = sleekImageTexture.positionScale_Y;
						sleekImageTexture4.backgroundColor = new Color(1f, 1f, 0f, 0.5f);
						OV_PlayerDashboardInformationUI.mapDynamicContainer.add(sleekImageTexture4);
						SleekImageTexture sleekImageTexture5 = new SleekImageTexture(newTexture2);
						sleekImageTexture5.positionScale_Y = sleekImageTexture.positionScale_Y + sleekImageTexture.sizeScale_Y;
						sleekImageTexture5.sizeScale_X = 1f;
						sleekImageTexture5.sizeScale_Y = 1f - sleekImageTexture.positionScale_Y - sleekImageTexture.sizeScale_Y;
						sleekImageTexture5.backgroundColor = new Color(1f, 1f, 0f, 0.5f);
						OV_PlayerDashboardInformationUI.mapDynamicContainer.add(sleekImageTexture5);
					}
					SleekImageTexture sleekImageTexture6 = new SleekImageTexture(newTexture);
					sleekImageTexture6.positionScale_X = LevelManager.arenaCurrentCenter.x / (float)(Level.size - Level.border * 2) + 0.5f - LevelManager.arenaCurrentRadius / (float)(Level.size - Level.border * 2);
					sleekImageTexture6.positionScale_Y = 0.5f - LevelManager.arenaCurrentCenter.z / (float)(Level.size - Level.border * 2) - LevelManager.arenaCurrentRadius / (float)(Level.size - Level.border * 2);
					sleekImageTexture6.sizeScale_X = LevelManager.arenaCurrentRadius * 2f / (float)(Level.size - Level.border * 2);
					sleekImageTexture6.sizeScale_Y = LevelManager.arenaCurrentRadius * 2f / (float)(Level.size - Level.border * 2);
					OV_PlayerDashboardInformationUI.mapDynamicContainer.add(sleekImageTexture6);
					SleekImageTexture sleekImageTexture7 = new SleekImageTexture(newTexture2);
					sleekImageTexture7.positionScale_Y = sleekImageTexture6.positionScale_Y;
					sleekImageTexture7.sizeScale_X = sleekImageTexture6.positionScale_X;
					sleekImageTexture7.sizeScale_Y = sleekImageTexture6.sizeScale_Y;
					OV_PlayerDashboardInformationUI.mapDynamicContainer.add(sleekImageTexture7);
					SleekImageTexture sleekImageTexture8 = new SleekImageTexture(newTexture2);
					sleekImageTexture8.positionScale_X = sleekImageTexture6.positionScale_X + sleekImageTexture6.sizeScale_X;
					sleekImageTexture8.positionScale_Y = sleekImageTexture6.positionScale_Y;
					sleekImageTexture8.sizeScale_X = 1f - sleekImageTexture6.positionScale_X - sleekImageTexture6.sizeScale_X;
					sleekImageTexture8.sizeScale_Y = sleekImageTexture6.sizeScale_Y;
					OV_PlayerDashboardInformationUI.mapDynamicContainer.add(sleekImageTexture8);
					SleekImageTexture sleekImageTexture9 = new SleekImageTexture(newTexture2);
					sleekImageTexture9.sizeScale_X = 1f;
					sleekImageTexture9.sizeScale_Y = sleekImageTexture6.positionScale_Y;
					OV_PlayerDashboardInformationUI.mapDynamicContainer.add(sleekImageTexture9);
					SleekImageTexture sleekImageTexture10 = new SleekImageTexture(newTexture2);
					sleekImageTexture10.positionScale_Y = sleekImageTexture6.positionScale_Y + sleekImageTexture6.sizeScale_Y;
					sleekImageTexture10.sizeScale_X = 1f;
					sleekImageTexture10.sizeScale_Y = 1f - sleekImageTexture6.positionScale_Y - sleekImageTexture6.sizeScale_Y;
					OV_PlayerDashboardInformationUI.mapDynamicContainer.add(sleekImageTexture10);
				}
				Texture2D newTexture3 = PlayerDashboardInformationUI.icons.load<Texture2D>(<Module>.smethod_7<string>(758696872u));
				foreach (SteamPlayer steamPlayer in Provider.clients)
				{
					if (!(steamPlayer.model == null))
					{
						PlayerQuests quests = steamPlayer.player.quests;
						if ((MiscOptions.ShowPlayersOnMap || steamPlayer.playerID.steamID == Provider.client || quests.isMemberOfSameGroupAs(Player.player)) && quests.isMarkerPlaced)
						{
							SleekImageTexture sleekImageTexture11 = new SleekImageTexture(newTexture3);
							sleekImageTexture11.positionScale_X = quests.markerPosition.x / (float)(Level.size - Level.border * 2) + 0.5f;
							sleekImageTexture11.positionScale_Y = 0.5f - quests.markerPosition.z / (float)(Level.size - Level.border * 2);
							sleekImageTexture11.positionOffset_X = -10;
							sleekImageTexture11.positionOffset_Y = -10;
							sleekImageTexture11.sizeOffset_X = 20;
							sleekImageTexture11.sizeOffset_Y = 20;
							sleekImageTexture11.backgroundColor = steamPlayer.markerColor;
							if (!string.IsNullOrEmpty(steamPlayer.playerID.nickName))
							{
								sleekImageTexture11.addLabel(steamPlayer.playerID.nickName, ESleekSide.RIGHT);
							}
							else
							{
								sleekImageTexture11.addLabel(steamPlayer.playerID.characterName, ESleekSide.RIGHT);
							}
							OV_PlayerDashboardInformationUI.mapDynamicContainer.add(sleekImageTexture11);
						}
					}
				}
				bool areSpecStatsVisible = Player.player.look.areSpecStatsVisible;
				for (int i = 0; i < Provider.clients.Count; i++)
				{
					SteamPlayer steamPlayer2 = Provider.clients[i];
					if (steamPlayer2.model != null && steamPlayer2.playerID.steamID != Provider.client)
					{
						bool flag = steamPlayer2.player.quests.isMemberOfSameGroupAs(Player.player);
						if (MiscOptions.ShowPlayersOnMap || areSpecStatsVisible || flag)
						{
							SleekImageTexture sleekImageTexture12 = new SleekImageTexture();
							sleekImageTexture12.positionOffset_X = -10;
							sleekImageTexture12.positionOffset_Y = -10;
							sleekImageTexture12.positionScale_X = steamPlayer2.player.transform.position.x / (float)(Level.size - Level.border * 2) + 0.5f;
							sleekImageTexture12.positionScale_Y = 0.5f - steamPlayer2.player.transform.position.z / (float)(Level.size - Level.border * 2);
							sleekImageTexture12.sizeOffset_X = 20;
							sleekImageTexture12.sizeOffset_Y = 20;
							if (!OptionsSettings.streamer)
							{
								sleekImageTexture12.texture = Provider.provider.communityService.getIcon(steamPlayer2.playerID.steamID, false);
							}
							if (!string.IsNullOrEmpty(steamPlayer2.playerID.nickName))
							{
								sleekImageTexture12.addLabel(steamPlayer2.playerID.nickName, ESleekSide.RIGHT);
							}
							else
							{
								sleekImageTexture12.addLabel(steamPlayer2.playerID.characterName, ESleekSide.RIGHT);
							}
							sleekImageTexture12.shouldDestroyTexture = true;
							OV_PlayerDashboardInformationUI.mapDynamicContainer.add(sleekImageTexture12);
						}
					}
				}
				if (Player.player != null)
				{
					SleekImageTexture sleekImageTexture13 = new SleekImageTexture();
					sleekImageTexture13.positionOffset_X = -10;
					sleekImageTexture13.positionOffset_Y = -10;
					sleekImageTexture13.positionScale_X = Player.player.transform.position.x / (float)(Level.size - Level.border * 2) + 0.5f;
					sleekImageTexture13.positionScale_Y = 0.5f - Player.player.transform.position.z / (float)(Level.size - Level.border * 2);
					sleekImageTexture13.sizeOffset_X = 20;
					sleekImageTexture13.sizeOffset_Y = 20;
					sleekImageTexture13.isAngled = true;
					sleekImageTexture13.angle = Player.player.transform.rotation.eulerAngles.y;
					sleekImageTexture13.texture = PlayerDashboardInformationUI.icons.load<Texture2D>(<Module>.smethod_4<string>(280019277u));
					sleekImageTexture13.backgroundTint = ESleekTint.FOREGROUND;
					if (string.IsNullOrEmpty(Characters.active.nick))
					{
						sleekImageTexture13.addLabel(Characters.active.name, ESleekSide.RIGHT);
					}
					else
					{
						sleekImageTexture13.addLabel(Characters.active.nick, ESleekSide.RIGHT);
					}
					OV_PlayerDashboardInformationUI.mapDynamicContainer.add(sleekImageTexture13);
				}
			}
		}

		// Token: 0x060001CF RID: 463 RVA: 0x000036F7 File Offset: 0x000018F7
		MethodInfo method_0(string string_0, BindingFlags bindingFlags_0)
		{
			return base.GetMethod(string_0, bindingFlags_0);
		}

		// Token: 0x040001BB RID: 443
		public static bool WasGPSEnabled;

		// Token: 0x040001BC RID: 444
		public static bool WasEnabled;

		// Token: 0x040001BD RID: 445
		public static MethodInfo RefreshStaticMap = typeof(PlayerDashboardInformationUI).method_0(<Module>.smethod_5<string>(1184161668u), BindingFlags.Static | BindingFlags.NonPublic);

		// Token: 0x040001BE RID: 446
		public static FieldInfo DynamicContainerInfo = typeof(PlayerDashboardInformationUI).GetField(<Module>.smethod_6<string>(2771572126u), ReflectionVariables.PrivateStatic);
	}
}
