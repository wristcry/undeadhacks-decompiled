using System;
using System.Collections;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000012 RID: 18
	public static class AimbotCoroutines
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600004F RID: 79 RVA: 0x0000374A File Offset: 0x0000194A
		// (set) Token: 0x06000050 RID: 80 RVA: 0x0000375B File Offset: 0x0000195B
		public static float Pitch
		{
			get
			{
				return OptimizationVariables.MainPlayer.look.pitch;
			}
			set
			{
				AimbotCoroutines.PitchInfo.SetValue(OptimizationVariables.MainPlayer.look, value);
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00003777 File Offset: 0x00001977
		// (set) Token: 0x06000052 RID: 82 RVA: 0x00003788 File Offset: 0x00001988
		public static float Yaw
		{
			get
			{
				return OptimizationVariables.MainPlayer.look.yaw;
			}
			set
			{
				AimbotCoroutines.YawInfo.SetValue(OptimizationVariables.MainPlayer.look, value);
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000037A4 File Offset: 0x000019A4
		public static IEnumerator SetLockedObject()
		{
			return new AimbotCoroutines.<SetLockedObject>d__11(0);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000037AC File Offset: 0x000019AC
		public static IEnumerator AimToObject()
		{
			return new AimbotCoroutines.<AimToObject>d__12(0);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00006DE4 File Offset: 0x00004FE4
		public static void Aim(GameObject obj)
		{
			Vector3 aimPosition = AimbotCoroutines.GetAimPosition(obj.transform, <Module>.smethod_8<string>(629351294u));
			if (aimPosition == AimbotCoroutines.PiVector)
			{
				return;
			}
			Transform transform = OptimizationVariables.MainCam.transform;
			transform.LookAt(aimPosition);
			Vector3 eulerAngles = transform.eulerAngles;
			float num = eulerAngles.x;
			if (num <= 90f && num <= 270f)
			{
				num += 90f;
			}
			else if (num >= 270f && num <= 360f)
			{
				num -= 270f;
			}
			AimbotCoroutines.Pitch = num;
			AimbotCoroutines.Yaw = eulerAngles.y;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00006E74 File Offset: 0x00005074
		public static void SmoothAim(GameObject obj)
		{
			Vector3 aimPosition = AimbotCoroutines.GetAimPosition(obj.transform, <Module>.smethod_8<string>(629351294u));
			if (aimPosition == AimbotCoroutines.PiVector)
			{
				return;
			}
			Transform transform = OptimizationVariables.MainPlayer.transform;
			Transform transform2 = OptimizationVariables.MainCam.transform;
			float num = Time.deltaTime * AimbotOptions.AimSpeed;
			transform.rotation = Quaternion.Slerp(Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(aimPosition - transform.position), num), Quaternion.LookRotation(aimPosition - transform.position), num);
			transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
			transform2.localRotation = Quaternion.Slerp(Quaternion.RotateTowards(transform2.localRotation, Quaternion.LookRotation(aimPosition - transform2.position), num), Quaternion.LookRotation(aimPosition - transform2.position), num);
			float num2 = transform2.localRotation.eulerAngles.x;
			if (num2 <= 90f && num2 <= 270f)
			{
				num2 += 90f;
			}
			else if (num2 >= 270f && num2 <= 360f)
			{
				num2 -= 270f;
			}
			AimbotCoroutines.Pitch = num2;
			AimbotCoroutines.Yaw = transform.eulerAngles.y;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00006FC0 File Offset: 0x000051C0
		public static Vector3 GetAimPosition(Transform parent, string name)
		{
			Transform[] componentsInChildren = parent.GetComponentsInChildren<Transform>();
			if (componentsInChildren == null)
			{
				return AimbotCoroutines.PiVector;
			}
			foreach (Transform transform in componentsInChildren)
			{
				if (transform.name.Trim() == name)
				{
					return transform.position + new Vector3(0f, 0.4f, 0f);
				}
			}
			return AimbotCoroutines.PiVector;
		}

		// Token: 0x0400003B RID: 59
		public static Vector3 PiVector = new Vector3(0f, 3.14159274f, 0f);

		// Token: 0x0400003C RID: 60
		public static GameObject LockedObject;

		// Token: 0x0400003D RID: 61
		public static bool IsAiming;

		// Token: 0x0400003E RID: 62
		public static FieldInfo PitchInfo = typeof(PlayerLook).GetField(<Module>.smethod_6<string>(1806994675u), BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x0400003F RID: 63
		public static FieldInfo YawInfo = typeof(PlayerLook).GetField(<Module>.smethod_4<string>(1674905531u), BindingFlags.Instance | BindingFlags.NonPublic);
	}
}
