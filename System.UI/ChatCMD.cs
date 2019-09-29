using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200000F RID: 15
	public static class ChatCMD
	{
		// Token: 0x06000044 RID: 68 RVA: 0x00006A08 File Offset: 0x00004C08
		public static void Tab()
		{
			Prefab.ScrollView(new Rect(0f, 0f, 611f, 370f), <Module>.smethod_7<string>(653031536u), ref ChatCMD.HotkeyScroll, delegate()
			{
				GUILayout.Space(10f);
				foreach (KeyValuePair<string, Hotkey> keyValuePair in HotkeyOptions.ChatKeys)
				{
					ChatCMD.DrawButton(keyValuePair.Key);
				}
			}, 20);
			GUILayout.Space(380f);
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			if (Prefab.Button(<Module>.smethod_6<string>(2107596087u), 75f, 25f) && !HotkeyOptions.ChatKeys.ContainsKey(ChatCMD.NewKey))
			{
				HotkeyOptions.ChatKeys.Add(ChatCMD.NewKey, new Hotkey
				{
					Keys = new KeyCode[0],
					Name = ChatCMD.NewKey
				});
			}
			GUILayout.Space(10f);
			GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
			GUILayout.Space(5f);
			ChatCMD.NewKey = Prefab.TextField(ChatCMD.NewKey, <Module>.smethod_6<string>(958703910u), 477f);
			GUILayout.EndVertical();
			GUILayout.EndHorizontal();
			if (Prefab.Button(<Module>.smethod_5<string>(1220468469u), new Rect(0f, 0f, 100f, 21f)))
			{
				HotkeyTab.chat = !HotkeyTab.chat;
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00006B4C File Offset: 0x00004D4C
		public static void DrawButton(string Identifier)
		{
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			GUILayout.Label(Identifier, Prefab._TextStyle, Array.Empty<GUILayoutOption>());
			if (Prefab.Button(<Module>.smethod_5<string>(1470282929u), 75f, 25f))
			{
				HotkeyComponent.Clear();
				HotkeyOptions.ChatKeys.Remove(Identifier);
				ChatCMD.ClickedOption = string.Empty;
			}
			if (ChatCMD.ClickedOption == Identifier)
			{
				if (HotkeyComponent.StopKeys)
				{
					HotkeyOptions.ChatKeys[Identifier].Keys = HotkeyComponent.CurrentKeys.ToArray();
					HotkeyComponent.Clear();
					Prefab.Button(string.Join(<Module>.smethod_4<string>(1593946513u), HotkeyOptions.ChatKeys[Identifier].Keys.Select(delegate(KeyCode k)
					{
						KeyCode keyCode = k;
						return keyCode.ToString();
					}).ToArray<string>()), 200f, 25f);
					ChatCMD.ClickedOption = string.Empty;
				}
				else
				{
					string text;
					if (HotkeyOptions.ChatKeys[Identifier].Keys.Length == 0)
					{
						text = <Module>.smethod_4<string>(2965097687u);
					}
					else
					{
						text = string.Join(<Module>.smethod_8<string>(3789737526u), HotkeyOptions.ChatKeys[Identifier].Keys.Select(delegate(KeyCode k)
						{
							KeyCode keyCode = k;
							return keyCode.ToString();
						}).ToArray<string>());
					}
					Prefab.Button(text, 200f, 25f);
				}
			}
			else
			{
				string text2;
				if (HotkeyOptions.ChatKeys[Identifier].Keys.Length != 0)
				{
					text2 = string.Join(<Module>.smethod_8<string>(3789737526u), HotkeyOptions.ChatKeys[Identifier].Keys.Select(delegate(KeyCode k)
					{
						KeyCode keyCode = k;
						return keyCode.ToString();
					}).ToArray<string>());
				}
				else
				{
					text2 = <Module>.smethod_6<string>(4187141676u);
				}
				if (Prefab.Button(text2, 200f, 25f))
				{
					HotkeyComponent.Clear();
					ChatCMD.ClickedOption = Identifier;
					HotkeyComponent.NeedsKeys = true;
				}
			}
			GUILayout.EndHorizontal();
			GUILayout.Space(2f);
		}

		// Token: 0x04000032 RID: 50
		public static string NewKey = <Module>.smethod_5<string>(2306240662u);

		// Token: 0x04000033 RID: 51
		public static Vector2 HotkeyScroll;

		// Token: 0x04000034 RID: 52
		public static string ClickedOption;

		// Token: 0x04000035 RID: 53
		public static bool IsFirst = true;
	}
}
