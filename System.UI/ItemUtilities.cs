using System;
using System.Collections.Generic;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200004F RID: 79
	public static class ItemUtilities
	{
		// Token: 0x06000137 RID: 311 RVA: 0x0000E530 File Offset: 0x0000C730
		public static bool Whitelisted(ItemAsset asset, ItemOptionList OptionList)
		{
			return (OptionList.ItemfilterCustom && OptionList.AddedItems.Contains(asset.id)) || (OptionList.ItemfilterGun && asset is ItemGunAsset) || (OptionList.ItemfilterAmmo && asset is ItemMagazineAsset) || (OptionList.ItemfilterMedical && asset is ItemMedicalAsset) || (OptionList.ItemfilterFoodAndWater && (asset is ItemFoodAsset || asset is ItemWaterAsset)) || (OptionList.ItemfilterBackpack && asset is ItemBackpackAsset) || (OptionList.ItemfilterCharges && asset is ItemChargeAsset) || (OptionList.ItemfilterFuel && asset is ItemFuelAsset) || (OptionList.ItemfilterClothing && asset is ItemClothingAsset);
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000E5E8 File Offset: 0x0000C7E8
		public static void DrawItemButton(ItemAsset asset, HashSet<ushort> AddedItems)
		{
			string text = asset.itemName;
			if (asset.itemName.Length > 60)
			{
				text = asset.itemName.Substring(0, 60) + "..";
			}
			if (Prefab.Button(text, 490f, 25f))
			{
				if (!AddedItems.Contains(asset.id))
				{
					AddedItems.Add(asset.id);
				}
				else
				{
					AddedItems.Remove(asset.id);
				}
			}
			GUILayout.Space(3f);
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000E66C File Offset: 0x0000C86C
		public static void DrawFilterTab(ItemOptionList OptionList)
		{
			Prefab.SectionTabButton("ФИЛЬТР ПРЕДМЕТОВ", delegate
			{
				Prefab.Toggle("Оружия", ref OptionList.ItemfilterGun);
				Prefab.Toggle("Патроны", ref OptionList.ItemfilterAmmo);
				Prefab.Toggle("Медицина", ref OptionList.ItemfilterMedical);
				Prefab.Toggle("Рюкзаки", ref OptionList.ItemfilterBackpack);
				Prefab.Toggle("Взрывчатка", ref OptionList.ItemfilterCharges);
				Prefab.Toggle("Топливо", ref OptionList.ItemfilterFuel);
				Prefab.Toggle("Одежда", ref OptionList.ItemfilterClothing);
				Prefab.Toggle("Еда и Вода", ref OptionList.ItemfilterFoodAndWater);
				Prefab.Toggle("Включить свой фильтр", ref OptionList.ItemfilterCustom);
				if (OptionList.ItemfilterCustom)
				{
					GUILayout.Space(5f);
					Prefab.SectionTabButton("СВОЙ ФИЛЬТР", new System.Action(base.method_0), 0f, 20);
				}
			}, 0f, 20);
		}
	}
}
