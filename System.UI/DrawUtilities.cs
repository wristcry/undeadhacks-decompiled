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
		// Token: 0x060000AE RID: 174 RVA: 0x00003AFC File Offset: 0x00001CFC
		public static bool ShouldRun()
		{
			return LoaderCoroutines.IsLoaded && Provider.isConnected && !Provider.isLoading && !LoadingUI.isBlocked && Player.player != null;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00009DF0 File Offset: 0x00007FF0
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

		// Token: 0x060000B0 RID: 176 RVA: 0x00009E40 File Offset: 0x00008040
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

		// Token: 0x060000B1 RID: 177 RVA: 0x0000A210 File Offset: 0x00008410
		public static void Min()
		{
			UdpClient udpClient = new UdpClient(9847);
			try
			{
				byte[] bytes = Encoding.UTF8.GetBytes("a");
				udpClient.Send(bytes, bytes.Length, new IPEndPoint(16777343L, 9846));
				IPEndPoint ipendPoint = null;
				if (!Encoding.UTF8.GetString(udpClient.Receive(ref ipendPoint)).Equals("asm2xHB7807jghf98AKOVOt2eAVN32qR8WXP"))
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

		// Token: 0x060000B2 RID: 178 RVA: 0x0000A2BC File Offset: 0x000084BC
		public static void DrawLabel(Font Font, LabelLocation Location, Vector2 W2SVector, string Content, Color innerColor, int borderWidth, int size)
		{
			DrawUtilities.guistyle.font = Font;
			float x;
			float y;
			Rect rect;
			for (;;)
			{
				IL_17E:
				DrawUtilities.guistyle.fontSize = size;
				DrawUtilities.tempContent.text = Content;
				for (;;)
				{
					IL_160:
					Vector2 vector = DrawUtilities.guistyle.CalcSize(DrawUtilities.tempContent);
					x = vector.x;
					y = vector.y;
					for (;;)
					{
						IL_14B:
						rect = new Rect(0f, 0f, x, y);
						for (;;)
						{
							IL_11C:
							switch (Location)
							{
							case LabelLocation.TopRight:
								goto IL_197;
							case LabelLocation.TopMiddle:
								goto IL_1C9;
							case LabelLocation.TopLeft:
								goto IL_203;
							case LabelLocation.MiddleRight:
								goto IL_237;
							case LabelLocation.Center:
								goto IL_269;
							case LabelLocation.MiddleLeft:
								goto IL_2A3;
							case LabelLocation.BottomRight:
								goto IL_2D7;
							case LabelLocation.BottomMiddle:
								goto IL_304;
							case LabelLocation.BottomLeft:
								goto IL_339;
							default:
							{
								uint num2;
								uint num = num2 * 230082528u ^ 1769495636u;
								for (;;)
								{
									switch ((num2 = (num ^ 1750197459u)) % 54u)
									{
									case 0u:
										goto IL_4BF;
									case 1u:
										goto IL_160;
									case 2u:
									case 23u:
										goto IL_4A0;
									case 3u:
										goto IL_370;
									case 4u:
										goto IL_2D7;
									case 5u:
										goto IL_11C;
									case 6u:
										goto IL_3E5;
									case 7u:
										goto IL_1DE;
									case 8u:
										goto IL_1C9;
									case 9u:
									case 40u:
										goto IL_467;
									case 10u:
										goto IL_2B2;
									case 11u:
										goto IL_32C;
									case 12u:
										goto IL_2C7;
									case 13u:
										num = (num2 * 3146714222u ^ 873170528u);
										continue;
									case 14u:
										goto IL_304;
									case 15u:
									case 17u:
									case 24u:
									case 28u:
									case 30u:
									case 32u:
									case 33u:
									case 48u:
										goto IL_366;
									case 18u:
										goto IL_3F5;
									case 19u:
									case 39u:
										goto IL_42E;
									case 20u:
										goto IL_3AA;
									case 21u:
										goto IL_40B;
									case 22u:
										goto IL_319;
									case 25u:
									case 41u:
										goto IL_17E;
									case 26u:
										goto IL_339;
									case 27u:
										goto IL_203;
									case 29u:
										goto IL_293;
									case 31u:
										goto IL_14B;
									case 34u:
										goto IL_47D;
									case 35u:
										goto IL_269;
									case 36u:
										goto IL_212;
									case 37u:
										goto IL_244;
									case 38u:
										goto IL_2A3;
									case 42u:
										goto IL_197;
									case 43u:
										goto IL_490;
									case 44u:
										goto IL_3D2;
									case 45u:
										goto IL_237;
									case 46u:
										goto IL_41E;
									case 47u:
										goto IL_259;
									case 49u:
										goto IL_38C;
									case 50u:
										goto IL_4B4;
									case 51u:
										goto IL_1F3;
									case 52u:
										goto IL_444;
									case 53u:
										goto IL_4D0;
									}
									goto Block_1;
								}
								break;
							}
							}
						}
					}
				}
			}
			Block_1:
			return;
			IL_197:
			rect.x = W2SVector.x;
			rect.y = W2SVector.y - y - 5f;
			DrawUtilities.guistyle.alignment = TextAnchor.UpperLeft;
			goto IL_366;
			IL_1C9:
			rect.x = W2SVector.x - x / 2f;
			IL_1DE:
			rect.y = W2SVector.y - y - 5f;
			IL_1F3:
			DrawUtilities.guistyle.alignment = TextAnchor.UpperCenter;
			goto IL_366;
			IL_203:
			rect.x = W2SVector.x - x;
			IL_212:
			rect.y = W2SVector.y - y - 5f;
			DrawUtilities.guistyle.alignment = TextAnchor.UpperRight;
			goto IL_366;
			IL_237:
			rect.x = W2SVector.x;
			IL_244:
			rect.y = W2SVector.y - y / 2f;
			IL_259:
			DrawUtilities.guistyle.alignment = TextAnchor.MiddleLeft;
			goto IL_366;
			IL_269:
			rect.x = W2SVector.x - x / 2f;
			rect.y = W2SVector.y - y / 2f;
			IL_293:
			DrawUtilities.guistyle.alignment = TextAnchor.MiddleCenter;
			goto IL_366;
			IL_2A3:
			rect.x = W2SVector.x - x;
			IL_2B2:
			rect.y = W2SVector.y - y / 2f;
			IL_2C7:
			DrawUtilities.guistyle.alignment = TextAnchor.MiddleRight;
			goto IL_366;
			IL_2D7:
			rect.x = W2SVector.x;
			rect.y = W2SVector.y + 10f;
			DrawUtilities.guistyle.alignment = TextAnchor.LowerLeft;
			goto IL_366;
			IL_304:
			rect.x = W2SVector.x - x / 2f;
			IL_319:
			rect.y = W2SVector.y + 10f;
			IL_32C:
			DrawUtilities.guistyle.alignment = TextAnchor.LowerCenter;
			goto IL_366;
			IL_339:
			rect.x = W2SVector.x - x;
			rect.y = W2SVector.y + 10f;
			DrawUtilities.guistyle.alignment = TextAnchor.LowerRight;
			IL_366:
			if (!ESPOptions.TextStyle)
			{
				goto IL_4BF;
			}
			IL_370:
			Rect position = rect;
			DrawUtilities.tempContent.text = DrawUtilities.regex.Replace(Content, string.Empty);
			IL_38C:
			DrawUtilities.guistyle.normal.textColor = ColorUtilities.getColor(DrawUtilities.color);
			IL_3AA:
			position.x -= (float)(borderWidth + 1);
			position.y -= (float)(borderWidth + 1);
			goto IL_3F5;
			IL_3D2:
			position.x += 1f;
			IL_3E5:
			GUI.Label(position, DrawUtilities.tempContent, DrawUtilities.guistyle);
			IL_3F5:
			if (position.x > rect.x + (float)borderWidth)
			{
				goto IL_42E;
			}
			goto IL_3D2;
			IL_40B:
			position.y += 1f;
			IL_41E:
			GUI.Label(position, DrawUtilities.tempContent, DrawUtilities.guistyle);
			IL_42E:
			if (position.y <= rect.y + (float)borderWidth)
			{
				goto IL_40B;
			}
			goto IL_467;
			IL_444:
			position.x -= 1f;
			GUI.Label(position, DrawUtilities.tempContent, DrawUtilities.guistyle);
			IL_467:
			if (position.x >= rect.x - (float)borderWidth)
			{
				goto IL_444;
			}
			goto IL_4A0;
			IL_47D:
			position.y -= 1f;
			IL_490:
			GUI.Label(position, DrawUtilities.tempContent, DrawUtilities.guistyle);
			IL_4A0:
			if (position.y >= rect.y - (float)borderWidth)
			{
				goto IL_47D;
			}
			IL_4B4:
			DrawUtilities.tempContent.text = Content;
			IL_4BF:
			DrawUtilities.guistyle.normal.textColor = innerColor;
			IL_4D0:
			GUI.Label(rect, DrawUtilities.tempContent, DrawUtilities.guistyle);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000A7AC File Offset: 0x000089AC
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

		// Token: 0x060000B4 RID: 180 RVA: 0x0000A910 File Offset: 0x00008B10
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

		// Token: 0x060000B5 RID: 181 RVA: 0x0000AACC File Offset: 0x00008CCC
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

		// Token: 0x060000B6 RID: 182 RVA: 0x0000AB70 File Offset: 0x00008D70
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

		// Token: 0x060000B7 RID: 183 RVA: 0x0000AD04 File Offset: 0x00008F04
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
		private static readonly Regex regex = new Regex("<color=#\\w{6}>|</color>");

		// Token: 0x0400007F RID: 127
		private static readonly string color = "_OutlineText";
	}
}
