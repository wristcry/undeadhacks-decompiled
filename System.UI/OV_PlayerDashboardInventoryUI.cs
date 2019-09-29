using System;
using System.Collections.Generic;
using System.Reflection;
using SDG.Unturned;

namespace UndeadHacks
{
	// Token: 0x0200000E RID: 14
	public class OV_PlayerDashboardInventoryUI
	{
		// Token: 0x06000040 RID: 64 RVA: 0x00006744 File Offset: 0x00004944
		[Override(typeof(PlayerDashboardInventoryUI), "updateNearbyDrops", BindingFlags.Static | BindingFlags.NonPublic, 0)]
		public static void updateNearbyDrops()
		{
			if (MiscOptions.IncreaseNearbyItemDistance && !MiscOptions.PanicMode)
			{
				OV_PlayerDashboardInventoryUI.areaItems.clear();
				OV_PlayerDashboardInventoryUI.regionsInRadius.Clear();
				Regions.getRegionsInRadius(Player.player.look.aim.position, 20f, OV_PlayerDashboardInventoryUI.regionsInRadius);
				OV_PlayerDashboardInventoryUI.itemsInRadius.Clear();
				ItemManager.getItemsInRadius(Player.player.look.aim.position, 400f, OV_PlayerDashboardInventoryUI.regionsInRadius, OV_PlayerDashboardInventoryUI.itemsInRadius);
				if (OV_PlayerDashboardInventoryUI.itemsInRadius.Count > 0)
				{
					OV_PlayerDashboardInventoryUI.areaItems.resize(8, 0);
					byte b = 0;
					while ((int)b < OV_PlayerDashboardInventoryUI.itemsInRadius.Count && OV_PlayerDashboardInventoryUI.areaItems.getItemCount() < 200)
					{
						InteractableItem interactableItem = OV_PlayerDashboardInventoryUI.itemsInRadius[(int)b];
						if (interactableItem)
						{
							Item item = interactableItem.item;
							if (item != null)
							{
								while (!OV_PlayerDashboardInventoryUI.areaItems.tryAddItem(item))
								{
									if (OV_PlayerDashboardInventoryUI.areaItems.height >= 200)
									{
										goto IL_14E;
									}
									OV_PlayerDashboardInventoryUI.areaItems.resize(OV_PlayerDashboardInventoryUI.areaItems.width, OV_PlayerDashboardInventoryUI.areaItems.height + 1);
								}
								ItemJar item2 = OV_PlayerDashboardInventoryUI.areaItems.getItem(OV_PlayerDashboardInventoryUI.areaItems.getItemCount() - 1);
								item2.interactableItem = interactableItem;
								interactableItem.jar = item2;
							}
						}
						b += 1;
					}
					IL_14E:
					if (OV_PlayerDashboardInventoryUI.areaItems.height + 3 <= 200)
					{
						OV_PlayerDashboardInventoryUI.areaItems.resize(OV_PlayerDashboardInventoryUI.areaItems.width, OV_PlayerDashboardInventoryUI.areaItems.height + 3);
					}
				}
				else
				{
					OV_PlayerDashboardInventoryUI.areaItems.resize(8, 3);
				}
				Player.player.inventory.replaceItems(PlayerInventory.AREA, OV_PlayerDashboardInventoryUI.areaItems);
				SleekItems[] array = (SleekItems[])OV_PlayerDashboardInventoryUI.itemsfield.GetValue(null);
				array[(int)(PlayerInventory.AREA - PlayerInventory.SLOTS)].clear();
				array[(int)(PlayerInventory.AREA - PlayerInventory.SLOTS)].resize(OV_PlayerDashboardInventoryUI.areaItems.width, OV_PlayerDashboardInventoryUI.areaItems.height);
				for (int i = 0; i < (int)OV_PlayerDashboardInventoryUI.areaItems.getItemCount(); i++)
				{
					array[(int)(PlayerInventory.AREA - PlayerInventory.SLOTS)].addItem(OV_PlayerDashboardInventoryUI.areaItems.getItem((byte)i));
				}
				OV_PlayerDashboardInventoryUI.updateBoxAreasfield.Invoke(null, null);
				return;
			}
			OverrideUtilities.CallOriginal(null, null);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000036F7 File Offset: 0x000018F7
		MethodInfo method_0(string string_0, BindingFlags bindingFlags_0)
		{
			return base.GetMethod(string_0, bindingFlags_0);
		}

		// Token: 0x0400002D RID: 45
		private static Items areaItems = new Items(PlayerInventory.AREA);

		// Token: 0x0400002E RID: 46
		private static List<InteractableItem> itemsInRadius = new List<InteractableItem>();

		// Token: 0x0400002F RID: 47
		private static List<RegionCoordinate> regionsInRadius = new List<RegionCoordinate>(4);

		// Token: 0x04000030 RID: 48
		private static FieldInfo itemsfield = typeof(PlayerDashboardInventoryUI).GetField("items", BindingFlags.Static | BindingFlags.NonPublic);

		// Token: 0x04000031 RID: 49
		private static MethodInfo updateBoxAreasfield = typeof(PlayerDashboardInventoryUI).method_0("updateBoxAreas", BindingFlags.Static | BindingFlags.NonPublic);
	}
}
