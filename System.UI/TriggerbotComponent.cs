using System;
using System.Collections;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x020000AA RID: 170
	[Component]
	public class TriggerbotComponent : MonoBehaviour
	{
		// Token: 0x06000274 RID: 628 RVA: 0x00004A0B File Offset: 0x00002C0B
		public void Start()
		{
			base.StartCoroutine(TriggerbotComponent.CheckTrigger());
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00004A19 File Offset: 0x00002C19
		public static IEnumerator CheckTrigger()
		{
			return new TriggerbotComponent.<CheckTrigger>d__2(0);
		}

		// Token: 0x04000244 RID: 580
		public static FieldInfo CurrentFiremode = typeof(UseableGun).GetField(<Module>.smethod_4<string>(1702735862u), BindingFlags.Instance | BindingFlags.NonPublic);
	}
}
