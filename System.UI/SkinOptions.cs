using System;

namespace UndeadHacks
{
	// Token: 0x0200009B RID: 155
	public static class SkinOptions
	{
		// Token: 0x04000223 RID: 547
		[Save]
		public static SkinConfig SkinConfig = new SkinConfig();

		// Token: 0x04000224 RID: 548
		public static SkinOptionList SkinWeapons = new SkinOptionList(ESkinType.WEAPONS);

		// Token: 0x04000225 RID: 549
		public static SkinOptionList SkinClothesShirts = new SkinOptionList(ESkinType.SHIRTS);

		// Token: 0x04000226 RID: 550
		public static SkinOptionList SkinClothesPants = new SkinOptionList(ESkinType.PANTS);

		// Token: 0x04000227 RID: 551
		public static SkinOptionList SkinClothesBackpack = new SkinOptionList(ESkinType.BACKPACKS);

		// Token: 0x04000228 RID: 552
		public static SkinOptionList SkinClothesVest = new SkinOptionList(ESkinType.VESTS);

		// Token: 0x04000229 RID: 553
		public static SkinOptionList SkinClothesHats = new SkinOptionList(ESkinType.HATS);

		// Token: 0x0400022A RID: 554
		public static SkinOptionList SkinClothesMask = new SkinOptionList(ESkinType.MASKS);

		// Token: 0x0400022B RID: 555
		public static SkinOptionList SkinClothesGlasses = new SkinOptionList(ESkinType.GLASSES);
	}
}
