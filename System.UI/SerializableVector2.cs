using System;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000095 RID: 149
	public class SerializableVector2
	{
		// Token: 0x06000244 RID: 580 RVA: 0x00004936 File Offset: 0x00002B36
		public SerializableVector2(float nx, float ny)
		{
			this.x = nx;
			this.y = ny;
		}

		// Token: 0x06000245 RID: 581 RVA: 0x0000494C File Offset: 0x00002B4C
		public Vector2 ToVector2()
		{
			return new Vector2(this.x, this.y);
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0000495F File Offset: 0x00002B5F
		public static implicit operator Vector2(SerializableVector2 vector)
		{
			return vector.ToVector2();
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00004967 File Offset: 0x00002B67
		public static implicit operator SerializableVector2(Vector2 vector)
		{
			return new SerializableVector2(vector.x, vector.y);
		}

		// Token: 0x04000211 RID: 529
		public float x;

		// Token: 0x04000212 RID: 530
		public float y;
	}
}
