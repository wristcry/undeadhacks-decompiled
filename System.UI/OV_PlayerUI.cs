using System;
using System.Reflection;
using SDG.Unturned;

namespace UndeadHacks
{
	// Token: 0x02000080 RID: 128
	public class OV_PlayerUI
	{
		// Token: 0x060001E5 RID: 485 RVA: 0x00012650 File Offset: 0x00010850
		[Override(typeof(PlayerUI), "updateCrosshair", BindingFlags.Static | BindingFlags.Public, 0)]
		public static void updateCrosshair(float spread)
		{
			if (!Provider.modeConfigData.Gameplay.Crosshair)
			{
				return;
			}
			PlayerLifeUI.crosshairLeftImage.positionOffset_X = (int)(-spread * 400f) - 4;
			PlayerLifeUI.crosshairLeftImage.positionOffset_Y = -4;
			PlayerLifeUI.crosshairRightImage.positionOffset_X = (int)(spread * 400f) - 4;
			PlayerLifeUI.crosshairRightImage.positionOffset_Y = -4;
			PlayerLifeUI.crosshairUpImage.positionOffset_X = -4;
			PlayerLifeUI.crosshairUpImage.positionOffset_Y = (int)(-spread * 400f) - 4;
			PlayerLifeUI.crosshairDownImage.positionOffset_X = -4;
			PlayerLifeUI.crosshairDownImage.positionOffset_Y = (int)(spread * 400f) - 4;
		}
	}
}
