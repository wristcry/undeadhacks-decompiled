using System;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000028 RID: 40
	public class DebugUtilities
	{
		// Token: 0x060000A7 RID: 167 RVA: 0x00003A3E File Offset: 0x00001C3E
		public static void Log(object Output)
		{
			Debug.Log(string.Format(<Module>.smethod_8<string>(543893310u), Output));
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00003A55 File Offset: 0x00001C55
		public static void LogException(Exception Exception)
		{
			Debug.unityLogger.LogException(Exception, null);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00003A63 File Offset: 0x00001C63
		public static void Init()
		{
			Debug.Log(string.Format(<Module>.smethod_6<string>(3244823603u), DateTime.Now));
		}
	}
}
