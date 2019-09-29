using System;
using System.Collections;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200002F RID: 47
	public static class ESPCoroutines
	{
		// Token: 0x060000C5 RID: 197 RVA: 0x00003BF1 File Offset: 0x00001DF1
		public static IEnumerator DoChams()
		{
			return new ESPCoroutines.<DoChams>d__2(0);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000BE20 File Offset: 0x0000A020
		public static void DoChamsGameObject(GameObject pgo, Color32 front, Color32 behind)
		{
			Renderer[] componentsInChildren = pgo.GetComponentsInChildren<Renderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				foreach (Material material in componentsInChildren[i].materials)
				{
					if (material.shader == (ESPCoroutines.Normal | ESPCoroutines.Chams[0] | ESPCoroutines.Chams[1]))
					{
						material.shader = ESPCoroutines.Chams[ESPOptions.ChamsMode];
						material.SetColor(<Module>.smethod_4<string>(3215702939u), behind);
						material.SetColor(<Module>.smethod_7<string>(2199936712u), front);
					}
				}
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000BEDC File Offset: 0x0000A0DC
		[OffSpy]
		public static void EnableChams()
		{
			if (ESPOptions.ChamsEnabled && ESPCoroutines.Chams != null && ESPOptions.ChamsMode < ESPCoroutines.Chams.Length)
			{
				foreach (SteamPlayer steamPlayer in Provider.clients)
				{
					Player player = steamPlayer.player;
					if (player && player != OptimizationVariables.MainPlayer && player.gameObject)
					{
						Color32 front = FriendUtilities.IsFriendly(player) ? ColorUtilities.getColor(<Module>.smethod_8<string>(1270709942u)) : ColorUtilities.getColor(<Module>.smethod_4<string>(1034961585u));
						Color32 behind = FriendUtilities.IsFriendly(player) ? ColorUtilities.getColor(<Module>.smethod_4<string>(117594846u)) : ColorUtilities.getColor(<Module>.smethod_7<string>(2164885953u));
						ESPCoroutines.DoChamsGameObject(player.gameObject, front, behind);
					}
				}
				return;
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000BFE8 File Offset: 0x0000A1E8
		[OnSpy]
		public static void DisableChams()
		{
			if (ESPCoroutines.Normal == null)
			{
				return;
			}
			for (int i = 0; i < Provider.clients.Count; i++)
			{
				Player player = Provider.clients[i].player;
				if (player && player != OptimizationVariables.MainPlayer)
				{
					Renderer[] componentsInChildren = player.gameObject.GetComponentsInChildren<Renderer>();
					for (int j = 0; j < componentsInChildren.Length; j++)
					{
						Material[] materials = componentsInChildren[j].materials;
						for (int k = 0; k < materials.Length; k++)
						{
							if (materials[k].shader == (ESPCoroutines.Chams[0] | ESPCoroutines.Chams[1]))
							{
								materials[k].shader = ESPCoroutines.Normal;
							}
						}
					}
				}
			}
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00003BF9 File Offset: 0x00001DF9
		public static IEnumerator UpdateObjectList()
		{
			return new ESPCoroutines.<UpdateObjectList>d__6(0);
		}

		// Token: 0x04000092 RID: 146
		public static Shader[] Chams;

		// Token: 0x04000093 RID: 147
		public static Shader Normal;
	}
}
