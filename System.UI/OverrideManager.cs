using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UndeadHacks
{
	// Token: 0x0200006B RID: 107
	public static class OverrideManager
	{
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000195 RID: 405 RVA: 0x00004303 File Offset: 0x00002503
		public static Dictionary<OverrideAttribute, OverrideWrapper> Overrides { get; } = new Dictionary<OverrideAttribute, OverrideWrapper>();

		// Token: 0x06000196 RID: 406 RVA: 0x000109EC File Offset: 0x0000EBEC
		public static void LoadOverride(MethodInfo method)
		{
			OverrideAttribute attribute = (OverrideAttribute)Attribute.GetCustomAttribute(method, typeof(OverrideAttribute));
			if (OverrideManager.Overrides.Count((KeyValuePair<OverrideAttribute, OverrideWrapper> a) => a.Key.Method == attribute.Method) > 0)
			{
				return;
			}
			OverrideWrapper overrideWrapper = new OverrideWrapper(attribute.Method, method, attribute, null);
			overrideWrapper.Override();
			OverrideManager.Overrides.Add(attribute, overrideWrapper);
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00010A68 File Offset: 0x0000EC68
		public static void InitHook()
		{
			Type[] types = Assembly.GetExecutingAssembly().GetTypes();
			for (int i = 0; i < types.Length; i++)
			{
				foreach (MethodInfo methodInfo in types[i].GetMethods())
				{
					if (methodInfo.Name == <Module>.smethod_8<string>(386596012u) && methodInfo.IsDefined(typeof(OverrideAttribute), false))
					{
						OverrideManager.LoadOverride(methodInfo);
					}
				}
			}
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00010AE0 File Offset: 0x0000ECE0
		public static void RemoveOverrides()
		{
			foreach (OverrideWrapper overrideWrapper in OverrideManager.Overrides.Values)
			{
				overrideWrapper.Revert();
			}
		}
	}
}
