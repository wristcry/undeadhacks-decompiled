using System;
using System.Collections.Generic;

namespace UndeadHacks
{
	// Token: 0x02000037 RID: 55
	public class ESPVariables
	{
		// Token: 0x040000C3 RID: 195
		public static List<ESPObject> Objects = new List<ESPObject>();

		// Token: 0x040000C4 RID: 196
		public static Queue<ESPBox> DrawBuffer = new Queue<ESPBox>();

		// Token: 0x040000C5 RID: 197
		public static Queue<ESPBox2> DrawBuffer2 = new Queue<ESPBox2>();
	}
}
