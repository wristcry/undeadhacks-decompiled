using System;
using System.Collections.Generic;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000042 RID: 66
	public static class IcoSphere
	{
		// Token: 0x0600010F RID: 271 RVA: 0x0000D704 File Offset: 0x0000B904
		public static GameObject Create(string name, float radius)
		{
			GameObject gameObject = new GameObject(name);
			Mesh mesh = new Mesh
			{
				name = name
			};
			List<Vector3> list = new List<Vector3>();
			float num = (1f + Mathf.Sqrt(5f)) / 2f;
			list.Add(new Vector3(-1f, num, 0f).normalized * radius);
			list.Add(new Vector3(1f, num, 0f).normalized * radius);
			list.Add(new Vector3(-1f, -num, 0f).normalized * radius);
			list.Add(new Vector3(1f, -num, 0f).normalized * radius);
			list.Add(new Vector3(0f, -1f, num).normalized * radius);
			list.Add(new Vector3(0f, 1f, num).normalized * radius);
			list.Add(new Vector3(0f, -1f, -num).normalized * radius);
			list.Add(new Vector3(0f, 1f, -num).normalized * radius);
			list.Add(new Vector3(num, 0f, -1f).normalized * radius);
			list.Add(new Vector3(num, 0f, 1f).normalized * radius);
			list.Add(new Vector3(-num, 0f, -1f).normalized * radius);
			list.Add(new Vector3(-num, 0f, 1f).normalized * radius);
			List<IcoSphere.TriangleIndices> list2 = new List<IcoSphere.TriangleIndices>
			{
				new IcoSphere.TriangleIndices(0, 11, 5),
				new IcoSphere.TriangleIndices(0, 5, 1),
				new IcoSphere.TriangleIndices(0, 1, 7),
				new IcoSphere.TriangleIndices(0, 7, 10),
				new IcoSphere.TriangleIndices(0, 10, 11),
				new IcoSphere.TriangleIndices(1, 5, 9),
				new IcoSphere.TriangleIndices(5, 11, 4),
				new IcoSphere.TriangleIndices(11, 10, 2),
				new IcoSphere.TriangleIndices(10, 7, 6),
				new IcoSphere.TriangleIndices(7, 1, 8),
				new IcoSphere.TriangleIndices(3, 9, 4),
				new IcoSphere.TriangleIndices(3, 4, 2),
				new IcoSphere.TriangleIndices(3, 2, 6),
				new IcoSphere.TriangleIndices(3, 6, 8),
				new IcoSphere.TriangleIndices(3, 8, 9),
				new IcoSphere.TriangleIndices(4, 9, 5),
				new IcoSphere.TriangleIndices(2, 4, 11),
				new IcoSphere.TriangleIndices(6, 2, 10),
				new IcoSphere.TriangleIndices(8, 6, 7),
				new IcoSphere.TriangleIndices(9, 8, 1)
			};
			mesh.vertices = list.ToArray();
			List<int> list3 = new List<int>();
			for (int i = 0; i < list2.Count; i++)
			{
				list3.Add(list2[i].v1);
				list3.Add(list2[i].v2);
				list3.Add(list2[i].v3);
			}
			mesh.triangles = list3.ToArray();
			Vector3[] vertices = mesh.vertices;
			Vector2[] array = new Vector2[vertices.Length];
			for (int j = 0; j < vertices.Length; j++)
			{
				Vector3 normalized = vertices[j].normalized;
				Vector2 vector = new Vector2(0f, 0f)
				{
					x = (Mathf.Atan2(normalized.x, normalized.z) + 3.14159274f) / 3.14159274f / 2f,
					y = (Mathf.Acos(normalized.y) + 3.14159274f) / 3.14159274f - 1f
				};
				array[j] = new Vector2(vector.x, vector.y);
			}
			mesh.uv = array;
			Vector3[] array2 = new Vector3[list.Count];
			for (int k = 0; k < array2.Length; k++)
			{
				array2[k] = list[k].normalized;
			}
			mesh.normals = array2;
			mesh.RecalculateBounds();
			gameObject.AddComponent<MeshCollider>().sharedMesh = mesh;
			return gameObject;
		}

		// Token: 0x02000043 RID: 67
		private struct TriangleIndices
		{
			// Token: 0x06000110 RID: 272 RVA: 0x00003E9B File Offset: 0x0000209B
			public TriangleIndices(int v1, int v2, int v3)
			{
				this.v1 = v1;
				this.v2 = v2;
				this.v3 = v3;
			}

			// Token: 0x040000F1 RID: 241
			public readonly int v1;

			// Token: 0x040000F2 RID: 242
			public readonly int v2;

			// Token: 0x040000F3 RID: 243
			public readonly int v3;
		}
	}
}
