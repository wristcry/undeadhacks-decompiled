using System;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000011 RID: 17
	[Component]
	public class AimbotComponent : MonoBehaviour
	{
		// Token: 0x0600004D RID: 77 RVA: 0x0000371F File Offset: 0x0000191F
		public void Start()
		{
			base.StartCoroutine(RaycastCoroutines.UpdateObjects());
			base.StartCoroutine(AimbotCoroutines.SetLockedObject());
			base.StartCoroutine(AimbotCoroutines.AimToObject());
		}
	}
}
