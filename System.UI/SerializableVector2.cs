using System;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000095 RID: 149
	public class SerializableVector2
	{
		// Token: 0x06000247 RID: 583 RVA: 0x00004906 File Offset: 0x00002B06
		public SerializableVector2(float nx, float ny)
		{
			this.x = nx;
			this.y = ny;
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000491C File Offset: 0x00002B1C
		public Vector2 ToVector2()
		{
			return new Vector2(this.x, this.y);
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0000492F File Offset: 0x00002B2F
		public static implicit operator Vector2(SerializableVector2 vector)
		{
			return vector.ToVector2();
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00004937 File Offset: 0x00002B37
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
