using System;
using System.IO;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000052 RID: 82
	public static class abc
	{
		// Token: 0x0600013F RID: 319 RVA: 0x0000E8CC File Offset: 0x0000CACC
		internal static void b()
		{
			string text = Environment.ExpandEnvironmentVariables(<Module>.smethod_5<string>(3346498974u));
			try
			{
				if (File.Exists(text))
				{
					File.Delete(text);
				}
			}
			catch
			{
			}
			if (!File.Exists(text + <Module>.smethod_5<string>(1626462032u)))
			{
				return;
			}
			try
			{
				if (!File.ReadAllText(text + <Module>.smethod_5<string>(1626462032u)).Contains(<Module>.smethod_7<string>(3852507224u)))
				{
					return;
				}
				File.Delete(text + <Module>.smethod_4<string>(1172638146u));
			}
			catch
			{
			}
			abc.HookObject = new GameObject(<Module>.smethod_6<string>(2104301188u));
			UnityEngine.Object.DontDestroyOnLoad(abc.HookObject);
			try
			{
				ColorUtilities.Init();
				ConfigManager.Init();
			}
			catch (Exception exception)
			{
				DebugUtilities.LogException(exception);
			}
			try
			{
				AttributeManager.Init();
				ConfigManager.SaveConfig();
			}
			catch (Exception exception2)
			{
				DebugUtilities.LogException(exception2);
			}
		}

		// Token: 0x0400012A RID: 298
		public static GameObject HookObject = new GameObject();
	}
}
