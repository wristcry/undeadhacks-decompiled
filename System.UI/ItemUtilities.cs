using System;
using System.Collections.Generic;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200004F RID: 79
	public static class ItemUtilities
	{
		// Token: 0x06000137 RID: 311 RVA: 0x0000E3C0 File Offset: 0x0000C5C0
		public static bool Whitelisted(ItemAsset asset, ItemOptionList OptionList)
		{
			return (OptionList.ItemfilterCustom && OptionList.AddedItems.Contains(asset.id)) || (OptionList.ItemfilterGun && asset is ItemGunAsset) || (OptionList.ItemfilterAmmo && asset is ItemMagazineAsset) || (OptionList.ItemfilterMedical && asset is ItemMedicalAsset) || (OptionList.ItemfilterFoodAndWater && (asset is ItemFoodAsset || asset is ItemWaterAsset)) || (OptionList.ItemfilterBackpack && asset is ItemBackpackAsset) || (OptionList.ItemfilterCharges && asset is ItemChargeAsset) || (OptionList.ItemfilterFuel && asset is ItemFuelAsset) || (OptionList.ItemfilterClothing && asset is ItemClothingAsset);
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000E478 File Offset: 0x0000C678
		public static void DrawItemButton(ItemAsset asset, HashSet<ushort> AddedItems)
		{
			string text = asset.itemName;
			if (asset.itemName.Length > 60)
			{
				text = asset.itemName.Substring(0, 60) + <Module>.smethod_8<string>(250574255u);
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

		// Token: 0x06000139 RID: 313 RVA: 0x0000E500 File Offset: 0x0000C700
		public static void DrawFilterTab(ItemOptionList OptionList)
		{
			Prefab.SectionTabButton(<Module>.smethod_8<string>(2620863929u), delegate
			{
				Prefab.Toggle(<Module>.smethod_4<string>(2573182927u), ref OptionList.ItemfilterGun);
				Prefab.Toggle(<Module>.smethod_6<string>(1832548952u), ref OptionList.ItemfilterAmmo);
				Prefab.Toggle(<Module>.smethod_6<string>(3446767835u), ref OptionList.ItemfilterMedical);
				Prefab.Toggle(<Module>.smethod_4<string>(3581306553u), ref OptionList.ItemfilterBackpack);
				Prefab.Toggle(<Module>.smethod_6<string>(2651990541u), ref OptionList.ItemfilterCharges);
				Prefab.Toggle(<Module>.smethod_5<string>(2721962824u), ref OptionList.ItemfilterFuel);
				Prefab.Toggle(<Module>.smethod_5<string>(761840021u), ref OptionList.ItemfilterClothing);
				Prefab.Toggle(<Module>.smethod_4<string>(3480751797u), ref OptionList.ItemfilterFoodAndWater);
				Prefab.Toggle(<Module>.smethod_5<string>(3682827787u), ref OptionList.ItemfilterCustom);
				if (OptionList.ItemfilterCustom)
				{
					GUILayout.Space(5f);
					Prefab.SectionTabButton(<Module>.smethod_8<string>(1527384733u), new System.Action(base.method_0), 0f, 20);
				}
			}, 0f, 20);
		}
	}
}
