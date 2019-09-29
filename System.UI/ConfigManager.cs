using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UndeadHacks
{
	// Token: 0x02000026 RID: 38
	public class ConfigManager
	{
		// Token: 0x0600009B RID: 155 RVA: 0x00009A10 File Offset: 0x00007C10
		public static void Init()
		{
			ConfigManager.LoadConfig(ConfigManager.GetConfig());
			int length = Enum.GetValues(typeof(ESPTarget)).Length;
			while (ESPOptions.VisualOptions.Length < length)
			{
				List<ESPVisual> list = ESPOptions.VisualOptions.ToList<ESPVisual>();
				list.Add(new ESPVisual
				{
					Labels = true,
					Boxes = false,
					ShowName = true,
					ShowDistance = true,
					Glow = true,
					Distance = 1000f,
					Location = LabelLocation.BottomMiddle,
					FixedTextSize = 11,
					MinTextSize = 8,
					MaxTextSize = 11,
					MinTextSizeDistance = 800f,
					BorderStrength = 0,
					ObjectCap = 24
				});
				ESPOptions.VisualOptions = list.ToArray();
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00009AD4 File Offset: 0x00007CD4
		public static Dictionary<string, object> CollectConfig()
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>
			{
				{
					"Version",
					ConfigManager.ConfigVersion
				}
			};
			foreach (Type type in (from T in Assembly.GetExecutingAssembly().GetTypes()
			where T.IsClass
			select T).ToArray<Type>())
			{
				foreach (FieldInfo fieldInfo in (from F in type.GetFields()
				where F.IsDefined(typeof(SaveAttribute), false)
				select F).ToArray<FieldInfo>())
				{
					dictionary.Add(type.Name + "_" + fieldInfo.Name, fieldInfo.GetValue(null));
				}
			}
			return dictionary;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00009BB0 File Offset: 0x00007DB0
		public static Dictionary<string, object> GetConfig()
		{
			if (!File.Exists(ConfigManager.ConfigPath))
			{
				ConfigManager.SaveConfig();
			}
			Dictionary<string, object> result = new Dictionary<string, object>();
			try
			{
				result = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(ConfigManager.ConfigPath), new JsonSerializerSettings
				{
					Formatting = Formatting.Indented
				});
			}
			catch
			{
				ConfigManager.SaveConfig();
			}
			return result;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000039A6 File Offset: 0x00001BA6
		public static void SaveConfig()
		{
			ColorOptions.ColorDict = ColorOptions.ColorDict2;
			File.WriteAllText(ConfigManager.ConfigPath, JsonConvert.SerializeObject(ConfigManager.CollectConfig(), Formatting.Indented));
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00009C0C File Offset: 0x00007E0C
		public static void LoadConfig(Dictionary<string, object> Config)
		{
			if (!File.Exists(ConfigManager.ConfigPath))
			{
				return;
			}
			foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
			{
				foreach (FieldInfo fieldInfo in from f in type.GetFields()
				where Attribute.IsDefined(f, typeof(SaveAttribute))
				select f)
				{
					string key = string.Format("{0}_{1}", type.Name, fieldInfo.Name);
					Type fieldType = fieldInfo.FieldType;
					object value = fieldInfo.GetValue(null);
					if (!Config.ContainsKey(key))
					{
						Config.Add(key, value);
					}
					try
					{
						if (Config[key].GetType() == typeof(JArray))
						{
							Config[key] = ((JArray)Config[key]).ToObject(fieldInfo.FieldType);
						}
						if (Config[key].GetType() == typeof(JObject))
						{
							Config[key] = ((JObject)Config[key]).ToObject(fieldInfo.FieldType);
						}
						fieldInfo.SetValue(null, fieldInfo.FieldType.IsEnum ? Enum.ToObject(fieldInfo.FieldType, Config[key]) : Convert.ChangeType(Config[key], fieldInfo.FieldType));
					}
					catch
					{
						Config[key] = value;
					}
				}
			}
			HotkeyUtilities.Initialize();
			ColorUtilities.LoadDict();
			ConfigManager.SaveConfig();
		}

		// Token: 0x04000072 RID: 114
		public static string ConfigPath = string.Format("{0}/config.txt", Environment.ExpandEnvironmentVariables("%appdata%"));

		// Token: 0x04000073 RID: 115
		public static string appdata = Environment.ExpandEnvironmentVariables("%appdata%/");

		// Token: 0x04000074 RID: 116
		public static string current = "config";

		// Token: 0x04000075 RID: 117
		public static string ConfigVersion = "1.0.2";
	}
}
