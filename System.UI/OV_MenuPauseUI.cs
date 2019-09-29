using System;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000079 RID: 121
	public static class OV_MenuPauseUI
	{
		// Token: 0x060001C5 RID: 453 RVA: 0x000044FC File Offset: 0x000026FC
		[Override(typeof(MenuPauseUI), "onClickedExitButton", BindingFlags.Static | BindingFlags.NonPublic, 0)]
		public static void OV_onClickedExitButton(SleekButton button)
		{
			Application.Quit();
		}
	}
}
