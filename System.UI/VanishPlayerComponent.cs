using System;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200000C RID: 12
	[SpyComponent]
	[Component]
	public class VanishPlayerComponent : MonoBehaviour
	{
		// Token: 0x0600003B RID: 59 RVA: 0x00006524 File Offset: 0x00004724
		private void OnGUI()
		{
			if (!DrawUtilities.ShouldRun())
			{
				return;
			}
			if (ESPOptions.ShowVanishPlayers)
			{
				GUI.color = new Color(1f, 1f, 1f, 0f);
				VanishPlayerComponent.vew = GUILayout.Window(350, VanishPlayerComponent.vew, new GUI.WindowFunction(this.PlayersMenu), string.Empty, Array.Empty<GUILayoutOption>());
				GUI.color = Color.white;
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00006594 File Offset: 0x00004794
		private void PlayersMenu(int windowID)
		{
			Rect position = new Rect(0f, 0f, VanishPlayerComponent.vew.width, 25f);
			Drawing.DrawRect(position, new Color32(34, 34, 34, byte.MaxValue));
			GUIStyle guistyle = new GUIStyle
			{
				alignment = TextAnchor.MiddleCenter
			};
			guistyle.normal.textColor = Color.white;
			GUI.Label(position, <Module>.smethod_5<string>(4189577711u), guistyle);
			Drawing.DrawRect(new Rect(0f, 25f, VanishPlayerComponent.vew.width, VanishPlayerComponent.vew.height + 25f), new Color32(34, 34, 34, 200));
			GUILayout.Space(10f);
			foreach (SteamPlayer steamPlayer in Provider.clients)
			{
				if (Vector3.Distance(steamPlayer.player.transform.position, Vector3.zero) < 10f)
				{
					GUILayout.Label(steamPlayer.playerID.characterName, Array.Empty<GUILayoutOption>());
					GUILayout.Space(-2f);
				}
			}
			GUI.DragWindow();
		}

		// Token: 0x0400002C RID: 44
		public static Rect vew = new Rect((float)Screen.width - 210f, 10f, 200f, 250f);
	}
}
