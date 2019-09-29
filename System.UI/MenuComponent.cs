using System;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000058 RID: 88
	[SpyComponent]
	[Component]
	public class MenuComponent : MonoBehaviour
	{
		// Token: 0x0600014F RID: 335 RVA: 0x0000ED08 File Offset: 0x0000CF08
		private void Update()
		{
			if (!HotkeyOptions.UnorganizedHotkeys.ContainsKey(<Module>.smethod_5<string>(2211040748u)))
			{
				HotkeyUtilities.AddHotkey(<Module>.smethod_7<string>(2682667799u), <Module>.smethod_8<string>(1122874549u), <Module>.smethod_5<string>(2211040748u), new KeyCode[]
				{
					KeyCode.F1
				});
			}
			if ((HotkeyOptions.UnorganizedHotkeys[<Module>.smethod_5<string>(2211040748u)].Keys.Length == 0 && Input.GetKeyDown(MenuComponent.MenuKey)) || HotkeyUtilities.IsHotkeyDown(<Module>.smethod_4<string>(485774526u)))
			{
				MenuComponent.IsInMenu = !MenuComponent.IsInMenu;
				if (MenuComponent.IsInMenu)
				{
					SectionTab.CurrentSectionTab = null;
				}
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000EDB0 File Offset: 0x0000CFB0
		private void OnGUI()
		{
			if (MenuComponent.IsInMenu && MenuComponent._LogoTexLarge != null)
			{
				if (this._cursorTexture == null)
				{
					this._cursorTexture = (Resources.Load(<Module>.smethod_6<string>(597109247u)) as Texture);
				}
				GUI.depth = -1;
				MenuComponent.MenuRect = GUI.Window(0, MenuComponent.MenuRect, new GUI.WindowFunction(this.DoMenu), string.Empty);
				GUI.Label(new Rect(MenuComponent.MenuRect.x + 20f, MenuComponent.MenuRect.y - 105f, 640f, 96f), MenuComponent._LogoTexLarge);
				GUI.depth = -2;
				this._cursor.x = Input.mousePosition.x;
				this._cursor.y = (float)Screen.height - Input.mousePosition.y;
				GUI.DrawTexture(this._cursor, this._cursorTexture);
				Cursor.lockState = CursorLockMode.None;
				if (PlayerUI.window != null)
				{
					PlayerUI.window.showCursor = true;
				}
			}
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000EEC0 File Offset: 0x0000D0C0
		private void DoMenu(int id)
		{
			if (SectionTab.CurrentSectionTab == null)
			{
				this.DoBorder();
				this.DoTabs();
				this.DrawTabs();
			}
			else
			{
				this.DoSectionTab();
			}
			GUI.DragWindow(new Rect(0f, 0f, MenuComponent.MenuRect.width, 25f));
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0000EF14 File Offset: 0x0000D114
		private void DoBorder()
		{
			Rect rect = new Rect(0f, 0f, MenuComponent.MenuRect.width, MenuComponent.MenuRect.height);
			Rect rect2 = MenuUtilities.Inline(rect, 1f);
			Rect rect3 = MenuUtilities.Inline(rect2, 1f);
			Rect rect4 = MenuUtilities.Inline(rect3, 3f);
			Rect position = MenuUtilities.Inline(rect4, 1f);
			Drawing.DrawRect(rect, MenuComponent._OutlineBorderBlack);
			Drawing.DrawRect(rect2, MenuComponent._OutlineBorderLightGray);
			Drawing.DrawRect(rect3, MenuComponent._OutlineBorderDarkGray);
			Drawing.DrawRect(rect4, MenuComponent._OutlineBorderLightGray);
			Drawing.DrawRect(position, MenuComponent._FillLightBlack);
			Drawing.DrawRect(new Rect(position.x + 2f, position.y + 2f, position.width - 4f, 2f), MenuComponent._Accent1);
			Drawing.DrawRect(new Rect(position.x + 2f, position.y + 4f, position.width - 4f, 2f), MenuComponent._Accent2);
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0000F044 File Offset: 0x0000D244
		private void DoTabs()
		{
			GUILayout.BeginArea(new Rect(15f, 25f, 620f, 100f));
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			for (int i = 0; i < MenuTabOption.tabs.Length; i++)
			{
				if (Prefab.IMenuTab(i, ref MenuTabOption.tabs[i].enabled))
				{
					MenuTabOption.CurrentTab = (MenuTabOption.tabs[i].enabled ? MenuTabOption.tabs[i] : null);
				}
				GUILayout.Space(1f);
				if (MenuTabOption.tabs[i] != MenuTabOption.CurrentTab)
				{
					MenuTabOption.tabs[i].enabled = false;
				}
			}
			GUILayout.Space(20f);
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00003FE4 File Offset: 0x000021E4
		private void DrawTabs()
		{
			GUILayout.BeginArea(new Rect(15f, 80f, 611f, 406f));
			if (MenuTabOption.CurrentTab != null)
			{
				MenuTabOption.CurrentTab.tab();
			}
			GUILayout.EndArea();
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0000F0F8 File Offset: 0x0000D2F8
		private void DoSectionTab()
		{
			if (SectionTab.CurrentSectionTab != null)
			{
				this.DoBorder();
				Prefab.MenuArea(new Rect(10f, 20f, MenuComponent.MenuRect.width - 20f, MenuComponent.MenuRect.height - 30f), SectionTab.CurrentSectionTab.name.ToUpper(), SectionTab.CurrentSectionTab.code);
				bool flag = false;
				if (Prefab.MenuTabAbsolute(new Vector2(17f, 448f), <Module>.smethod_5<string>(2818205776u), ref flag, 29))
				{
					SectionTab.CurrentSectionTab = null;
				}
			}
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0000F18C File Offset: 0x0000D38C
		public static void UpdateColors()
		{
			MenuComponent._OutlineBorderBlack = ColorUtilities.getColor(<Module>.smethod_7<string>(1481510855u));
			MenuComponent._OutlineBorderLightGray = ColorUtilities.getColor(<Module>.smethod_6<string>(1197867080u));
			MenuComponent._OutlineBorderDarkGray = ColorUtilities.getColor(<Module>.smethod_5<string>(3470363166u));
			MenuComponent._FillLightBlack = ColorUtilities.getColor(<Module>.smethod_7<string>(2848261051u));
			MenuComponent._Accent1 = ColorUtilities.getColor(<Module>.smethod_7<string>(3784599769u));
			MenuComponent._Accent2 = ColorUtilities.getColor(<Module>.smethod_8<string>(4067687858u));
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0000401F File Offset: 0x0000221F
		public static void SetGUIColors()
		{
			MenuComponent.UpdateColors();
			Prefab.UpdateColors();
		}

		// Token: 0x04000132 RID: 306
		public static Texture2D[] Icons;

		// Token: 0x04000133 RID: 307
		public static Font _TabFont;

		// Token: 0x04000134 RID: 308
		public static Font _TextFont;

		// Token: 0x04000135 RID: 309
		public static Texture2D _LogoTexLarge;

		// Token: 0x04000136 RID: 310
		public static bool IsInMenu;

		// Token: 0x04000137 RID: 311
		public static KeyCode MenuKey = KeyCode.F1;

		// Token: 0x04000138 RID: 312
		public static Rect MenuRect = new Rect(200f, 200f, 640f, 500f);

		// Token: 0x04000139 RID: 313
		public static Color32 _OutlineBorderBlack;

		// Token: 0x0400013A RID: 314
		public static Color32 _OutlineBorderLightGray;

		// Token: 0x0400013B RID: 315
		public static Color32 _OutlineBorderDarkGray;

		// Token: 0x0400013C RID: 316
		public static Color32 _FillLightBlack;

		// Token: 0x0400013D RID: 317
		public static Color32 _Accent1;

		// Token: 0x0400013E RID: 318
		public static Color32 _Accent2;

		// Token: 0x0400013F RID: 319
		private Rect _cursor = new Rect(0f, 0f, 20f, 20f);

		// Token: 0x04000140 RID: 320
		private Texture _cursorTexture;
	}
}
