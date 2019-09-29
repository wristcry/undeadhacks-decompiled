using System;
using System.Reflection;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000075 RID: 117
	public static class OV_Cursor
	{
		// Token: 0x060001BB RID: 443 RVA: 0x00004463 File Offset: 0x00002663
		[Override(typeof(Cursor), "set_lockState", BindingFlags.Static | BindingFlags.Public, 0)]
		public static void OV_set_lockState(CursorLockMode rMode)
		{
			if (MenuComponent.IsInMenu && !PlayerCoroutines.IsSpying && (rMode == CursorLockMode.Confined || rMode == CursorLockMode.Locked))
			{
				return;
			}
			OverrideUtilities.CallOriginal(null, new object[]
			{
				rMode
			});
		}
	}
}
