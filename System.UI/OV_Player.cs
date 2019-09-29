using System;
using System.Reflection;
using SDG.Unturned;
using Steamworks;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200007A RID: 122
	public class OV_Player : MonoBehaviour
	{
		// Token: 0x060001C5 RID: 453 RVA: 0x00004508 File Offset: 0x00002708
		[Override(typeof(Player), "askScreenshot", BindingFlags.Instance | BindingFlags.Public, 0)]
		public void OV_askScreenshot(CSteamID steamid)
		{
			if (Player.player.channel.checkServer(steamid))
			{
				base.StartCoroutine(PlayerCoroutines.TakeScreenshot());
			}
		}
	}
}
