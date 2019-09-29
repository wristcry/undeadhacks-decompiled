using System;
using System.Collections.Generic;
using System.Text;
using HighlightingSystem;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200002E RID: 46
	[SpyComponent]
	[Component]
	public class ESPComponent : MonoBehaviour
	{
		// Token: 0x060000BB RID: 187 RVA: 0x00003B27 File Offset: 0x00001D27
		public void Start()
		{
			base.StartCoroutine(ESPCoroutines.UpdateObjectList());
			base.StartCoroutine(ESPCoroutines.DoChams());
			ESPComponent.MainCamera = OptimizationVariables.MainCam;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00003B4B File Offset: 0x00001D4B
		public void Update()
		{
			if (MiscOptions.NoRain)
			{
				LevelLighting.rainyness = ELightingRain.NONE;
			}
			if (MiscOptions.NoSnow)
			{
				LevelLighting.snowyness = ELightingSnow.NONE;
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000AFA4 File Offset: 0x000091A4
		public void OnGUI()
		{
			if (Event.current.type != EventType.Repaint || !ESPOptions.Enabled)
			{
				return;
			}
			if (!DrawUtilities.ShouldRun())
			{
				return;
			}
			ESPComponent.MainCamera = OptimizationVariables.MainCam;
			if (ESPComponent.MainCamera == null)
			{
				return;
			}
			GUI.depth = 1;
			if (RaycastOptions.Enabled && MiscOptions.ShowSilentFOV && RaycastOptions.SilentAimUseFOV)
			{
				DrawUtilities.DrawCircle(ESPComponent.GLMat, Color.red, new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), VectorUtilities.FOVRadius(RaycastOptions.SilentAimFOV));
			}
			if (AimbotOptions.Enabled && MiscOptions.ShowAimFOV)
			{
				DrawUtilities.DrawCircle(ESPComponent.GLMat, Color.white, new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), VectorUtilities.FOVRadius(AimbotOptions.FOV));
			}
			Vector3 position = ESPComponent.MainCamera.transform.position;
			Vector3 forward = ESPComponent.MainCamera.transform.forward;
			for (int i = 0; i < ESPVariables.Objects.Count; i++)
			{
				ESPObject espobject = ESPVariables.Objects[i];
				if (espobject.Object)
				{
					GameObject gameObject = espobject.Object.gameObject;
					ESPVisual espvisual = ESPOptions.VisualOptions[(int)espobject.Target];
					if (espvisual.Enabled)
					{
						Vector3 position2 = gameObject.transform.position;
						float num = Vector3.Distance(position2, ESPComponent.MainCamera.transform.position);
						if ((double)num >= 0.5 && (num <= espvisual.Distance || espvisual.InfiniteDistance))
						{
							Vector3 vector = ESPComponent.MainCamera.WorldToScreenPoint(position2);
							if (vector.z > 0f)
							{
								ESPTarget target = espobject.Target;
								Bounds bounds;
								if (target <= ESPTarget.Zombies)
								{
									Vector3 localScale = gameObject.transform.localScale;
									bounds = new Bounds(new Vector3(position2.x, position2.y + 1.1f, position2.z), new Vector3(localScale.x * 1.8f, localScale.y * 2.6f, localScale.z * 1.8f));
								}
								else if (target != ESPTarget.Vehicles)
								{
									bounds = gameObject.GetComponent<Collider>().bounds;
								}
								else
								{
									bounds = gameObject.transform.Find(<Module>.smethod_8<string>(1577346828u)).GetComponent<MeshRenderer>().bounds;
									Transform transform = gameObject.transform.Find(<Module>.smethod_5<string>(2941026930u));
									if (transform)
									{
										bounds.Encapsulate(transform.GetComponent<MeshRenderer>().bounds);
									}
								}
								Color color = ColorUtilities.getColor(<Module>.smethod_5<string>(3402262973u) + espobject.Target);
								StringBuilder stringBuilder = new StringBuilder();
								switch (espobject.Target)
								{
								case ESPTarget.Players:
								{
									Player player = (Player)espobject.Object;
									if (player.life.isDead)
									{
										goto IL_CA9;
									}
									if (espvisual.Labels)
									{
										if (espvisual.ShowName)
										{
											stringBuilder.Append(ESPOptions.FullName ? player.name : player.channel.owner.playerID.characterName);
											stringBuilder.Append(<Module>.smethod_7<string>(737181723u));
										}
										stringBuilder.Append(<Module>.smethod_6<string>(3434213192u));
										if (ESPOptions.ShowPlayerWeapon)
										{
											stringBuilder.Append((player.equipment.asset != null) ? player.equipment.asset.itemName : <Module>.smethod_7<string>(2304575930u));
											stringBuilder.Append(<Module>.smethod_4<string>(2833079653u));
										}
										if (ESPOptions.ShowPlayerVehicle)
										{
											stringBuilder.Append((player.movement.getVehicle() != null) ? (player.movement.getVehicle().asset.name + <Module>.smethod_4<string>(2833079653u)) : <Module>.smethod_8<string>(980043457u));
										}
									}
									bounds.size /= 2f;
									bounds.size = new Vector3(bounds.size.x, bounds.size.y * 1.25f, bounds.size.z);
									if (FriendUtilities.IsFriendly(player))
									{
										color = ColorUtilities.getColor(<Module>.smethod_6<string>(2186218844u));
									}
									break;
								}
								case ESPTarget.Zombies:
									if (((Zombie)espobject.Object).isDead)
									{
										goto IL_CA9;
									}
									if (espvisual.Labels)
									{
										if (espvisual.ShowName)
										{
											stringBuilder.Append(((Zombie)espobject.Object).isMega ? <Module>.smethod_7<string>(3374677322u) : <Module>.smethod_5<string>(20039164u));
										}
										stringBuilder.Append(<Module>.smethod_7<string>(2505219941u));
									}
									break;
								case ESPTarget.Items:
									if (espvisual.Labels)
									{
										if (espvisual.ShowName)
										{
											stringBuilder.Append(((InteractableItem)espobject.Object).asset.itemName);
											stringBuilder.Append(<Module>.smethod_7<string>(737181723u));
										}
										stringBuilder.Append(<Module>.smethod_4<string>(1361373723u));
									}
									break;
								case ESPTarget.Sentries:
									if (espvisual.Labels)
									{
										InteractableSentry interactableSentry = (InteractableSentry)espobject.Object;
										if (espvisual.ShowName)
										{
											stringBuilder.Append(<Module>.smethod_7<string>(3775965344u));
										}
										if (ESPOptions.ShowSentryItem)
										{
											stringBuilder.Append(ESPComponent.SentryName(interactableSentry.displayItem));
											stringBuilder.Append(<Module>.smethod_5<string>(855996897u));
										}
										stringBuilder.Append(<Module>.smethod_8<string>(2955284852u));
									}
									break;
								case ESPTarget.Beds:
									if (espvisual.Labels)
									{
										InteractableBed bed = (InteractableBed)espobject.Object;
										if (espvisual.ShowName)
										{
											stringBuilder.Append(<Module>.smethod_4<string>(3277066219u));
										}
										if (ESPOptions.ShowClaimed)
										{
											stringBuilder.Append(ESPComponent.GetOwned(bed));
											stringBuilder.Append(<Module>.smethod_4<string>(2833079653u));
										}
										stringBuilder.Append(<Module>.smethod_5<string>(2979419807u));
									}
									break;
								case ESPTarget.ClaimFlags:
									if (espvisual.Labels)
									{
										if (espvisual.ShowName)
										{
											stringBuilder.Append(<Module>.smethod_8<string>(3249205585u));
										}
										stringBuilder.Append(<Module>.smethod_4<string>(1361373723u));
									}
									break;
								case ESPTarget.Vehicles:
									if (espvisual.Labels)
									{
										InteractableVehicle interactableVehicle = (InteractableVehicle)espobject.Object;
										if (interactableVehicle.health == 0 || (ESPOptions.FilterVehicleLocked && interactableVehicle.isLocked))
										{
											goto IL_CA9;
										}
										if (espvisual.ShowName)
										{
											stringBuilder.Append(interactableVehicle.asset.name);
											stringBuilder.Append(<Module>.smethod_5<string>(855996897u));
										}
										stringBuilder.Append(<Module>.smethod_6<string>(3434213192u));
										if (ESPOptions.ShowVehicleHealth)
										{
											stringBuilder.Append(<Module>.smethod_4<string>(2460254236u));
											stringBuilder.Append((int)(100f * (float)interactableVehicle.health / (float)interactableVehicle.asset.health));
											stringBuilder.Append(<Module>.smethod_4<string>(2359699480u));
										}
										if (ESPOptions.ShowVehicleFuel)
										{
											ushort num2;
											ushort num3;
											interactableVehicle.getDisplayFuel(out num2, out num3);
											stringBuilder.Append(<Module>.smethod_6<string>(1655269015u));
											stringBuilder.Append((int)(100f * (float)num2 / (float)num3));
											stringBuilder.Append(<Module>.smethod_6<string>(2421197133u));
										}
										if (ESPOptions.ShowVehicleLocked)
										{
											stringBuilder.Append(ESPComponent.GetLocked(interactableVehicle));
											stringBuilder.Append(<Module>.smethod_8<string>(2367443386u));
										}
									}
									break;
								case ESPTarget.Storage:
									if (espvisual.Labels)
									{
										stringBuilder.Append(<Module>.smethod_6<string>(506376838u));
										if (espvisual.ShowName)
										{
											stringBuilder.Append(espobject.Object.name);
											stringBuilder.Append(<Module>.smethod_7<string>(737181723u));
										}
										stringBuilder.Append(<Module>.smethod_8<string>(2955284852u));
									}
									break;
								case ESPTarget.Generators:
									if (espvisual.Labels)
									{
										InteractableGenerator interactableGenerator = (InteractableGenerator)espobject.Object;
										if (ESPOptions.ShowGeneratorFuel)
										{
											stringBuilder.Append(<Module>.smethod_8<string>(2013496975u));
											stringBuilder.Append((int)(100f * (float)interactableGenerator.fuel / (float)interactableGenerator.capacity));
											stringBuilder.Append(<Module>.smethod_6<string>(2421197133u));
										}
										if (ESPOptions.ShowGeneratorPowered)
										{
											stringBuilder.Append(ESPComponent.GetPowered(interactableGenerator));
											stringBuilder.Append(<Module>.smethod_8<string>(2367443386u));
										}
										stringBuilder.Append(<Module>.smethod_8<string>(2955284852u));
									}
									break;
								case ESPTarget.Animals:
								{
									Animal animal = (Animal)espobject.Object;
									if (animal.isDead)
									{
										goto IL_CA9;
									}
									if (espvisual.Labels)
									{
										stringBuilder.Append(<Module>.smethod_6<string>(2585922427u));
										if (espvisual.ShowName)
										{
											stringBuilder.Append(animal.asset.animalName);
											stringBuilder.Append(<Module>.smethod_4<string>(2833079653u));
										}
										stringBuilder.Append(<Module>.smethod_6<string>(3434213192u));
									}
									break;
								}
								case ESPTarget.Farm:
									if (espvisual.Labels)
									{
										stringBuilder.Append(<Module>.smethod_8<string>(1466757377u));
										if (espvisual.ShowName)
										{
											stringBuilder.Append(espobject.Object.name);
											stringBuilder.Append(<Module>.smethod_8<string>(2367443386u));
										}
										stringBuilder.Append(<Module>.smethod_5<string>(2979419807u));
									}
									break;
								case ESPTarget.Traps:
									if (espvisual.Labels)
									{
										stringBuilder.Append(<Module>.smethod_5<string>(4247949305u));
										if (espvisual.ShowName)
										{
											stringBuilder.Append(espobject.Object.name);
											stringBuilder.Append(<Module>.smethod_8<string>(2367443386u));
										}
										stringBuilder.Append(<Module>.smethod_4<string>(1361373723u));
									}
									break;
								case ESPTarget.AirDrop:
									if (espvisual.Labels)
									{
										if (espvisual.ShowName)
										{
											stringBuilder.Append(<Module>.smethod_4<string>(2680959486u));
										}
										stringBuilder.Append(<Module>.smethod_8<string>(2955284852u));
									}
									break;
								}
								Vector2[] rectangleLines = DrawUtilities.GetRectangleLines(ESPComponent.MainCamera, bounds);
								if (espvisual.Boxes)
								{
									if (!espvisual.TwoDimensional)
									{
										DrawUtilities.PrepareBoxLines(DrawUtilities.GetBoxVectors(bounds), color);
									}
									else
									{
										DrawUtilities.PrepareRectangleLines(rectangleLines, color);
									}
								}
								if (!espvisual.Glow)
								{
									Highlighter component = gameObject.GetComponent<Highlighter>();
									if (component)
									{
										UnityEngine.Object.DestroyImmediate(component);
										ESPComponent.Highlighters.Remove(component);
									}
								}
								else
								{
									Highlighter highlighter = gameObject.GetComponent<Highlighter>();
									if (!highlighter)
									{
										highlighter = gameObject.AddComponent<Highlighter>();
										ESPComponent.Highlighters.Add(highlighter);
									}
									highlighter.overlay = true;
									highlighter.ConstantOn(ColorUtilities.getColor(string.Format(<Module>.smethod_6<string>(1284414608u), espobject.Target)), 0.25f);
								}
								if (espvisual.Labels)
								{
									LabelLocation location = espvisual.Location;
									Vector2 vector2 = DrawUtilities.Get2DW2SVector(rectangleLines, location);
									if (vector2.x > 0f && vector2.y > 0f && vector2.x < (float)Screen.width && vector2.y < (float)Screen.height)
									{
										if (espvisual.ShowDistance)
										{
											stringBuilder.Insert(0, <Module>.smethod_5<string>(913846972u) + (int)num + <Module>.smethod_6<string>(2338834486u));
										}
										if (espvisual.ShowAngle)
										{
											stringBuilder.Append(<Module>.smethod_5<string>(3498505925u));
											stringBuilder.Append((int)VectorUtilities.GetAngleDelta(position, forward, position2));
											stringBuilder.Append(<Module>.smethod_5<string>(3748320385u));
										}
										stringBuilder.Append(<Module>.smethod_5<string>(1576775999u));
										string newValue = <Module>.smethod_4<string>(3588528356u) + ColorUtilities.getHex(string.Format(<Module>.smethod_8<string>(2506418552u), espobject.Target)) + <Module>.smethod_8<string>(180484994u);
										DrawUtilities.DrawLabel(ESPComponent.ESPFont, location, vector2, stringBuilder.ToString().Replace(<Module>.smethod_6<string>(3434213192u), newValue), color, espvisual.BorderStrength, DrawUtilities.GetTextSize(espvisual, num));
									}
								}
								if (espvisual.LineToObject)
								{
									ESPVariables.DrawBuffer2.Enqueue(new ESPBox2
									{
										Color = color,
										Vertices = new Vector2[]
										{
											new Vector2((float)(Screen.width / 2), (float)Screen.height),
											new Vector2(vector.x, (float)Screen.height - vector.y)
										}
									});
								}
							}
						}
					}
					else
					{
						Highlighter component2 = gameObject.GetComponent<Highlighter>();
						if (component2)
						{
							UnityEngine.Object.DestroyImmediate(component2);
							ESPComponent.Highlighters.Remove(component2);
						}
					}
				}
				IL_CA9:;
			}
			ESPComponent.GLMat.SetPass(0);
			GL.PushMatrix();
			GL.Begin(1);
			int j = 0;
			IL_D77:
			while (j < ESPVariables.DrawBuffer2.Count)
			{
				ESPBox2 espbox = ESPVariables.DrawBuffer2.Dequeue();
				GL.Color(espbox.Color);
				Vector2[] vertices = espbox.Vertices;
				bool flag = true;
				for (int k = 0; k < vertices.Length; k++)
				{
					if (k < vertices.Length - 1 && Vector2.Distance(vertices[k + 1], vertices[k]) > (float)(Screen.width / 2))
					{
						flag = false;
						IL_D37:
						if (flag)
						{
							for (int l = 0; l < vertices.Length; l++)
							{
								GL.Vertex3(vertices[l].x, vertices[l].y, 0f);
							}
						}
						j++;
						goto IL_D77;
					}
				}
				goto IL_D37;
			}
			GL.End();
			GL.LoadProjectionMatrix(ESPComponent.MainCamera.projectionMatrix);
			GL.modelview = ESPComponent.MainCamera.worldToCameraMatrix;
			GL.Begin(1);
			for (int m = 0; m < ESPVariables.DrawBuffer.Count; m++)
			{
				ESPBox espbox2 = ESPVariables.DrawBuffer.Dequeue();
				GL.Color(espbox2.Color);
				Vector3[] vertices2 = espbox2.Vertices;
				for (int n = 0; n < vertices2.Length; n++)
				{
					GL.Vertex(vertices2[n]);
				}
			}
			GL.End();
			GL.PopMatrix();
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000BDC4 File Offset: 0x00009FC4
		[OnSpy]
		public static void DisableHighlighters()
		{
			foreach (Highlighter obj in ESPComponent.Highlighters)
			{
				UnityEngine.Object.DestroyImmediate(obj);
			}
			ESPComponent.Highlighters.Clear();
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00003B67 File Offset: 0x00001D67
		public static string SentryName(Item DisplayItem)
		{
			if (DisplayItem != null)
			{
				return Assets.find(EAssetType.ITEM, DisplayItem.id).name;
			}
			return <Module>.smethod_6<string>(753464779u);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00003B88 File Offset: 0x00001D88
		public static string GetLocked(InteractableVehicle Vehicle)
		{
			if (Vehicle.isLocked)
			{
				return <Module>.smethod_6<string>(312802368u);
			}
			return <Module>.smethod_5<string>(2326219379u);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00003BA7 File Offset: 0x00001DA7
		public static string GetPowered(InteractableGenerator Generator)
		{
			if (Generator.isPowered)
			{
				return <Module>.smethod_6<string>(4006566840u);
			}
			return <Module>.smethod_8<string>(2601338441u);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00003BC6 File Offset: 0x00001DC6
		public static string GetOwned(InteractableBed bed)
		{
			if (bed.isClaimed)
			{
				return <Module>.smethod_7<string>(1301355875u);
			}
			return <Module>.smethod_6<string>(2009383898u);
		}

		// Token: 0x0400008E RID: 142
		public static Material GLMat;

		// Token: 0x0400008F RID: 143
		public static Font ESPFont;

		// Token: 0x04000090 RID: 144
		public static List<Highlighter> Highlighters = new List<Highlighter>();

		// Token: 0x04000091 RID: 145
		public static Camera MainCamera;
	}
}
