using System;
using System.Reflection;
using SDG.Unturned;

namespace UndeadHacks
{
	// Token: 0x0200007C RID: 124
	public class OV_PlayerEquipment
	{
		// Token: 0x060001CF RID: 463 RVA: 0x00011B8C File Offset: 0x0000FD8C
		[Override(typeof(PlayerEquipment), "punch", BindingFlags.Instance | BindingFlags.NonPublic, 0)]
		public void OV_punch(EPlayerPunch p)
		{
			if (!MiscOptions.PanicMode)
			{
				if (!RaycastOptions.Enabled)
				{
					if (MiscOptions.ExtendMeleeRange)
					{
						OV_DamageTool.OVType = OverrideType.Extended;
					}
				}
				else
				{
					OV_DamageTool.OVType = OverrideType.SilentAimMelee;
				}
			}
			OverrideUtilities.CallOriginal(this, new object[]
			{
				p
			});
			OV_DamageTool.OVType = OverrideType.None;
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00004575 File Offset: 0x00002775
		[Override(typeof(UseableMelee), "fire", BindingFlags.Instance | BindingFlags.NonPublic, 0)]
		public void OV_fire()
		{
			if (!MiscOptions.PanicMode)
			{
				if (RaycastOptions.Enabled)
				{
					OV_DamageTool.OVType = OverrideType.SilentAimMelee;
				}
				else if (MiscOptions.ExtendMeleeRange)
				{
					OV_DamageTool.OVType = OverrideType.Extended;
				}
			}
			OverrideUtilities.CallOriginal(this, Array.Empty<object>());
			OV_DamageTool.OVType = OverrideType.None;
		}

		// Token: 0x040001BF RID: 447
		public static bool WasPunching;

		// Token: 0x040001C0 RID: 448
		public static uint CurrSim;
	}
}
