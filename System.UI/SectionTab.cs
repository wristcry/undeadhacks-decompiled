using System;

namespace UndeadHacks
{
	// Token: 0x02000093 RID: 147
	public class SectionTab
	{
		// Token: 0x0600023E RID: 574 RVA: 0x000048A3 File Offset: 0x00002AA3
		public SectionTab(string name, Action code)
		{
			this.name = name;
			this.code = code;
		}

		// Token: 0x0400020A RID: 522
		public static SectionTab CurrentSectionTab;

		// Token: 0x0400020B RID: 523
		public Action code;

		// Token: 0x0400020C RID: 524
		public string name;
	}
}
