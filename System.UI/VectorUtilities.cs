using System;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x020000AD RID: 173
	public static class VectorUtilities
	{
		// Token: 0x0600027B RID: 635 RVA: 0x00004A8A File Offset: 0x00002C8A
		public static float GetDistance(Vector3 point)
		{
			return Vector3.Distance(OptimizationVariables.MainCam.transform.position, point);
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00016F60 File Offset: 0x00015160
		public static float FOVRadius(float fov)
		{
			float fieldOfView = OptimizationVariables.MainCam.fieldOfView;
			if (GraphicsSettings.scopeQuality != EGraphicQuality.OFF)
			{
				UseableGun useableGun = Player.player.equipment.useable as UseableGun;
				if (useableGun && useableGun.isAiming && Player.player.look.scopeCamera.enabled)
				{
					fieldOfView = Player.player.look.scopeCamera.fieldOfView;
				}
			}
			return (float)(Math.Tan((double)fov * 0.017453292519943295 / 2.0) / Math.Tan((double)fieldOfView * 0.017453292519943295 / 2.0) * (double)Screen.height);
		}

		// Token: 0x0600027D RID: 637 RVA: 0x00017010 File Offset: 0x00015210
		public static float GetAngleDelta(Vector3 mainPos, Vector3 forward, Vector3 target)
		{
			Vector3 lhs = Vector3.Normalize(target - mainPos);
			return (float)Math.Atan2((double)Vector3.Cross(lhs, forward).magnitude, (double)Vector3.Dot(lhs, forward)) * 57.29578f;
		}

		// Token: 0x0600027E RID: 638 RVA: 0x00004AA1 File Offset: 0x00002CA1
		public static Ray GetAimRay(Vector3 origin, Vector3 pos)
		{
			return new Ray(pos, Vector3.Normalize(pos - origin));
		}

		// Token: 0x04000249 RID: 585
		private const double DegRad = 0.017453292519943295;
	}
}
