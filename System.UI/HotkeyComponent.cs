using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Serialization;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200003D RID: 61
	[Component]
	public class HotkeyComponent : MonoBehaviour
	{
		// Token: 0x060000FC RID: 252 RVA: 0x0000CE8C File Offset: 0x0000B08C
		public void Update()
		{
			if (HotkeyComponent.NeedsKeys)
			{
				List<KeyCode> currentKeys = HotkeyComponent.CurrentKeys.ToList<KeyCode>();
				HotkeyComponent.CurrentKeys.Clear();
				foreach (KeyCode keyCode in HotkeyComponent.Keys)
				{
					if (Input.GetKey(keyCode))
					{
						HotkeyComponent.CurrentKeys.Add(keyCode);
					}
				}
				if (HotkeyComponent.CurrentKeys.Count < HotkeyComponent.CurrentKeyCount && HotkeyComponent.CurrentKeyCount > 0)
				{
					HotkeyComponent.CurrentKeys = currentKeys;
					HotkeyComponent.StopKeys = true;
				}
				HotkeyComponent.CurrentKeyCount = HotkeyComponent.CurrentKeys.Count;
			}
			if (MenuComponent.IsInMenu)
			{
				return;
			}
			foreach (KeyValuePair<string, Newtonsoft.Json.Serialization.Action> keyValuePair in HotkeyComponent.ActionDict)
			{
				if ((!MiscOptions.PanicMode || keyValuePair.Key == "_PanicButton") && HotkeyUtilities.IsHotkeyDown(keyValuePair.Key))
				{
					keyValuePair.Value();
				}
			}
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00003DBC File Offset: 0x00001FBC
		public static void Clear()
		{
			HotkeyComponent.NeedsKeys = false;
			HotkeyComponent.StopKeys = false;
			HotkeyComponent.CurrentKeyCount = 0;
			HotkeyComponent.CurrentKeys = new List<KeyCode>();
		}

		// Token: 0x040000DF RID: 223
		public static bool NeedsKeys;

		// Token: 0x040000E0 RID: 224
		public static bool StopKeys;

		// Token: 0x040000E1 RID: 225
		public static int CurrentKeyCount;

		// Token: 0x040000E2 RID: 226
		public static List<KeyCode> CurrentKeys;

		// Token: 0x040000E3 RID: 227
		public static Dictionary<string, Newtonsoft.Json.Serialization.Action> ActionDict = new Dictionary<string, Newtonsoft.Json.Serialization.Action>();

		// Token: 0x040000E4 RID: 228
		public static KeyCode[] Keys = (KeyCode[])Enum.GetValues(typeof(KeyCode));
	}
}
