using System;

namespace UndeadHacks
{
	// Token: 0x02000015 RID: 21
	public static class Names
	{
		// Token: 0x06000065 RID: 101 RVA: 0x000037E6 File Offset: 0x000019E6
		[Initializer]
		public static void Init()
		{
			Names.All = Names.RUS;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000073FC File Offset: 0x000055FC
		public static void EN()
		{
			MenuTabOption.tabs[0].name = "visuals";
			MenuTabOption.tabs[1].name = "aimbot";
			MenuTabOption.tabs[2].name = "weapons";
			MenuTabOption.tabs[3].name = "players";
			MenuTabOption.tabs[4].name = "stats";
			MenuTabOption.tabs[5].name = "skins";
			MenuTabOption.tabs[6].name = "misc";
			MenuTabOption.tabs[7].name = "misc 2";
			MenuTabOption.tabs[8].name = "colors";
			MenuTabOption.tabs[9].name = "hotkeys";
			MenuTabOption.tabs[10].name = "info";
			MenuTabOption.tabs[11].name = "attachments";
			Names.All = Names.ENG;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000074E4 File Offset: 0x000056E4
		public static void RU()
		{
			MenuTabOption.tabs[0].name = "визуалы";
			MenuTabOption.tabs[1].name = "аимбот";
			MenuTabOption.tabs[2].name = "оружия";
			MenuTabOption.tabs[3].name = "игроки";
			MenuTabOption.tabs[4].name = "статы";
			MenuTabOption.tabs[5].name = "скины";
			MenuTabOption.tabs[6].name = "прочее";
			MenuTabOption.tabs[7].name = "прочее 2";
			MenuTabOption.tabs[8].name = "цвета";
			MenuTabOption.tabs[9].name = "бинды";
			MenuTabOption.tabs[10].name = "инфо";
			MenuTabOption.tabs[11].name = "моды";
			Names.All = Names.RUS;
		}

		// Token: 0x04000044 RID: 68
		public static string[] All;

		// Token: 0x04000045 RID: 69
		public static readonly string[] RUS = new string[]
		{
			<Module>.smethod_7<string>(3572614211u),
			<Module>.smethod_6<string>(1448694911u),
			<Module>.smethod_5<string>(1278318544u),
			<Module>.smethod_7<string>(2316430536u),
			<Module>.smethod_6<string>(3799992736u),
			<Module>.smethod_5<string>(1941247571u),
			<Module>.smethod_8<string>(73149791u),
			<Module>.smethod_7<string>(3119006580u),
			<Module>.smethod_8<string>(3578020529u),
			<Module>.smethod_4<string>(696175512u),
			<Module>.smethod_5<string>(3440134331u),
			<Module>.smethod_5<string>(1729825988u),
			<Module>.smethod_4<string>(2158083573u),
			<Module>.smethod_7<string>(1231767416u),
			<Module>.smethod_8<string>(2291748146u),
			<Module>.smethod_6<string>(4100594148u),
			<Module>.smethod_6<string>(3388179501u),
			<Module>.smethod_7<string>(2799161623u),
			<Module>.smethod_4<string>(637388298u),
			<Module>.smethod_6<string>(1773960618u),
			<Module>.smethod_7<string>(1996585579u),
			<Module>.smethod_7<string>(2866042960u),
			<Module>.smethod_4<string>(264562881u),
			<Module>.smethod_4<string>(536833542u),
			<Module>.smethod_7<string>(1313210481u),
			<Module>.smethod_6<string>(2840490148u),
			<Module>.smethod_8<string>(1340498364u),
			<Module>.smethod_8<string>(2130594922u),
			<Module>.smethod_5<string>(1412954373u),
			<Module>.smethod_5<string>(3786191743u),
			<Module>.smethod_8<string>(398710487u),
			<Module>.smethod_7<string>(1662178894u),
			<Module>.smethod_6<string>(1197422089u),
			<Module>.smethod_5<string>(2806391101u),
			<Module>.smethod_8<string>(1482727778u),
			<Module>.smethod_4<string>(1392837001u),
			<Module>.smethod_8<string>(2617308842u),
			<Module>.smethod_6<string>(1032696795u),
			<Module>.smethod_8<string>(540939901u),
			<Module>.smethod_6<string>(2618066502u),
			<Module>.smethod_4<string>(203199601u),
			<Module>.smethod_4<string>(2945501949u),
			<Module>.smethod_6<string>(3849321326u),
			<Module>.smethod_7<string>(2107152100u),
			<Module>.smethod_5<string>(3257898545u),
			<Module>.smethod_6<string>(2453341208u),
			<Module>.smethod_7<string>(3244134829u),
			<Module>.smethod_7<string>(2976609481u),
			<Module>.smethod_7<string>(353675610u),
			<Module>.smethod_8<string>(3742428001u),
			<Module>.smethod_5<string>(1422682972u),
			<Module>.smethod_5<string>(3632620235u),
			<Module>.smethod_4<string>(3843272950u),
			<Module>.smethod_4<string>(919456828u),
			<Module>.smethod_5<string>(1344854180u),
			<Module>.smethod_5<string>(4016027486u),
			<Module>.smethod_6<string>(1794885023u),
			<Module>.smethod_4<string>(3683930980u),
			<Module>.smethod_5<string>(3593184320u),
			<Module>.smethod_5<string>(2219204790u),
			<Module>.smethod_4<string>(3311105563u),
			<Module>.smethod_4<string>(2857321128u),
			<Module>.smethod_7<string>(2938851600u),
			<Module>.smethod_4<string>(1294858311u),
			<Module>.smethod_4<string>(3865444754u),
			<Module>.smethod_4<string>(1476372085u),
			<Module>.smethod_5<string>(4016027486u)
		};

		// Token: 0x04000046 RID: 70
		public static readonly string[] ENG = new string[]
		{
			<Module>.smethod_6<string>(411014557u),
			<Module>.smethod_5<string>(2046176084u),
			<Module>.smethod_7<string>(850968425u),
			<Module>.smethod_6<string>(139262321u),
			<Module>.smethod_4<string>(3259540152u),
			<Module>.smethod_7<string>(2886531991u),
			<Module>.smethod_6<string>(1955425436u),
			<Module>.smethod_6<string>(2256026848u),
			<Module>.smethod_6<string>(341206553u),
			<Module>.smethod_8<string>(269197226u),
			<Module>.smethod_4<string>(2714998830u),
			<Module>.smethod_4<string>(2624241943u),
			<Module>.smethod_5<string>(816560982u),
			<Module>.smethod_5<string>(3026498245u),
			<Module>.smethod_8<string>(3085098952u),
			<Module>.smethod_5<string>(3314705582u),
			<Module>.smethod_5<string>(581966u),
			<Module>.smethod_8<string>(3224074118u),
			<Module>.smethod_7<string>(731767479u),
			<Module>.smethod_5<string>(1354582779u),
			<Module>.smethod_6<string>(559445318u),
			<Module>.smethod_6<string>(860046730u),
			<Module>.smethod_6<string>(3623157790u),
			<Module>.smethod_7<string>(1801868871u),
			<Module>.smethod_4<string>(2523687187u),
			<Module>.smethod_4<string>(971022239u),
			<Module>.smethod_7<string>(2901093719u),
			<Module>.smethod_7<string>(2633568371u),
			<Module>.smethod_6<string>(3376069849u),
			<Module>.smethod_6<string>(2993105790u),
			<Module>.smethod_6<string>(2774867025u),
			<Module>.smethod_8<string>(1596571477u),
			<Module>.smethod_5<string>(768439506u),
			<Module>.smethod_7<string>(3168619067u),
			<Module>.smethod_7<string>(679447870u),
			<Module>.smethod_7<string>(345041185u),
			<Module>.smethod_5<string>(1181554073u),
			<Module>.smethod_8<string>(3714042286u),
			<Module>.smethod_5<string>(2017511806u),
			<Module>.smethod_8<string>(2285540489u),
			<Module>.smethod_7<string>(1147617229u),
			<Module>.smethod_4<string>(1505765692u),
			<Module>.smethod_7<string>(2781892773u),
			<Module>.smethod_6<string>(3730184732u),
			<Module>.smethod_8<string>(3104022762u),
			<Module>.smethod_7<string>(2179960740u),
			<Module>.smethod_8<string>(1637673345u),
			<Module>.smethod_8<string>(1242625066u),
			<Module>.smethod_7<string>(3517587480u),
			<Module>.smethod_6<string>(1131798966u),
			<Module>.smethod_7<string>(3383824806u),
			<Module>.smethod_5<string>(1787154544u),
			<Module>.smethod_8<string>(3397943495u),
			<Module>.smethod_4<string>(66029435u),
			<Module>.smethod_5<string>(2075361881u),
			<Module>.smethod_6<string>(2634806026u),
			<Module>.smethod_8<string>(1485982026u),
			<Module>.smethod_4<string>(3816455409u),
			<Module>.smethod_8<string>(2377206130u),
			<Module>.smethod_6<string>(802348378u),
			<Module>.smethod_6<string>(3565459438u),
			<Module>.smethod_7<string>(2528929153u),
			<Module>.smethod_6<string>(1621789967u),
			<Module>.smethod_8<string>(1334290707u),
			<Module>.smethod_7<string>(1563466979u),
			<Module>.smethod_4<string>(519813870u),
			<Module>.smethod_8<string>(4200756206u)
		};
	}
}
