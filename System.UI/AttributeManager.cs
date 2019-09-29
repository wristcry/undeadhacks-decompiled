using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace UndeadHacks
{
	// Token: 0x0200001A RID: 26
	public static class AttributeManager
	{
		// Token: 0x06000072 RID: 114 RVA: 0x00008260 File Offset: 0x00006460
		public static void Init()
		{
			List<Type> list = new List<Type>();
			List<MethodInfo> list2 = new List<MethodInfo>();
			List<MethodInfo> list3 = new List<MethodInfo>();
			foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
			{
				if (type.IsDefined(typeof(ComponentAttribute), false))
				{
					abc.HookObject.AddComponent(type);
				}
				if (type.IsDefined(typeof(SpyComponentAttribute), false))
				{
					list.Add(type);
				}
				foreach (MethodInfo methodInfo in type.GetMethods(ReflectionVariables.Everything))
				{
					if (methodInfo.IsDefined(typeof(InitializerAttribute), false))
					{
						methodInfo.Invoke(null, null);
					}
					if (methodInfo.IsDefined(typeof(OverrideAttribute), false))
					{
						OverrideManager.LoadOverride(methodInfo);
					}
					if (methodInfo.IsDefined(typeof(OnSpyAttribute), false))
					{
						list2.Add(methodInfo);
					}
					if (methodInfo.IsDefined(typeof(OffSpyAttribute), false))
					{
						list3.Add(methodInfo);
					}
					if (methodInfo.IsDefined(typeof(ThreadAttribute), false))
					{
						new Thread(new ThreadStart(((Action)Delegate.CreateDelegate(typeof(Action), methodInfo)).Invoke)).Start();
					}
				}
			}
			SpyManager.Components = list;
			SpyManager.PostSpy = list3;
			SpyManager.PreSpy = list2;
		}
	}
}
