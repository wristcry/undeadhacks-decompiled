using System;
using System.Collections;

namespace UndeadHacks
{
	// Token: 0x02000048 RID: 72
	public static class ItemCoroutines
	{
		// Token: 0x0600011C RID: 284 RVA: 0x00003EC6 File Offset: 0x000020C6
		public static IEnumerator PickupItems()
		{
			return new ItemCoroutines.<PickupItems>d__0(0);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00003ECE File Offset: 0x000020CE
		public static IEnumerator PickupFarm()
		{
			return new ItemCoroutines.<PickupFarm>d__1(0);
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00003ED6 File Offset: 0x000020D6
		public static IEnumerator PickupForage()
		{
			return new ItemCoroutines.<PickupForage>d__2(0);
		}
	}
}
