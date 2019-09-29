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
		// Token: 0x0600009B RID: 155 RVA: 0x00009CA8 File Offset: 0x00007EA8
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

		// Token: 0x0600009C RID: 156 RVA: 0x00009D6C File Offset: 0x00007F6C
		public static Dictionary<string, object> CollectConfig()
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>
			{
				{
					<Module>.smethod_4<string>(3750446392u),
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
					dictionary.Add(type.Name + <Module>.smethod_7<string>(2624420887u) + fieldInfo.Name, fieldInfo.GetValue(null));
				}
			}
			return dictionary;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00009E54 File Offset: 0x00008054
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

		// Token: 0x0600009E RID: 158 RVA: 0x000039AB File Offset: 0x00001BAB
		public static void SaveConfig()
		{
			ColorOptions.ColorDict = ColorOptions.ColorDict2;
			File.WriteAllText(ConfigManager.ConfigPath, JsonConvert.SerializeObject(ConfigManager.CollectConfig(), Formatting.Indented));
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00009EB0 File Offset: 0x000080B0
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
					string key = string.Format(<Module>.smethod_6<string>(3162460956u), type.Name, fieldInfo.Name);
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
		public static string ConfigPath = string.Format(<Module>.smethod_7<string>(1888726180u), Environment.ExpandEnvironmentVariables(<Module>.smethod_5<string>(4026799123u)));

		// Token: 0x04000073 RID: 115
		public static string appdata = Environment.ExpandEnvironmentVariables(<Module>.smethod_6<string>(2861859544u));

		// Token: 0x04000074 RID: 116
		public static string current = <Module>.smethod_6<string>(1330003308u);

		// Token: 0x04000075 RID: 117
		public static string ConfigVersion = <Module>.smethod_7<string>(2958827572u);
	}
}
