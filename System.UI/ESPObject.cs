using System;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000034 RID: 52
	public class ESPObject
	{
		// Token: 0x060000EF RID: 239 RVA: 0x00003CDD File Offset: 0x00001EDD
		public ESPObject(ESPTarget t, Component o)
		{
			this.Target = t;
			this.Object = o;
		}

		// Token: 0x040000A1 RID: 161
		public Component Object;

		// Token: 0x040000A2 RID: 162
		public ESPTarget Target;
	}
}
