using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200003F RID: 63
	public static class HotkeyTab
	{
		// Token: 0x06000101 RID: 257 RVA: 0x0000CDBC File Offset: 0x0000AFBC
		public static void Tab()
		{
			if (HotkeyTab.chat)
			{
				ChatCMD.Tab();
				return;
			}
			Prefab.ScrollView(new Rect(0f, 0f, 611f, 406f), <Module>.smethod_6<string>(1259305322u), ref HotkeyTab.HotkeyScroll, delegate()
			{
				foreach (KeyValuePair<string, Dictionary<string, Hotkey>> keyValuePair in HotkeyOptions.HotkeyDict)
				{
					if (!HotkeyTab.IsFirst)
					{
						HotkeyTab.DrawSpacer(keyValuePair.Key, false);
					}
					else
					{
						HotkeyTab.IsFirst = false;
						HotkeyTab.DrawSpacer(keyValuePair.Key, true);
					}
					foreach (KeyValuePair<string, Hotkey> keyValuePair2 in keyValuePair.Value)
					{
						HotkeyTab.DrawButton(keyValuePair2.Value.Name, keyValuePair2.Key);
					}
				}
			}, 20);
			if (Prefab.Button(<Module>.smethod_4<string>(4042312791u), new Rect(0f, 0f, 100f, 21f)))
			{
				HotkeyTab.chat = !HotkeyTab.chat;
			}
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00003E13 File Offset: 0x00002013
		public static void DrawSpacer(string Text, bool First)
		{
			if (!First)
			{
				GUILayout.Space(10f);
			}
			Prefab._TextStyle.fontStyle = FontStyle.Bold;
			GUILayout.Label(Text, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
			Prefab._TextStyle.fontStyle = FontStyle.Normal;
			GUILayout.Space(8f);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000CE5C File Offset: 0x0000B05C
		public static void DrawButton(string Option, string Identifier)
		{
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			GUILayout.Label(Option, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
			if (HotkeyTab.ClickedOption == Identifier)
			{
				if (Prefab.Button(<Module>.smethod_4<string>(767336661u), 75f, 25f))
				{
					HotkeyComponent.Clear();
					HotkeyOptions.UnorganizedHotkeys[Identifier].Keys = new KeyCode[0];
					HotkeyTab.ClickedOption = string.Empty;
				}
				if (!HotkeyComponent.StopKeys)
				{
					string text;
					if (HotkeyOptions.UnorganizedHotkeys[Identifier].Keys.Length != 0)
					{
						text = string.Join(<Module>.smethod_7<string>(3825577831u), HotkeyOptions.UnorganizedHotkeys[Identifier].Keys.Select(delegate(KeyCode k)
						{
							KeyCode keyCode = k;
							return keyCode.ToString();
						}).ToArray<string>());
					}
					else
					{
						text = <Module>.smethod_5<string>(4141456235u);
					}
					Prefab.Button(text, 200f, 25f);
				}
				else
				{
					HotkeyOptions.UnorganizedHotkeys[Identifier].Keys = HotkeyComponent.CurrentKeys.ToArray();
					HotkeyComponent.Clear();
					Prefab.Button(string.Join(<Module>.smethod_8<string>(3789737526u), HotkeyOptions.UnorganizedHotkeys[Identifier].Keys.Select(delegate(KeyCode k)
					{
						KeyCode keyCode = k;
						return keyCode.ToString();
					}).ToArray<string>()), 200f, 25f);
					HotkeyTab.ClickedOption = string.Empty;
				}
			}
			else
			{
				string text2;
				if (HotkeyOptions.UnorganizedHotkeys[Identifier].Keys.Length != 0)
				{
					text2 = string.Join(<Module>.smethod_4<string>(1593946513u), HotkeyOptions.UnorganizedHotkeys[Identifier].Keys.Select(delegate(KeyCode k)
					{
						KeyCode keyCode = k;
						return keyCode.ToString();
					}).ToArray<string>());
				}
				else
				{
					text2 = <Module>.smethod_4<string>(2965097687u);
				}
				if (Prefab.Button(text2, 200f, 25f))
				{
					HotkeyComponent.Clear();
					HotkeyTab.ClickedOption = Identifier;
					HotkeyComponent.NeedsKeys = true;
				}
			}
			GUILayout.EndHorizontal();
			GUILayout.Space(2f);
		}

		// Token: 0x040000E8 RID: 232
		public static bool chat = false;

		// Token: 0x040000E9 RID: 233
		public static Vector2 HotkeyScroll;

		// Token: 0x040000EA RID: 234
		public static string ClickedOption;

		// Token: 0x040000EB RID: 235
		public static bool IsFirst = true;
	}
}
