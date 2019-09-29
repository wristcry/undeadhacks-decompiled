using System;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x020000A0 RID: 160
	[Component]
	public class SpectatorComponent : MonoBehaviour
	{
		// Token: 0x06000262 RID: 610 RVA: 0x00016840 File Offset: 0x00014A40
		public void FixedUpdate()
		{
			if (!DrawUtilities.ShouldRun())
			{
				return;
			}
			if (MiscOptions.SpectatedPlayer != null && !PlayerCoroutines.IsSpying)
			{
				OptimizationVariables.MainPlayer.look.isOrbiting = true;
				OptimizationVariables.MainPlayer.look.orbitPosition = MiscOptions.SpectatedPlayer.transform.position - OptimizationVariables.MainPlayer.transform.position;
				OptimizationVariables.MainPlayer.look.orbitPosition += new Vector3(0f, 3f, 0f);
				return;
			}
			OptimizationVariables.MainPlayer.look.isOrbiting = MiscOptions.Freecam;
		}
	}
}
