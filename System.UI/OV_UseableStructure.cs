using System;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200001C RID: 28
	public class OV_UseableStructure
	{
		// Token: 0x06000076 RID: 118 RVA: 0x00008524 File Offset: 0x00006724
		[Override(typeof(UseableStructure), "checkSpace", BindingFlags.Instance | BindingFlags.NonPublic, 0)]
		public bool OV_checkSpace()
		{
			if (!MiscOptions.BuildObs || PlayerCoroutines.IsSpying)
			{
				return (bool)OverrideUtilities.CallOriginal(this, Array.Empty<object>());
			}
			OverrideUtilities.CallOriginal(this, Array.Empty<object>());
			if ((Vector3)OV_UseableStructure.pointField.GetValue(this) != Vector3.zero && !MiscOptions.Freecam)
			{
				if (MiscOptions.epos)
				{
					OV_UseableStructure.pointField.SetValue(this, (Vector3)OV_UseableStructure.pointField.GetValue(this) + MiscOptions.pos);
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
				OV_UseableStructure.pointField.SetValue(this, vector);
				return true;
			}
			Vector3 vector2 = OptimizationVariables.MainCam.transform.position + OptimizationVariables.MainCam.transform.forward * 7f;
			if (MiscOptions.epos)
			{
				vector2 += MiscOptions.pos;
			}
			OV_UseableStructure.pointField.SetValue(this, vector2);
			return true;
		}

		// Token: 0x04000053 RID: 83
		public static FieldInfo pointField = typeof(UseableStructure).GetField(<Module>.smethod_6<string>(3915389440u), ReflectionVariables.PrivateInstance);
	}
}
