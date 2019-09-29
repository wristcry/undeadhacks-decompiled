using System;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000079 RID: 121
	public static class OV_MenuPauseUI
	{
		// Token: 0x060001C4 RID: 452 RVA: 0x00004501 File Offset: 0x00002701
		[Override(typeof(MenuPauseUI), "onClickedExitButton", BindingFlags.Static | BindingFlags.NonPublic, 0)]
		public static void OV_onClickedExitButton(SleekButton button)
		{
			Application.Quit();
		}
	}
}
