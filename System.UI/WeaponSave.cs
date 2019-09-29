using System;

namespace UndeadHacks
{
	// Token: 0x020000B4 RID: 180
	public class WeaponSave
	{
		// Token: 0x060002A1 RID: 673 RVA: 0x00004BFB File Offset: 0x00002DFB
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
