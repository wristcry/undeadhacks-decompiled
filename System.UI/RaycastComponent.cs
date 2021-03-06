﻿using System;
using System.Collections;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000089 RID: 137
	[DisallowMultipleComponent]
	public class RaycastComponent : MonoBehaviour
	{
		// Token: 0x06000219 RID: 537 RVA: 0x000047A5 File Offset: 0x000029A5
		private void Awake()
		{
			base.StartCoroutine(this.RedoSphere());
			base.StartCoroutine(this.CalcSphere());
		}

		// Token: 0x0600021A RID: 538 RVA: 0x000047C1 File Offset: 0x000029C1
		private IEnumerator CalcSphere()
		{
			RaycastComponent.<CalcSphere>d__2 <CalcSphere>d__ = new RaycastComponent.<CalcSphere>d__2(0);
			<CalcSphere>d__.<>4__this = this;
			return <CalcSphere>d__;
		}

		// Token: 0x0600021B RID: 539 RVA: 0x000047D0 File Offset: 0x000029D0
		private IEnumerator RedoSphere()
		{
			RaycastComponent.<RedoSphere>d__3 <RedoSphere>d__ = new RaycastComponent.<RedoSphere>d__3(0);
			<RedoSphere>d__.<>4__this = this;
			return <RedoSphere>d__;
		}

		// Token: 0x040001E8 RID: 488
		public GameObject Sphere;
	}
}
