using System;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000076 RID: 118
	public static class OV_DamageTool
	{
		// Token: 0x060001BB RID: 443 RVA: 0x00010E84 File Offset: 0x0000F084
		[Override(typeof(DamageTool), "raycast", BindingFlags.Static | BindingFlags.Public, 1)]
		public static RaycastInfo OV_raycast(Ray ray, float range, int mask, Player ignorePlayer)
		{
			OverrideType ovtype = OV_DamageTool.OVType;
			if (ovtype == OverrideType.Extended)
			{
				RaycastInfo raycastInfo = RaycastUtilities.GenerateOriginalRaycast(ray, Mathf.Max(20f, range), mask, ignorePlayer);
				float num = MiscOptions.ExtendRangeBypass ? range : Mathf.Max(5.5f, range);
				raycastInfo.point = ((Vector3.Distance(raycastInfo.point, ray.origin) > num) ? (ray.direction * num + ray.origin) : raycastInfo.point);
				return raycastInfo;
			}
			if (ovtype == OverrideType.SilentAimMelee)
			{
				RaycastInfo raycastInfo2;
				if (!RaycastUtilities.GenerateRaycast(out raycastInfo2) && !MiscOptions.ExtendMeleeRange)
				{
					raycastInfo2 = RaycastUtilities.GenerateOriginalRaycast(ray, range, mask, ignorePlayer);
				}
				float num2 = MiscOptions.ExtendRangeBypass ? range : Mathf.Max(5.5f, range);
				raycastInfo2.point = ((Vector3.Distance(raycastInfo2.point, ray.origin) > num2) ? (ray.direction * num2 + ray.origin) : raycastInfo2.point);
				return raycastInfo2;
			}
			return RaycastUtilities.GenerateOriginalRaycast(ray, range, mask, ignorePlayer);
		}

		// Token: 0x040001B7 RID: 439
		public static OverrideType OVType;
	}
}
