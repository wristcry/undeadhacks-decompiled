using System;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200009C RID: 156
	public static class SkinsTab
	{
		// Token: 0x06000250 RID: 592 RVA: 0x00015AD4 File Offset: 0x00013CD4
		public static void Tab()
		{
			SkinsUtilities.DrawSkins(SkinOptions.SkinWeapons);
			SkinsUtilities.DrawSkins(SkinOptions.SkinClothesShirts);
			SkinsUtilities.DrawSkins(SkinOptions.SkinClothesPants);
			SkinsUtilities.DrawSkins(SkinOptions.SkinClothesBackpack);
			SkinsUtilities.DrawSkins(SkinOptions.SkinClothesHats);
			SkinsUtilities.DrawSkins(SkinOptions.SkinClothesMask);
			SkinsUtilities.DrawSkins(SkinOptions.SkinClothesVest);
			SkinsUtilities.DrawSkins(SkinOptions.SkinClothesGlasses);
			GUILayout.Space(8f);
			GUILayout.Label(<Module>.smethod_8<string>(3366905210u), Prefab._TextStyle, Array.Empty<GUILayoutOption>());
		}
	}
}
