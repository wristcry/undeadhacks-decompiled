using System;
using System.Reflection;
using SDG.Unturned;

namespace UndeadHacks
{
	// Token: 0x02000017 RID: 23
	public class OV_VendorUI
	{
		// Token: 0x0600006A RID: 106 RVA: 0x00007D58 File Offset: 0x00005F58
		[Override(typeof(PlayerNPCVendorUI), "onClickedBuyingButton", BindingFlags.Static | BindingFlags.NonPublic, 0)]
		public static void onClickedBuyingButton(SleekButton button)
		{
			if (MiscOptions.FastSell)
			{
				for (int i = 0; i < MiscOptions.FastSellCount; i++)
				{
					OverrideUtilities.CallOriginal(null, new object[]
					{
						button
					});
				}
				return;
			}
			OverrideUtilities.CallOriginal(null, new object[]
			{
				button
			});
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00007DA0 File Offset: 0x00005FA0
		[Override(typeof(PlayerNPCVendorUI), "onClickedSellingButton", BindingFlags.Static | BindingFlags.NonPublic, 0)]
		public static void onClickedSellingButton(SleekButton button)
		{
			if (MiscOptions.FastBuy)
			{
				for (int i = 0; i < MiscOptions.FastSellCount; i++)
				{
					OverrideUtilities.CallOriginal(null, new object[]
					{
						button
					});
				}
				return;
			}
			OverrideUtilities.CallOriginal(null, new object[]
			{
				button
			});
		}
	}
}
