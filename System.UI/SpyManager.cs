using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x020000A4 RID: 164
	public class SpyManager
	{
		// Token: 0x06000264 RID: 612 RVA: 0x0001671C File Offset: 0x0001491C
		public static void InvokePre()
		{
			foreach (MethodInfo methodInfo in SpyManager.PreSpy)
			{
				methodInfo.Invoke(null, null);
			}
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0001676C File Offset: 0x0001496C
		public static void InvokePost()
		{
			foreach (MethodInfo methodInfo in SpyManager.PostSpy)
			{
				methodInfo.Invoke(null, null);
			}
		}

		// Token: 0x06000266 RID: 614 RVA: 0x000167BC File Offset: 0x000149BC
		public static void DestroyComponents()
		{
			foreach (Type type in SpyManager.Components)
			{
				UnityEngine.Object.Destroy(abc.HookObject.GetComponent(type));
			}
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00016814 File Offset: 0x00014A14
		public static void AddComponents()
		{
			foreach (Type componentType in SpyManager.Components)
			{
				abc.HookObject.AddComponent(componentType);
			}
		}

		// Token: 0x04000232 RID: 562
		public static IEnumerable<MethodInfo> PreSpy;

		// Token: 0x04000233 RID: 563
		public static IEnumerable<Type> Components;

		// Token: 0x04000234 RID: 564
		public static IEnumerable<MethodInfo> PostSpy;
	}
}
