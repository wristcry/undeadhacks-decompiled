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
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00003745 File Offset: 0x00001945
		// (set) Token: 0x06000050 RID: 80 RVA: 0x00003756 File Offset: 0x00001956
		public static float Pitch
		{
			get
			{
				return Player.player.look.pitch;
			}
			set
			{
				AimbotCoroutines.PitchInfo.SetValue(Player.player.look, value);
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00003772 File Offset: 0x00001972
		// (set) Token: 0x06000052 RID: 82 RVA: 0x00003783 File Offset: 0x00001983
		public static float Yaw
		{
			get
			{
				return Player.player.look.yaw;
			}
			set
			{
				AimbotCoroutines.YawInfo.SetValue(Player.player.look, value);
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0000379F File Offset: 0x0000199F
		public static IEnumerator SetLockedObject()
		{
			return new AimbotCoroutines.<SetLockedObject>d__11(0);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000037A7 File Offset: 0x000019A7
		public static IEnumerator AimToObject()
		{
			return new AimbotCoroutines.<AimToObject>d__12(0);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00006DAC File Offset: 0x00004FAC
		public static void Aim(GameObject obj)
		{
			Vector3 aimPosition = AimbotCoroutines.GetAimPosition(obj.transform, "Skull");
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

		// Token: 0x06000056 RID: 86 RVA: 0x00006E38 File Offset: 0x00005038
		public static void SmoothAim(GameObject obj)
		{
			Vector3 aimPosition = AimbotCoroutines.GetAimPosition(obj.transform, "Skull");
			if (aimPosition == AimbotCoroutines.PiVector)
			{
				return;
			}
			Transform transform = Player.player.transform;
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

		// Token: 0x06000057 RID: 87 RVA: 0x00006F84 File Offset: 0x00005184
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
		public static FieldInfo PitchInfo = typeof(PlayerLook).GetField("_pitch", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x0400003F RID: 63
		public static FieldInfo YawInfo = typeof(PlayerLook).GetField("_yaw", BindingFlags.Instance | BindingFlags.NonPublic);
	}
}
