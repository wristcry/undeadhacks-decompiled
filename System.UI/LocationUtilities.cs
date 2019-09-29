using System;
using System.Linq;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x02000055 RID: 85
	public static class LocationUtilities
	{
		// Token: 0x06000149 RID: 329 RVA: 0x0000ECD0 File Offset: 0x0000CED0
		public static LocationNode GetClosestLocation(Vector3 pos)
		{
			float num = 1337420f;
			LocationNode result = null;
			foreach (LocationNode locationNode in (from n in LevelNodes.nodes
			where n.type == ENodeType.LOCATION
			select (LocationNode)n).ToArray<LocationNode>())
			{
				float num2 = Vector3.Distance(pos, locationNode.point);
				if (num2 < num)
				{
					num = num2;
					result = locationNode;
				}
			}
			return result;
		}
	}
}
