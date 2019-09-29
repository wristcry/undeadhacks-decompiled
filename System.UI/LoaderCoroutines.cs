using System;
using System.Collections;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000053 RID: 83
	public static class LoaderCoroutines
	{
		// Token: 0x06000141 RID: 321 RVA: 0x00003F8B File Offset: 0x0000218B
		public static IEnumerator LoadAssets()
		{
			return new LoaderCoroutines.<LoadAssets>d__2(0);
		}

		// Token: 0x0400012B RID: 299
		public static bool IsLoaded;

		// Token: 0x0400012C RID: 300
		public static string AssetPath = string.Format(<Module>.smethod_4<string>(1101476997u), Application.dataPath);
	}
}
