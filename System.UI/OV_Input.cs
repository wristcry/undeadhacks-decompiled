﻿using System;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000077 RID: 119
	public static class OV_Input
	{
		// Token: 0x060001BC RID: 444 RVA: 0x00004497 File Offset: 0x00002697
		[OnSpy]
		public static void OnSpied()
		{
			OV_Input.InputEnabled = false;
		}

		// Token: 0x060001BD RID: 445 RVA: 0x0000449F File Offset: 0x0000269F
		[OffSpy]
		public static void OnEndSpy()
		{
			OV_Input.InputEnabled = true;
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00010F84 File Offset: 0x0000F184
		[Override(typeof(Input), "GetKey", BindingFlags.Static | BindingFlags.Public, 1)]
		public static bool OV_GetKey(KeyCode key)
		{
			if (DrawUtilities.ShouldRun() && OV_Input.InputEnabled)
			{
				if (key == ControlsSettings.primary)
				{
					if (TriggerbotOptions.IsFiring)
					{
						return true;
					}
				}
				if (key != ControlsSettings.left)
				{
					if (key != ControlsSettings.right)
					{
						if (key != ControlsSettings.up && key != ControlsSettings.down)
						{
							goto IL_52;
						}
					}
				}
				if (MiscOptions.SpectatedPlayer != null)
				{
					return false;
				}
				IL_52:
				return (bool)OverrideUtilities.CallOriginal(null, new object[]
				{
					key
				});
			}
			return (bool)OverrideUtilities.CallOriginal(null, new object[]
			{
				key
			});
		}

		// Token: 0x040001B8 RID: 440
		public static bool InputEnabled = true;
	}
}
