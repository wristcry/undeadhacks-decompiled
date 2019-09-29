using System;
using System.IO;
using System.Threading;

namespace UndeadHacks
{
	// Token: 0x0200000D RID: 13
	public static class FileThread
	{
		// Token: 0x0600003F RID: 63 RVA: 0x000066D8 File Offset: 0x000048D8
		[Thread]
		public static void CheckThread()
		{
			Thread.Sleep(5000);
			try
			{
				File.SetCreationTime(<Module>.smethod_6<string>(1452879792u), File.GetCreationTime(<Module>.smethod_8<string>(3445253020u)));
				File.SetLastWriteTime(<Module>.smethod_4<string>(4255289843u), File.GetLastWriteTime(<Module>.smethod_5<string>(3392012855u)));
			}
			catch
			{
			}
		}
	}
}
