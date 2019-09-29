using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace UndeadHacks
{
	// Token: 0x02000074 RID: 116
	public class OverrideWrapper
	{
		// Token: 0x060001AD RID: 429 RVA: 0x00010EE8 File Offset: 0x0000F0E8
		public OverrideWrapper(MethodInfo original, MethodInfo modified, OverrideAttribute attribute, object instance = null)
		{
			this.Original = original;
			this.Modified = modified;
			this.Instance = instance;
			this.Attribute = attribute;
			this.Local = (this.Modified.DeclaringType.Assembly == Assembly.GetExecutingAssembly());
			RuntimeHelpers.PrepareMethod(original.MethodHandle);
			RuntimeHelpers.PrepareMethod(modified.MethodHandle);
			this.PtrOriginal = this.Original.MethodHandle.GetFunctionPointer();
			this.PtrModified = this.Modified.MethodHandle.GetFunctionPointer();
			this.OffsetBackup = new OverrideUtilities.OffsetBackup(this.PtrOriginal);
			this.Detoured = false;
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060001AE RID: 430 RVA: 0x000043CA File Offset: 0x000025CA
		public MethodInfo Original { get; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060001AF RID: 431 RVA: 0x000043D2 File Offset: 0x000025D2
		public MethodInfo Modified { get; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060001B0 RID: 432 RVA: 0x000043DA File Offset: 0x000025DA
		public IntPtr PtrOriginal { get; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x000043E2 File Offset: 0x000025E2
		public IntPtr PtrModified { get; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060001B2 RID: 434 RVA: 0x000043EA File Offset: 0x000025EA
		public OverrideUtilities.OffsetBackup OffsetBackup { get; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x000043F2 File Offset: 0x000025F2
		public OverrideAttribute Attribute { get; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x000043FA File Offset: 0x000025FA
		// (set) Token: 0x060001B5 RID: 437 RVA: 0x00004402 File Offset: 0x00002602
		public bool Detoured { get; private set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x0000440B File Offset: 0x0000260B
		public object Instance { get; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x00004413 File Offset: 0x00002613
		public bool Local { get; }

		// Token: 0x060001B8 RID: 440 RVA: 0x0000441B File Offset: 0x0000261B
		public bool Override()
		{
			if (this.Detoured)
			{
				return true;
			}
			bool flag = OverrideUtilities.OverrideFunction(this.PtrOriginal, this.PtrModified);
			if (flag)
			{
				this.Detoured = true;
			}
			return flag;
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x00004442 File Offset: 0x00002642
		public bool Revert()
		{
			if (!this.Detoured)
			{
				return false;
			}
			bool flag = OverrideUtilities.RevertOverride(this.OffsetBackup);
			if (flag)
			{
				this.Detoured = false;
			}
			return flag;
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00010F98 File Offset: 0x0000F198
		public object CallOriginal(object[] args, object instance = null)
		{
			this.Revert();
			object result = null;
			try
			{
				result = this.Original.Invoke(instance ?? this.Instance, args);
			}
			catch (Exception)
			{
			}
			this.Override();
			return result;
		}
	}
}
