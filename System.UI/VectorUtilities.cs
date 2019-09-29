using System;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x020000AD RID: 173
	public static class VectorUtilities
	{
		// Token: 0x0600027E RID: 638 RVA: 0x00004A5A File Offset: 0x00002C5A
		public static float GetDistance(Vector3 point)
		{
			return Vector3.Distance(OptimizationVariables.MainCam.transform.position, point);
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0001722C File Offset: 0x0001542C
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

		// Token: 0x06000280 RID: 640 RVA: 0x000172DC File Offset: 0x000154DC
		public static float GetAngleDelta(Vector3 mainPos, Vector3 forward, Vector3 target)
		{
			Vector3 lhs = Vector3.Normalize(target - mainPos);
			return (float)Math.Atan2((double)Vector3.Cross(lhs, forward).magnitude, (double)Vector3.Dot(lhs, forward)) * 57.29578f;
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00004A71 File Offset: 0x00002C71
		public static Ray GetAimRay(Vector3 origin, Vector3 pos)
		{
			return new Ray(pos, Vector3.Normalize(pos - origin));
		}

		// Token: 0x04000249 RID: 585
		private const double DegRad = 0.017453292519943295;
	}
}
