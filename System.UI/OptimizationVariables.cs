using System;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000068 RID: 104
	public static class OptimizationVariables
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600018C RID: 396 RVA: 0x000042C1 File Offset: 0x000024C1
		public static Player MainPlayer
		{
			get
			{
				return Player.player;
			}
		}

		// Token: 0x04000193 RID: 403
		public static Camera MainCam;
	}
}
