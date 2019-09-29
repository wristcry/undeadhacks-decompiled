using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000041 RID: 65
	public static class HotkeyUtilities
	{
		// Token: 0x0600010B RID: 267 RVA: 0x0000D2FC File Offset: 0x0000B4FC
		[Initializer]
		public static void Initialize()
		{
			HotkeyUtilities.AddHotkey("Aimbot", "Аимбот Вкл/Выкл", "_ToggleAimbot", new KeyCode[]
			{
				KeyCode.Keypad3
			});
			HotkeyUtilities.AddHotkey("Aimbot", "Аимбот Клавиша", "_AimbotKey", new KeyCode[]
			{
				KeyCode.LeftControl
			});
			HotkeyUtilities.AddHotkey("Aimbot", "Аимбот Silent Вкл/Выкл", "_ToggleSilent", new KeyCode[]
			{
				KeyCode.KeypadPlus
			});
			HotkeyUtilities.AddHotkey("Misc", "Автоподбор", "_AutoPickup", new KeyCode[]
			{
				KeyCode.Keypad1
			});
			HotkeyUtilities.AddHotkey("Misc", "Выключить визуалы (Паник кей)", "_PanicButton", new KeyCode[]
			{
				KeyCode.Keypad0
			});
			HotkeyUtilities.AddHotkey("Misc", "Свободная камера", "_ToggleFreecam", new KeyCode[]
			{
				KeyCode.Keypad2
			});
			HotkeyUtilities.AddHotkey("Misc", "Медленное падение Вкл/Выкл", "_ToggleSlowFall", new KeyCode[]
			{
				KeyCode.Keypad4
			});
			HotkeyUtilities.AddHotkey("Misc", "Меню", "_Menu", new KeyCode[]
			{
				KeyCode.F1
			});
			HotkeyUtilities.AddHotkey("Weapons", "Триггербот", "_ToggleTriggerbot", new KeyCode[]
			{
				KeyCode.Keypad5
			});
			HotkeyUtilities.AddHotkey("Weapons", "Нет Отдачи", "_ToggleNoRecoil", new KeyCode[]
			{
				KeyCode.Keypad6
			});
			HotkeyUtilities.AddHotkey("Weapons", "Нет Разброса", "_ToggleNoSpread", new KeyCode[]
			{
				KeyCode.Keypad7
			});
			HotkeyUtilities.AddHotkey("Weapons", "Нет увода", "_ToggleNoSway", new KeyCode[]
			{
				KeyCode.Keypad8
			});
			HotkeyUtilities.AddHotkey("Vehicle Flight", "Полёт на машине", "_VFToggle", new KeyCode[]
			{
				KeyCode.End
			});
			HotkeyUtilities.AddHotkey("Vehicle Flight", "Движение Вверх", "_VFStrafeUp", new KeyCode[]
			{
				KeyCode.Space
			});
			HotkeyUtilities.AddHotkey("Vehicle Flight", "Движение Вниз", "_VFStrafeDown", new KeyCode[]
			{
				KeyCode.LeftControl
			});
			HotkeyUtilities.AddHotkey("Vehicle Flight", "Движение Влево", "_VFStrafeLeft", new KeyCode[]
			{
				KeyCode.LeftBracket
			});
			HotkeyUtilities.AddHotkey("Vehicle Flight", "Движение Вправо", "_VFStrafeRight", new KeyCode[]
			{
				KeyCode.RightBracket
			});
			HotkeyUtilities.AddHotkey("Vehicle Flight", "Движение Вперёд", "_VFMoveForward", new KeyCode[]
			{
				KeyCode.W
			});
			HotkeyUtilities.AddHotkey("Vehicle Flight", "Движение Назад", "_VFMoveBackward", new KeyCode[]
			{
				KeyCode.S
			});
			HotkeyUtilities.AddHotkey("Vehicle Flight", "Поворот Влево", "_VFRotateLeft", new KeyCode[]
			{
				KeyCode.A
			});
			HotkeyUtilities.AddHotkey("Vehicle Flight", "Поворот Вправо", "_VFRotateRight", new KeyCode[]
			{
				KeyCode.D
			});
			HotkeyUtilities.AddHotkey("Vehicle Flight", "Поворот Вверх", "_VFRotateUp", new KeyCode[]
			{
				KeyCode.UpArrow
			});
			HotkeyUtilities.AddHotkey("Vehicle Flight", "Поворот Вниз", "_VFRotateDown", new KeyCode[]
			{
				KeyCode.DownArrow
			});
			HotkeyUtilities.AddHotkey("Vehicle Flight", "Вращать Влево", "_VFRollLeft", new KeyCode[]
			{
				KeyCode.LeftArrow
			});
			HotkeyUtilities.AddHotkey("Vehicle Flight", "Вращать Вправо", "_VFRollRight", new KeyCode[]
			{
				KeyCode.RightArrow
			});
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0000D648 File Offset: 0x0000B848
		public static void AddHotkey(string Group, string Name, string Identifier, params KeyCode[] DefaultKeys)
		{
			if (!HotkeyOptions.HotkeyDict.ContainsKey(Group))
			{
				HotkeyOptions.HotkeyDict.Add(Group, new Dictionary<string, Hotkey>());
			}
			Dictionary<string, Hotkey> dictionary = HotkeyOptions.HotkeyDict[Group];
			if (!dictionary.ContainsKey(Identifier))
			{
				Hotkey value = new Hotkey
				{
					Name = Name,
					Keys = DefaultKeys
				};
				dictionary.Add(Identifier, value);
				HotkeyOptions.UnorganizedHotkeys.Add(Identifier, value);
				return;
			}
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0000D6B0 File Offset: 0x0000B8B0
		public static bool IsHotkeyDown(string Identifier)
		{
			return HotkeyOptions.UnorganizedHotkeys[Identifier].Keys.Any(new Func<KeyCode, bool>(Input.GetKeyDown)) && HotkeyOptions.UnorganizedHotkeys[Identifier].Keys.All(new Func<KeyCode, bool>(Input.GetKey));
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00003E78 File Offset: 0x00002078
		public static bool IsHotkeyHeld(string Identifier)
		{
			return HotkeyOptions.UnorganizedHotkeys[Identifier].Keys.All(new Func<KeyCode, bool>(Input.GetKey));
		}
	}
}
