using System;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200007F RID: 127
	public static class OV_PlayerPauseUI
	{
		// Token: 0x060001E4 RID: 484 RVA: 0x000125B8 File Offset: 0x000107B8
		[Override(typeof(PlayerPauseUI), "onClickedExitButton", BindingFlags.Static | BindingFlags.NonPublic, 0)]
		public static void OV_onClickedExitButton(SleekButton button)
		{
			if (Provider.isServer || !Provider.isPvP || Provider.clients.Count <= 1 || (Player.player.movement.isSafe && Player.player.movement.isSafeInfo.noWeapons) || Player.player.life.isDead || Time.realtimeSinceStartup - PlayerPauseUI.lastLeave >= Provider.modeConfigData.Gameplay.Timer_Exit || (MiscOptions.Disconnect && !MiscOptions.PanicMode))
			{
				Provider.disconnect();
			}
		}
	}
}
