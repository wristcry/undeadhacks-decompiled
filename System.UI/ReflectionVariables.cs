using System;
using System.Reflection;

namespace UndeadHacks
{
	// Token: 0x02000091 RID: 145
	public static class ReflectionVariables
	{
		// Token: 0x04000205 RID: 517
		public static BindingFlags PublicInstance = BindingFlags.Instance | BindingFlags.Public;

		// Token: 0x04000206 RID: 518
		public static BindingFlags PrivateInstance = BindingFlags.Instance | BindingFlags.NonPublic;

		// Token: 0x04000207 RID: 519
		public static BindingFlags PublicStatic = BindingFlags.Static | BindingFlags.Public;

		// Token: 0x04000208 RID: 520
		public static BindingFlags PrivateStatic = BindingFlags.Static | BindingFlags.NonPublic;

		// Token: 0x04000209 RID: 521
		public static BindingFlags Everything = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
	}
}
