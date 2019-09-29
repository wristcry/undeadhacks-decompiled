using System;
using System.Reflection;
using SDG.Provider;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200001E RID: 30
	public static class AttachTab
	{
		// Token: 0x0600007A RID: 122 RVA: 0x000086D0 File Offset: 0x000068D0
		public static void Tab()
		{
			Prefab.MenuArea(new Rect(0f, 0f, 611f, 406f), <Module>.smethod_4<string>(3463225730u), delegate
			{
				AttachTab.sightID = Prefab.TextField(AttachTab.sightID, "Прицел:", 100f, 100f);
				GUILayout.Space(2f);
				AttachTab.tacticalID = Prefab.TextField(AttachTab.tacticalID, "Тактич:", 100f, 100f);
				GUILayout.Space(2f);
				AttachTab.gripID = Prefab.TextField(AttachTab.gripID, "Приклад:", 100f, 100f);
				GUILayout.Space(2f);
				AttachTab.barrelID = Prefab.TextField(AttachTab.barrelID, "Ствол:", 100f, 100f);
				GUILayout.Space(2f);
				AttachTab.magazineID = Prefab.TextField(AttachTab.magazineID, "Магазин:", 100f, 100f);
				GUILayout.Space(5f);
				if (Prefab.Button("Прочитать", 200f, 25f) && Player.player.equipment.useable != null)
				{
					Attachments attachments = (Attachments)AttachTab.attachments1.GetValue(Player.player.equipment.useable);
					if (attachments != null)
					{
						AttachTab.sightID = attachments.sightID.ToString();
						AttachTab.tacticalID = attachments.tacticalID.ToString();
						AttachTab.gripID = attachments.gripID.ToString();
						AttachTab.barrelID = attachments.barrelID.ToString();
						AttachTab.magazineID = attachments.magazineID.ToString();
					}
				}
				GUILayout.Space(5f);
				if (Prefab.Button("Применить", 200f, 25f))
				{
					UseableGun obj = (UseableGun)Player.player.equipment.useable;
					if (Player.player.equipment.useable != null)
					{
						Attachments attachments2 = (Attachments)AttachTab.attachments1.GetValue(obj);
						Attachments attachments3 = (Attachments)AttachTab.attachments3.GetValue(obj);
						ushort value;
						ushort.TryParse(AttachTab.sightID, out value);
						ushort value2;
						ushort.TryParse(AttachTab.tacticalID, out value2);
						ushort value3;
						ushort.TryParse(AttachTab.gripID, out value3);
						ushort value4;
						ushort.TryParse(AttachTab.barrelID, out value4);
						ushort value5;
						ushort.TryParse(AttachTab.magazineID, out value5);
						if (attachments2 != null)
						{
							byte[] array = new byte[18];
							byte[] array2 = new byte[2];
							array2 = BitConverter.GetBytes(value);
							array[0] = array2[0];
							array[1] = array2[1];
							array2 = BitConverter.GetBytes(value2);
							array[2] = array2[0];
							array[3] = array2[1];
							array2 = BitConverter.GetBytes(value3);
							array[4] = array2[0];
							array[5] = array2[1];
							array2 = BitConverter.GetBytes(value4);
							array[6] = array2[0];
							array[7] = array2[1];
							array2 = BitConverter.GetBytes(value5);
							array[8] = array2[0];
							array[9] = array2[1];
							attachments2.updateAttachments(array, true);
							attachments3.updateAttachments(array, false);
							AttachTab.upattachments.Invoke(obj, null);
						}
					}
				}
				Prefab.MenuArea(new Rect(230f, 15f, 230f, 130f), "StatTrack", delegate
				{
					GUILayout.Space(5f);
					AttachTab.id = Prefab.TextField(AttachTab.id, "ID оружия:", 100f, 100f);
					GUILayout.Space(2f);
					AttachTab.count = Prefab.TextField(AttachTab.count, "Убийства:", 100f, 100f);
					GUILayout.Space(5f);
					if (Prefab.Button("Выбрать текущее оружие", 200f, 25f) && Player.player)
					{
						ItemAsset asset = Player.player.equipment.asset;
						if (asset != null)
						{
							EStatTrackerType estatTrackerType;
							int num;
							Player.player.equipment.getUseableStatTrackerValue(out estatTrackerType, out num);
							AttachTab.id = asset.id.ToString();
							AttachTab.count = num.ToString();
						}
					}
					GUILayout.Space(5f);
					ushort itemID;
					int newValue;
					if (Prefab.Button("Применить", 200f, 25f) && ushort.TryParse(AttachTab.id, out itemID) && int.TryParse(AttachTab.count, out newValue))
					{
						SkinsUtilities.incrementStatTrackerValue(itemID, newValue);
					}
				});
			});
		}

		// Token: 0x0600007C RID: 124 RVA: 0x000036F7 File Offset: 0x000018F7
		MethodInfo method_0(string string_0, BindingFlags bindingFlags_0)
		{
			return base.GetMethod(string_0, bindingFlags_0);
		}

		// Token: 0x0400005A RID: 90
		public static FieldInfo attachments1 = typeof(UseableGun).GetField("firstAttachments", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x0400005B RID: 91
		public static FieldInfo attachments3 = typeof(UseableGun).GetField("thirdAttachments", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x0400005C RID: 92
		public static MethodInfo upattachments = typeof(UseableGun).method_0("updateAttachments", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x0400005D RID: 93
		private static string id;

		// Token: 0x0400005E RID: 94
		private static string count;

		// Token: 0x0400005F RID: 95
		public static string sightID;

		// Token: 0x04000060 RID: 96
		public static string tacticalID;

		// Token: 0x04000061 RID: 97
		public static string gripID;

		// Token: 0x04000062 RID: 98
		public static string barrelID;

		// Token: 0x04000063 RID: 99
		public static string magazineID;
	}
}
