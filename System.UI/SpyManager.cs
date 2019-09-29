using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x020000A4 RID: 164
	public class SpyManager
	{
		// Token: 0x06000267 RID: 615 RVA: 0x000169C0 File Offset: 0x00014BC0
		public static void InvokePre()
		{
			foreach (MethodInfo methodInfo in SpyManager.PreSpy)
			{
				methodInfo.Invoke(null, null);
			}
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00016A10 File Offset: 0x00014C10
		public static void InvokePost()
		{
			foreach (MethodInfo methodInfo in SpyManager.PostSpy)
			{
				methodInfo.Invoke(null, null);
			}
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00016A60 File Offset: 0x00014C60
		public static void DestroyComponents()
		{
			foreach (Type type in SpyManager.Components)
			{
				UnityEngine.Object.Destroy(abc.HookObject.GetComponent(type));
			}
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00016AB8 File Offset: 0x00014CB8
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
