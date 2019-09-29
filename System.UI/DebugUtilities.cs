using System;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000028 RID: 40
	public class DebugUtilities
	{
		// Token: 0x060000A7 RID: 167 RVA: 0x00003A05 File Offset: 0x00001C05
		public static void Log(object Output)
		{
			Debug.Log(string.Format(<Module>.smethod_8<string>(543893310u), Output));
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00003A1C File Offset: 0x00001C1C
		public static void LogException(Exception Exception)
		{
			Debug.unityLogger.LogException(Exception, null);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00003A2A File Offset: 0x00001C2A
		public static void Init()
		{
			Debug.Log(string.Format(<Module>.smethod_6<string>(3244823603u), DateTime.Now));
		}
	}
}
