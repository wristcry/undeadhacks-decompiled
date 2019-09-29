using System;
using System.Linq;
using System.Reflection;

namespace UndeadHacks
{
	// Token: 0x02000069 RID: 105
	[AttributeUsage(AttributeTargets.Method)]
	public class OverrideAttribute : Attribute
	{
		// Token: 0x0600018D RID: 397 RVA: 0x00010964 File Offset: 0x0000EB64
		public OverrideAttribute(Type tClass, string method, BindingFlags flags, int index = 0)
		{
			this.Class = tClass;
			this.MethodName = method;
			this.Flags = flags;
			try
			{
				this.Method = (from a in this.Class.GetMethods(flags)
				where a.Name == method
				select a).ToArray<MethodInfo>()[index];
				this.MethodFound = 1;
			}
			catch (Exception)
			{
				this.MethodFound = 0;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600018E RID: 398 RVA: 0x000042C8 File Offset: 0x000024C8
		public Type Class { get; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600018F RID: 399 RVA: 0x000042D0 File Offset: 0x000024D0
		public string MethodName { get; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000190 RID: 400 RVA: 0x000042D8 File Offset: 0x000024D8
		public MethodInfo Method { get; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000191 RID: 401 RVA: 0x000042E0 File Offset: 0x000024E0
		public BindingFlags Flags { get; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000192 RID: 402 RVA: 0x000042E8 File Offset: 0x000024E8
		public bool MethodFound { get; }
	}
}
