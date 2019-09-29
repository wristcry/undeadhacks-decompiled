using System;

namespace UndeadHacks
{
	// Token: 0x020000B4 RID: 180
	public class WeaponSave
	{
		// Token: 0x0600029E RID: 670 RVA: 0x00004C2B File Offset: 0x00002E2B
		public WeaponSave(ushort WeaponID, int SkinID)
		{
			this.WeaponID = WeaponID;
			this.SkinID = SkinID;
		}

		// Token: 0x04000267 RID: 615
		public int SkinID;

		// Token: 0x04000268 RID: 616
		public ushort WeaponID;
	}
}
