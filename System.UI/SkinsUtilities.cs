﻿using System;
using System.Collections.Generic;
using SDG.Provider;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200009D RID: 157
	public static class SkinsUtilities
	{
		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000254 RID: 596 RVA: 0x000049A8 File Offset: 0x00002BA8
		private static HumanClothes CharacterClothes
		{
			get
			{
				return OptimizationVariables.MainPlayer.clothing.characterClothes;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000255 RID: 597 RVA: 0x000049B9 File Offset: 0x00002BB9
		private static HumanClothes FirstClothes
		{
			get
			{
				return OptimizationVariables.MainPlayer.clothing.firstClothes;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000256 RID: 598 RVA: 0x000049CA File Offset: 0x00002BCA
		private static HumanClothes ThirdClothes
		{
			get
			{
				return OptimizationVariables.MainPlayer.clothing.thirdClothes;
			}
		}

		// Token: 0x06000257 RID: 599 RVA: 0x00015DC8 File Offset: 0x00013FC8
		public static void Apply(Skin skin, ESkinType skinType)
		{
			if (skinType == ESkinType.WEAPONS)
			{
				Dictionary<ushort, int> itemSkins = OptimizationVariables.MainPlayer.channel.owner.itemSkins;
				if (itemSkins == null)
				{
					return;
				}
				ushort inventoryItemID = Provider.provider.economyService.getInventoryItemID(skin.ID);
				SkinOptions.SkinConfig.WeaponSkins.Clear();
				int num;
				if (itemSkins.TryGetValue(inventoryItemID, out num))
				{
					itemSkins[inventoryItemID] = skin.ID;
				}
				else
				{
					itemSkins.Add(inventoryItemID, skin.ID);
				}
				OptimizationVariables.MainPlayer.equipment.applySkinVisual();
				OptimizationVariables.MainPlayer.equipment.applyMythicVisual();
				using (Dictionary<ushort, int>.Enumerator enumerator = itemSkins.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<ushort, int> keyValuePair = enumerator.Current;
						SkinOptions.SkinConfig.WeaponSkins.Add(new WeaponSave(keyValuePair.Key, keyValuePair.Value));
					}
					return;
				}
			}
			SkinsUtilities.ApplyClothing(skin, skinType);
		}

		// Token: 0x06000258 RID: 600 RVA: 0x00015EC8 File Offset: 0x000140C8
		private static void ApplyClothing(Skin skin, ESkinType type)
		{
			switch (type)
			{
			case ESkinType.SHIRTS:
				SkinsUtilities.CharacterClothes.visualShirt = skin.ID;
				SkinsUtilities.FirstClothes.visualShirt = skin.ID;
				SkinsUtilities.ThirdClothes.visualShirt = skin.ID;
				SkinOptions.SkinConfig.ShirtID = skin.ID;
				break;
			case ESkinType.PANTS:
				SkinsUtilities.CharacterClothes.visualPants = skin.ID;
				SkinsUtilities.FirstClothes.visualPants = skin.ID;
				SkinsUtilities.ThirdClothes.visualPants = skin.ID;
				SkinOptions.SkinConfig.PantsID = skin.ID;
				break;
			case ESkinType.BACKPACKS:
				SkinsUtilities.CharacterClothes.visualBackpack = skin.ID;
				SkinsUtilities.FirstClothes.visualBackpack = skin.ID;
				SkinsUtilities.ThirdClothes.visualBackpack = skin.ID;
				SkinOptions.SkinConfig.BackpackID = skin.ID;
				break;
			case ESkinType.VESTS:
				SkinsUtilities.CharacterClothes.visualVest = skin.ID;
				SkinsUtilities.FirstClothes.visualVest = skin.ID;
				SkinsUtilities.ThirdClothes.visualVest = skin.ID;
				SkinOptions.SkinConfig.VestID = skin.ID;
				break;
			case ESkinType.HATS:
				SkinsUtilities.CharacterClothes.visualHat = skin.ID;
				SkinsUtilities.FirstClothes.visualHat = skin.ID;
				SkinsUtilities.ThirdClothes.visualHat = skin.ID;
				SkinOptions.SkinConfig.HatID = skin.ID;
				break;
			case ESkinType.MASKS:
				SkinsUtilities.CharacterClothes.visualMask = skin.ID;
				SkinsUtilities.FirstClothes.visualMask = skin.ID;
				SkinsUtilities.ThirdClothes.visualMask = skin.ID;
				SkinOptions.SkinConfig.MaskID = skin.ID;
				break;
			case ESkinType.GLASSES:
				SkinsUtilities.CharacterClothes.visualGlasses = skin.ID;
				SkinsUtilities.FirstClothes.visualGlasses = skin.ID;
				SkinsUtilities.ThirdClothes.visualGlasses = skin.ID;
				SkinOptions.SkinConfig.GlassesID = skin.ID;
				break;
			}
			SkinsUtilities.CharacterClothes.apply();
			SkinsUtilities.FirstClothes.apply();
			SkinsUtilities.ThirdClothes.apply();
		}

		// Token: 0x06000259 RID: 601 RVA: 0x000160F8 File Offset: 0x000142F8
		public static void ApplyFromConfig()
		{
			Dictionary<ushort, int> dictionary = new Dictionary<ushort, int>();
			foreach (WeaponSave weaponSave in SkinOptions.SkinConfig.WeaponSkins)
			{
				dictionary[weaponSave.WeaponID] = weaponSave.SkinID;
			}
			OptimizationVariables.MainPlayer.channel.owner.itemSkins = dictionary;
			if (SkinOptions.SkinConfig.ShirtID != 0)
			{
				SkinsUtilities.CharacterClothes.visualShirt = SkinOptions.SkinConfig.ShirtID;
				SkinsUtilities.FirstClothes.visualShirt = SkinOptions.SkinConfig.ShirtID;
				SkinsUtilities.ThirdClothes.visualShirt = SkinOptions.SkinConfig.ShirtID;
			}
			if (SkinOptions.SkinConfig.PantsID != 0)
			{
				SkinsUtilities.CharacterClothes.visualPants = SkinOptions.SkinConfig.PantsID;
				SkinsUtilities.FirstClothes.visualPants = SkinOptions.SkinConfig.PantsID;
				SkinsUtilities.ThirdClothes.visualPants = SkinOptions.SkinConfig.PantsID;
			}
			if (SkinOptions.SkinConfig.BackpackID != 0)
			{
				SkinsUtilities.CharacterClothes.visualBackpack = SkinOptions.SkinConfig.BackpackID;
				SkinsUtilities.FirstClothes.visualBackpack = SkinOptions.SkinConfig.BackpackID;
				SkinsUtilities.ThirdClothes.visualBackpack = SkinOptions.SkinConfig.BackpackID;
			}
			if (SkinOptions.SkinConfig.VestID != 0)
			{
				SkinsUtilities.CharacterClothes.visualVest = SkinOptions.SkinConfig.VestID;
				SkinsUtilities.FirstClothes.visualVest = SkinOptions.SkinConfig.VestID;
				SkinsUtilities.ThirdClothes.visualVest = SkinOptions.SkinConfig.VestID;
			}
			if (SkinOptions.SkinConfig.HatID != 0)
			{
				SkinsUtilities.CharacterClothes.visualHat = SkinOptions.SkinConfig.HatID;
				SkinsUtilities.FirstClothes.visualHat = SkinOptions.SkinConfig.HatID;
				SkinsUtilities.ThirdClothes.visualHat = SkinOptions.SkinConfig.HatID;
			}
			if (SkinOptions.SkinConfig.MaskID != 0)
			{
				SkinsUtilities.CharacterClothes.visualMask = SkinOptions.SkinConfig.MaskID;
				SkinsUtilities.FirstClothes.visualMask = SkinOptions.SkinConfig.MaskID;
				SkinsUtilities.ThirdClothes.visualMask = SkinOptions.SkinConfig.MaskID;
			}
			if (SkinOptions.SkinConfig.GlassesID != 0)
			{
				SkinsUtilities.CharacterClothes.visualGlasses = SkinOptions.SkinConfig.GlassesID;
				SkinsUtilities.FirstClothes.visualGlasses = SkinOptions.SkinConfig.GlassesID;
				SkinsUtilities.ThirdClothes.visualGlasses = SkinOptions.SkinConfig.GlassesID;
			}
			SkinsUtilities.CharacterClothes.apply();
			SkinsUtilities.FirstClothes.apply();
			SkinsUtilities.ThirdClothes.apply();
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0001638C File Offset: 0x0001458C
		public static void DrawSkins(SkinOptionList OptionList)
		{
			Prefab.SectionTabButton(OptionList.Type.ToString(), delegate
			{
				GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
				GUILayout.Space(60f);
				SkinsUtilities.SearchString = Prefab.TextField(SkinsUtilities.SearchString, <Module>.smethod_6<string>(107118246u), 480f);
				GUILayout.EndHorizontal();
				Rect area = new Rect(70f, 40f, 540f, 395f);
				string title = OptionList.Type.ToString();
				Prefab.ScrollView(area, title, ref SkinsUtilities.ScrollPos, new System.Action(base.method_0), 20);
			}, 0f, 20);
		}

		// Token: 0x0600025B RID: 603 RVA: 0x000163D4 File Offset: 0x000145D4
		public static void RefreshEconInfo()
		{
			if (SkinOptions.SkinWeapons.Skins.Count > 5)
			{
				return;
			}
			foreach (UnturnedEconInfo unturnedEconInfo in TempSteamworksEconomy.econInfo)
			{
				if (unturnedEconInfo.type.Contains(<Module>.smethod_5<string>(99954032u)))
				{
					SkinOptions.SkinWeapons.Skins.Add(new Skin(unturnedEconInfo.name, unturnedEconInfo.itemdefid));
				}
				if (unturnedEconInfo.type.Contains(<Module>.smethod_6<string>(3859026061u)))
				{
					SkinOptions.SkinClothesShirts.Skins.Add(new Skin(unturnedEconInfo.name, unturnedEconInfo.itemdefid));
				}
				if (unturnedEconInfo.type.Contains(<Module>.smethod_6<string>(3476062002u)))
				{
					SkinOptions.SkinClothesPants.Skins.Add(new Skin(unturnedEconInfo.name, unturnedEconInfo.itemdefid));
				}
				if (unturnedEconInfo.type.Contains(<Module>.smethod_5<string>(2598098632u)))
				{
					SkinOptions.SkinClothesBackpack.Skins.Add(new Skin(unturnedEconInfo.name, unturnedEconInfo.itemdefid));
				}
				if (unturnedEconInfo.type.Contains(<Module>.smethod_7<string>(150324477u)))
				{
					SkinOptions.SkinClothesVest.Skins.Add(new Skin(unturnedEconInfo.name, unturnedEconInfo.itemdefid));
				}
				if (unturnedEconInfo.type.Contains(<Module>.smethod_7<string>(284087151u)))
				{
					SkinOptions.SkinClothesHats.Skins.Add(new Skin(unturnedEconInfo.name, unturnedEconInfo.itemdefid));
				}
				if (unturnedEconInfo.type.Contains(<Module>.smethod_8<string>(4222934264u)))
				{
					SkinOptions.SkinClothesMask.Skins.Add(new Skin(unturnedEconInfo.name, unturnedEconInfo.itemdefid));
				}
				if (unturnedEconInfo.type.Contains(<Module>.smethod_5<string>(887790289u)))
				{
					SkinOptions.SkinClothesGlasses.Skins.Add(new Skin(unturnedEconInfo.name, unturnedEconInfo.itemdefid));
				}
			}
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00016608 File Offset: 0x00014808
		public static void incrementStatTrackerValue(ushort itemID, int newValue)
		{
			if (Player.player == null)
			{
				return;
			}
			SteamPlayer owner = Player.player.channel.owner;
			if (owner == null)
			{
				return;
			}
			int num;
			if (!owner.getItemSkinItemDefID(itemID, out num))
			{
				return;
			}
			string tags;
			string dynamic_props;
			if (!owner.getTagsAndDynamicPropsForItem(num, out tags, out dynamic_props))
			{
				return;
			}
			DynamicEconDetails dynamicEconDetails = new DynamicEconDetails(tags, dynamic_props);
			EStatTrackerType type;
			int num2;
			if (!dynamicEconDetails.getStatTrackerValue(out type, out num2))
			{
				return;
			}
			if (!owner.modifiedItems.Contains(itemID))
			{
				owner.modifiedItems.Add(itemID);
			}
			int i = 0;
			while (i < owner.skinItems.Length)
			{
				if (owner.skinItems[i] != num)
				{
					i++;
				}
				else
				{
					if (i < owner.skinDynamicProps.Length)
					{
						owner.skinDynamicProps[i] = dynamicEconDetails.getPredictedDynamicPropsJsonForStatTracker(type, newValue);
						return;
					}
					return;
				}
			}
		}

		// Token: 0x0400022C RID: 556
		public static Vector2 ScrollPos;

		// Token: 0x0400022D RID: 557
		private static string SearchString = string.Empty;
	}
}
