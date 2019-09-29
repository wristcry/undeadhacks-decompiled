using System;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x020000A0 RID: 160
	[Component]
	public class SpectatorComponent : MonoBehaviour
	{
		// Token: 0x0600025F RID: 607 RVA: 0x0001659C File Offset: 0x0001479C
		public void FixedUpdate()
		{
			if (!DrawUtilities.ShouldRun())
			{
				return;
			}
			if (MiscOptions.SpectatedPlayer != null && !PlayerCoroutines.IsSpying)
			{
				Player.player.look.isOrbiting = true;
				Player.player.look.orbitPosition = MiscOptions.SpectatedPlayer.transform.position - Player.player.transform.position;
				Player.player.look.orbitPosition += new Vector3(0f, 3f, 0f);
				return;
			}
			Player.player.look.isOrbiting = MiscOptions.Freecam;
		}
	}
}
