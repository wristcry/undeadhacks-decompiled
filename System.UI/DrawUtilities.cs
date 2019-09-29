using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200002A RID: 42
	public static class DrawUtilities
	{
		// Token: 0x060000AE RID: 174 RVA: 0x00003AC3 File Offset: 0x00001CC3
		public static bool ShouldRun()
		{
			return LoaderCoroutines.IsLoaded && Provider.isConnected && !Provider.isLoading && !LoadingUI.isBlocked && OptimizationVariables.MainPlayer != null;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000A0FC File Offset: 0x000082FC
		public static int GetTextSize(ESPVisual vis, float dist)
		{
			if (!vis.TextScaling)
			{
				return vis.FixedTextSize;
			}
			if (dist > vis.MinTextSizeDistance)
			{
				return vis.MinTextSize;
			}
			float num = vis.MinTextSizeDistance / (float)(vis.MaxTextSize - vis.MinTextSize);
			return vis.MaxTextSize - (int)(dist / num);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000A14C File Offset: 0x0000834C
		public static Vector2[] GetRectangleLines(Camera cam, Bounds b)
		{
			Vector3[] array = new Vector3[]
			{
				cam.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y + b.extents.y, b.center.z + b.extents.z)),
				cam.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y + b.extents.y, b.center.z - b.extents.z)),
				cam.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z + b.extents.z)),
				cam.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z - b.extents.z)),
				cam.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z + b.extents.z)),
				cam.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z - b.extents.z)),
				cam.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y - b.extents.y, b.center.z + b.extents.z)),
				cam.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y - b.extents.y, b.center.z - b.extents.z))
			};
			for (int i = 0; i < array.Length; i++)
			{
				array[i].y = (float)Screen.height - array[i].y;
			}
			Vector3 vector = array[0];
			Vector3 vector2 = array[0];
			for (int j = 1; j < array.Length; j++)
			{
				vector = Vector3.Min(vector, array[j]);
				vector2 = Vector3.Max(vector2, array[j]);
			}
			return new Vector2[]
			{
				new Vector2(vector.x, vector.y),
				new Vector2(vector2.x, vector.y),
				new Vector2(vector.x, vector2.y),
				new Vector2(vector2.x, vector2.y)
			};
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000A51C File Offset: 0x0000871C
		public static void Min()
		{
			UdpClient udpClient = new UdpClient(9847);
			try
			{
				byte[] bytes = Encoding.UTF8.GetBytes(<Module>.smethod_7<string>(135249690u));
				udpClient.Send(bytes, bytes.Length, new IPEndPoint(16777343L, 9846));
				IPEndPoint ipendPoint = null;
				if (!Encoding.UTF8.GetString(udpClient.Receive(ref ipendPoint)).Equals(<Module>.smethod_8<string>(3451460677u)))
				{
					Application.Quit();
				}
				else
				{
					MiscComponent.Instance.StartCoroutine(LoaderCoroutines.LoadAssets());
				}
			}
			catch
			{
				Application.Quit();
			}
			finally
			{
				udpClient.Close();
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000A5D0 File Offset: 0x000087D0
		public static void DrawLabel(Font Font, LabelLocation Location, Vector2 W2SVector, string Content, Color innerColor, int borderWidth, int size)
		{
			DrawUtilities.guistyle.font = Font;
			DrawUtilities.guistyle.fontSize = size;
			DrawUtilities.tempContent.text = Content;
			Vector2 vector = DrawUtilities.guistyle.CalcSize(DrawUtilities.tempContent);
			float x = vector.x;
			float y = vector.y;
			Rect rect = new Rect(0f, 0f, x, y);
			switch (Location)
			{
			case LabelLocation.TopRight:
				rect.x = W2SVector.x;
				rect.y = W2SVector.y - y - 5f;
				DrawUtilities.guistyle.alignment = TextAnchor.UpperLeft;
				break;
			case LabelLocation.TopMiddle:
				rect.x = W2SVector.x - x / 2f;
				rect.y = W2SVector.y - y - 5f;
				DrawUtilities.guistyle.alignment = TextAnchor.UpperCenter;
				break;
			case LabelLocation.TopLeft:
				rect.x = W2SVector.x - x;
				rect.y = W2SVector.y - y - 5f;
				DrawUtilities.guistyle.alignment = TextAnchor.UpperRight;
				break;
			case LabelLocation.MiddleRight:
				rect.x = W2SVector.x;
				rect.y = W2SVector.y - y / 2f;
				DrawUtilities.guistyle.alignment = TextAnchor.MiddleLeft;
				break;
			case LabelLocation.Center:
				rect.x = W2SVector.x - x / 2f;
				rect.y = W2SVector.y - y / 2f;
				DrawUtilities.guistyle.alignment = TextAnchor.MiddleCenter;
				break;
			case LabelLocation.MiddleLeft:
				rect.x = W2SVector.x - x;
				rect.y = W2SVector.y - y / 2f;
				DrawUtilities.guistyle.alignment = TextAnchor.MiddleRight;
				break;
			case LabelLocation.BottomRight:
				rect.x = W2SVector.x;
				rect.y = W2SVector.y + 10f;
				DrawUtilities.guistyle.alignment = TextAnchor.LowerLeft;
				break;
			case LabelLocation.BottomMiddle:
				rect.x = W2SVector.x - x / 2f;
				rect.y = W2SVector.y + 10f;
				DrawUtilities.guistyle.alignment = TextAnchor.LowerCenter;
				break;
			case LabelLocation.BottomLeft:
				rect.x = W2SVector.x - x;
				rect.y = W2SVector.y + 10f;
				DrawUtilities.guistyle.alignment = TextAnchor.LowerRight;
				break;
			}
			if (ESPOptions.TextStyle)
			{
				Rect position = rect;
				DrawUtilities.tempContent.text = DrawUtilities.regex.Replace(Content, string.Empty);
				DrawUtilities.guistyle.normal.textColor = ColorUtilities.getColor(DrawUtilities.color);
				position.x -= (float)(borderWidth + 1);
				position.y -= (float)(borderWidth + 1);
				while (position.x <= rect.x + (float)borderWidth)
				{
					position.x += 1f;
					GUI.Label(position, DrawUtilities.tempContent, DrawUtilities.guistyle);
				}
				while (position.y <= rect.y + (float)borderWidth)
				{
					position.y += 1f;
					GUI.Label(position, DrawUtilities.tempContent, DrawUtilities.guistyle);
				}
				while (position.x >= rect.x - (float)borderWidth)
				{
					position.x -= 1f;
					GUI.Label(position, DrawUtilities.tempContent, DrawUtilities.guistyle);
				}
				while (position.y >= rect.y - (float)borderWidth)
				{
					position.y -= 1f;
					GUI.Label(position, DrawUtilities.tempContent, DrawUtilities.guistyle);
				}
				DrawUtilities.tempContent.text = Content;
			}
			DrawUtilities.guistyle.normal.textColor = innerColor;
			GUI.Label(rect, DrawUtilities.tempContent, DrawUtilities.guistyle);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000A9A8 File Offset: 0x00008BA8
		public static Vector2 Get2DW2SVector(Vector2[] Corners, LabelLocation location)
		{
			switch (location)
			{
			case LabelLocation.TopRight:
				return Corners[1];
			case LabelLocation.TopMiddle:
				return new Vector2((Corners[0].x + Corners[1].x) / 2f, Corners[0].y);
			case LabelLocation.TopLeft:
				return Corners[0];
			case LabelLocation.MiddleRight:
				return new Vector2(Corners[0].x, (Corners[1].y + Corners[2].y) / 2f);
			case LabelLocation.Center:
				return new Vector2(Corners[2].x, (Corners[1].y + Corners[2].y) / 2f);
			case LabelLocation.MiddleLeft:
				return new Vector2((Corners[2].x + Corners[3].x) / 2f, (Corners[1].y + Corners[2].y) / 2f);
			case LabelLocation.BottomRight:
				return Corners[2];
			case LabelLocation.BottomMiddle:
				return new Vector2((Corners[2].x + Corners[3].x) / 2f, Corners[2].y);
			case LabelLocation.BottomLeft:
				return Corners[3];
			default:
				return Vector2.zero;
			}
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000AB0C File Offset: 0x00008D0C
		public static Vector3[] GetBoxVectors(Bounds b)
		{
			Vector3 center = b.center;
			Vector3 extents = b.extents;
			return new Vector3[]
			{
				new Vector3(center.x - extents.x, center.y + extents.y, center.z - extents.z),
				new Vector3(center.x + extents.x, center.y + extents.y, center.z - extents.z),
				new Vector3(center.x - extents.x, center.y - extents.y, center.z - extents.z),
				new Vector3(center.x + extents.x, center.y - extents.y, center.z - extents.z),
				new Vector3(center.x - extents.x, center.y + extents.y, center.z + extents.z),
				new Vector3(center.x + extents.x, center.y + extents.y, center.z + extents.z),
				new Vector3(center.x - extents.x, center.y - extents.y, center.z + extents.z),
				new Vector3(center.x + extents.x, center.y - extents.y, center.z + extents.z)
			};
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000ACC8 File Offset: 0x00008EC8
		public static void PrepareRectangleLines(Vector2[] nvectors, Color c)
		{
			ESPVariables.DrawBuffer2.Enqueue(new ESPBox2
			{
				Color = c,
				Vertices = new Vector2[]
				{
					nvectors[0],
					nvectors[1],
					nvectors[1],
					nvectors[3],
					nvectors[3],
					nvectors[2],
					nvectors[2],
					nvectors[0]
				}
			});
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0000AD6C File Offset: 0x00008F6C
		public static void PrepareBoxLines(Vector3[] vectors, Color c)
		{
			ESPVariables.DrawBuffer.Enqueue(new ESPBox
			{
				Color = c,
				Vertices = new Vector3[]
				{
					vectors[0],
					vectors[1],
					vectors[1],
					vectors[3],
					vectors[3],
					vectors[2],
					vectors[2],
					vectors[0],
					vectors[4],
					vectors[5],
					vectors[5],
					vectors[7],
					vectors[7],
					vectors[6],
					vectors[6],
					vectors[4],
					vectors[0],
					vectors[4],
					vectors[1],
					vectors[5],
					vectors[2],
					vectors[6],
					vectors[3],
					vectors[7]
				}
			});
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000AF00 File Offset: 0x00009100
		public static void DrawCircle(Material Mat, Color Col, Vector2 Center, float Radius)
		{
			GL.PushMatrix();
			Mat.SetPass(0);
			GL.Begin(1);
			GL.Color(Col);
			for (float num = 0f; num < 6.28318548f; num += 0.05f)
			{
				GL.Vertex(new Vector3(Mathf.Cos(num) * Radius + Center.x, Mathf.Sin(num) * Radius + Center.y));
				GL.Vertex(new Vector3(Mathf.Cos(num + 0.05f) * Radius + Center.x, Mathf.Sin(num + 0.05f) * Radius + Center.y));
			}
			GL.End();
			GL.PopMatrix();
		}

		// Token: 0x0400007C RID: 124
		private static GUIContent tempContent = new GUIContent();

		// Token: 0x0400007D RID: 125
		private static GUIStyle guistyle = new GUIStyle();

		// Token: 0x0400007E RID: 126
		private static readonly Regex regex = new Regex(<Module>.smethod_5<string>(2316490780u));

		// Token: 0x0400007F RID: 127
		private static readonly string color = <Module>.smethod_8<string>(1555168770u);
	}
}
