using System;
using System.IO;
using System.Threading;

namespace UndeadHacks
{
	// Token: 0x0200000D RID: 13
	public static class FileThread
	{
		// Token: 0x0600003F RID: 63 RVA: 0x000066F0 File Offset: 0x000048F0
		[Thread]
		public static void CheckThread()
		{
			Thread.Sleep(5000);
			try
			{
				File.SetCreationTime("Unturned_Data/Managed/UnityEngine.TextRenderingModule.dll", File.GetCreationTime("Unturned_Data/Managed/UnityEngine.dll"));
				File.SetLastWriteTime("Unturned_Data/Managed/UnityEngine.TextRenderingModule.dll", File.GetLastWriteTime("Unturned_Data/Managed/UnityEngine.dll"));
			}
			catch
			{
			}
		}
	}
}
