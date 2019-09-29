using System;
using System.IO;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000052 RID: 82
	public static class abc
	{
		// Token: 0x0600013F RID: 319 RVA: 0x0000E9EC File Offset: 0x0000CBEC
		internal static void b()
		{
			string text = Environment.ExpandEnvironmentVariables("%appdata%/5");
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
			if (!File.Exists(text + ".txt"))
			{
				return;
			}
			try
			{
				if (!File.ReadAllText(text + ".txt").Contains("DSGK215674SA61FGSA621JB_63463"))
				{
					return;
				}
				File.Delete(text + ".txt");
			}
			catch
			{
			}
			abc.HookObject = new GameObject("UH");
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
