using System;
using System.Collections.Generic;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200004E RID: 78
	[Component]
	public class ItemsComponent : MonoBehaviour
	{
		// Token: 0x06000133 RID: 307 RVA: 0x0000E360 File Offset: 0x0000C560
		public static void RefreshItems()
		{
			ItemsComponent.items.Clear();
			for (ushort num = 0; num < 65535; num += 1)
			{
				ItemAsset itemAsset = (ItemAsset)Assets.find(EAssetType.ITEM, num);
				if (!string.IsNullOrEmpty((itemAsset != null) ? itemAsset.itemName : null) && !ItemsComponent.items.Contains(itemAsset))
				{
					ItemsComponent.items.Add(itemAsset);
				}
			}
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00003F4D File Offset: 0x0000214D
		public void Start()
		{
			base.StartCoroutine(ItemCoroutines.PickupItems());
			base.StartCoroutine(ItemCoroutines.PickupFarm());
			base.StartCoroutine(ItemCoroutines.PickupForage());
		}

		// Token: 0x0400011E RID: 286
		public static List<ItemAsset> items = new List<ItemAsset>();
	}
}
