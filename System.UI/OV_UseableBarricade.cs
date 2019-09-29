using System;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200001B RID: 27
	public class OV_UseableBarricade
	{
		// Token: 0x06000073 RID: 115 RVA: 0x00008488 File Offset: 0x00006688
		[Override(typeof(UseableBarricade), "checkSpace", BindingFlags.Instance | BindingFlags.NonPublic, 0)]
		public bool OV_checkSpace()
		{
			if (!MiscOptions.BuildObs || PlayerCoroutines.IsSpying)
			{
				return (bool)OverrideUtilities.CallOriginal(this, Array.Empty<object>());
			}
			OverrideUtilities.CallOriginal(this, Array.Empty<object>());
			if ((Vector3)OV_UseableBarricade.pointField.GetValue(this) != Vector3.zero && !MiscOptions.Freecam)
			{
				if (MiscOptions.epos)
				{
					OV_UseableBarricade.pointField.SetValue(this, (Vector3)OV_UseableBarricade.pointField.GetValue(this) + MiscOptions.pos);
				}
				return true;
			}
			RaycastHit raycastHit;
			if (Physics.Raycast(new Ray(OptimizationVariables.MainCam.transform.position, OptimizationVariables.MainCam.transform.forward), out raycastHit, 20f, RayMasks.DAMAGE_CLIENT))
			{
				Vector3 vector = raycastHit.point;
				if (MiscOptions.epos)
				{
					vector += MiscOptions.pos;
				}
				OV_UseableBarricade.pointField.SetValue(this, vector);
				return true;
			}
			Vector3 vector2 = OptimizationVariables.MainCam.transform.position + OptimizationVariables.MainCam.transform.forward * 7f;
			if (MiscOptions.epos)
			{
				vector2 += MiscOptions.pos;
			}
			OV_UseableBarricade.pointField.SetValue(this, vector2);
			return true;
		}

		// Token: 0x04000052 RID: 82
		private static FieldInfo pointField = typeof(UseableBarricade).GetField(<Module>.smethod_4<string>(4098523939u), ReflectionVariables.PrivateInstance);
	}
}
