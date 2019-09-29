﻿using System;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x020000A2 RID: 162
	public static class SphereUtilities
	{
		// Token: 0x06000265 RID: 613 RVA: 0x000168F0 File Offset: 0x00014AF0
		public static bool GetRaycast(GameObject Target, Vector3 StartPos, out Vector3 Point)
		{
			Point = Vector3.zero;
			if (Target == null)
			{
				return false;
			}
			RaycastComponent component = Target.GetComponent<RaycastComponent>();
			if (Vector3.Distance(Target.transform.position, StartPos) > 15f)
			{
				Vector3[] vertices = component.Sphere.GetComponent<MeshCollider>().sharedMesh.vertices;
				for (int i = 0; i < vertices.Length; i++)
				{
					Vector3 vector = component.Sphere.transform.TransformPoint(vertices[i]);
					Vector3 direction = Vector3.Normalize(vector - StartPos);
					float num = Vector3.Distance(StartPos, vector);
					if (!Physics.Raycast(StartPos, direction, num + 0.5f, RayMasks.DAMAGE_CLIENT))
					{
						Point = vector;
						return true;
					}
				}
				return false;
			}
			Point = OptimizationVariables.MainPlayer.transform.position;
			return true;
		}
	}
}
