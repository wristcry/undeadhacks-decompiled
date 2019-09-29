using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200006E RID: 110
	public static class OverrideUtilities
	{
		// Token: 0x0600019C RID: 412 RVA: 0x00010B38 File Offset: 0x0000ED38
		public static object CallOriginalFunc(MethodInfo method, object instance = null, params object[] args)
		{
			if (OverrideManager.Overrides.All((KeyValuePair<OverrideAttribute, OverrideWrapper> o) => o.Value.Original != method))
			{
				throw new Exception(<Module>.smethod_7<string>(3500831689u));
			}
			return OverrideManager.Overrides.First((KeyValuePair<OverrideAttribute, OverrideWrapper> a) => a.Value.Original == method).Value.CallOriginal(args, instance);
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00010BA0 File Offset: 0x0000EDA0
		public static object CallOriginal(object instance = null, params object[] args)
		{
			StackTrace stackTrace = new StackTrace(false);
			if (stackTrace.FrameCount < 1)
			{
				throw new Exception(<Module>.smethod_4<string>(1074659456u));
			}
			MethodBase method = stackTrace.GetFrame(1).GetMethod();
			MethodInfo original = null;
			if (!Attribute.IsDefined(method, typeof(OverrideAttribute)))
			{
				method = stackTrace.GetFrame(2).GetMethod();
			}
			OverrideAttribute overrideAttribute = (OverrideAttribute)Attribute.GetCustomAttribute(method, typeof(OverrideAttribute));
			if (overrideAttribute == null)
			{
				throw new Exception(<Module>.smethod_8<string>(1025001251u));
			}
			if (!overrideAttribute.MethodFound)
			{
				throw new Exception(<Module>.smethod_5<string>(3730427744u));
			}
			original = overrideAttribute.Method;
			if (OverrideManager.Overrides.All((KeyValuePair<OverrideAttribute, OverrideWrapper> o) => o.Value.Original != original))
			{
				throw new Exception(<Module>.smethod_4<string>(902943551u));
			}
			return OverrideManager.Overrides.First((KeyValuePair<OverrideAttribute, OverrideWrapper> a) => a.Value.Original == original).Value.CallOriginal(args, instance);
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00010CA4 File Offset: 0x0000EEA4
		public static bool EnableOverride(MethodInfo method)
		{
			OverrideWrapper value = OverrideManager.Overrides.First((KeyValuePair<OverrideAttribute, OverrideWrapper> a) => a.Value.Original == method).Value;
			return value != null && value.Override();
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00010CE8 File Offset: 0x0000EEE8
		public static bool DisableOverride(MethodInfo method)
		{
			OverrideWrapper value = OverrideManager.Overrides.First((KeyValuePair<OverrideAttribute, OverrideWrapper> a) => a.Value.Original == method).Value;
			return value != null && value.Revert();
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00010D2C File Offset: 0x0000EF2C
		public unsafe static bool OverrideFunction(IntPtr ptrOriginal, IntPtr ptrModified)
		{
			bool result;
			try
			{
				int size = IntPtr.Size;
				if (size != 4)
				{
					if (size != 8)
					{
						return false;
					}
					byte* ptr = (byte*)ptrOriginal.ToPointer();
					*ptr = 73;
					ptr[1] = 187;
					*(long*)(ptr + 2) = ptrModified.ToInt64();
					ptr[10] = 65;
					ptr[11] = byte.MaxValue;
					ptr[12] = 227;
				}
				else
				{
					byte* ptr2 = (byte*)ptrOriginal.ToPointer();
					ptr2[1] = 187;
					*(long*)(ptr2 + 2) = (long)ptrModified.ToInt32();
					ptr2[11] = byte.MaxValue;
					ptr2[12] = 227;
				}
				result = true;
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
				result = false;
			}
			return result;
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00010DDC File Offset: 0x0000EFDC
		public unsafe static bool RevertOverride(OverrideUtilities.OffsetBackup backup)
		{
			bool result;
			try
			{
				byte* ptr = (byte*)backup.Method.ToPointer();
				*ptr = backup.A;
				ptr[1] = backup.B;
				ptr[10] = backup.C;
				ptr[11] = backup.D;
				ptr[12] = backup.E;
				if (IntPtr.Size == 4)
				{
					*(int*)(ptr + 1) = (int)backup.F32;
					ptr[5] = backup.G;
				}
				else
				{
					*(long*)(ptr + 2) = (long)backup.F64;
				}
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0200006F RID: 111
		public class OffsetBackup
		{
			// Token: 0x060001A2 RID: 418 RVA: 0x00010E6C File Offset: 0x0000F06C
			public unsafe OffsetBackup(IntPtr method)
			{
				this.Method = method;
				byte* ptr = (byte*)method.ToPointer();
				this.A = *ptr;
				this.B = ptr[1];
				this.C = ptr[10];
				this.D = ptr[11];
				this.E = ptr[12];
				if (IntPtr.Size != 4)
				{
					this.F64 = (ulong)(*(long*)(ptr + 2));
					return;
				}
				this.F32 = *(uint*)(ptr + 1);
				this.G = ptr[5];
			}

			// Token: 0x040001A1 RID: 417
			public byte A;

			// Token: 0x040001A2 RID: 418
			public byte B;

			// Token: 0x040001A3 RID: 419
			public byte C;

			// Token: 0x040001A4 RID: 420
			public byte D;

			// Token: 0x040001A5 RID: 421
			public byte E;

			// Token: 0x040001A6 RID: 422
			public uint F32;

			// Token: 0x040001A7 RID: 423
			public ulong F64;

			// Token: 0x040001A8 RID: 424
			public byte G;

			// Token: 0x040001A9 RID: 425
			internal IntPtr Method;
		}
	}
}
