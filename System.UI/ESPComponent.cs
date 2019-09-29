using System;
using System.Collections.Generic;
using System.Text;
using HighlightingSystem;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200002E RID: 46
	[Component]
	[SpyComponent]
	public class ESPComponent : MonoBehaviour
	{
		// Token: 0x060000BB RID: 187 RVA: 0x00003B56 File Offset: 0x00001D56
		public void Start()
		{
			base.StartCoroutine(ESPCoroutines.UpdateObjectList());
			base.StartCoroutine(ESPCoroutines.DoChams());
			ESPComponent.MainCamera = OptimizationVariables.MainCam;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00003B7A File Offset: 0x00001D7A
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

		// Token: 0x060000BD RID: 189 RVA: 0x0000ADA8 File Offset: 0x00008FA8
		public void OnGUI()
		{
			if (Event.current.type == EventType.Repaint)
			{
				IL_F94:
				while (ESPOptions.Enabled)
				{
					IL_F88:
					while (DrawUtilities.ShouldRun())
					{
						for (;;)
						{
							IL_F7C:
							ESPComponent.MainCamera = OptimizationVariables.MainCam;
							IL_F6D:
							while (!(ESPComponent.MainCamera == null))
							{
								for (;;)
								{
									IL_F5E:
									GUI.depth = 1;
									if (RaycastOptions.Enabled)
									{
										goto IL_F19;
									}
									for (;;)
									{
										IL_F55:
										if (AimbotOptions.Enabled)
										{
											goto IL_F10;
										}
										for (;;)
										{
											IL_EFE:
											Vector3 position = ESPComponent.MainCamera.transform.position;
											for (;;)
											{
												IL_EBE:
												Vector3 forward = ESPComponent.MainCamera.transform.forward;
												for (;;)
												{
													IL_EBA:
													int i = 0;
													IL_EA5:
													while (i < ESPVariables.Objects.Count)
													{
														ESPObject espobject;
														GameObject gameObject;
														ESPVisual espvisual;
														Vector3 position2;
														float num;
														Vector3 vector;
														Color color;
														StringBuilder stringBuilder;
														Bounds bounds;
														for (;;)
														{
															IL_5A0:
															espobject = ESPVariables.Objects[i];
															IL_58E:
															while (espobject.Object)
															{
																for (;;)
																{
																	IL_57F:
																	gameObject = espobject.Object.gameObject;
																	for (;;)
																	{
																		IL_563:
																		espvisual = ESPOptions.VisualOptions[(int)espobject.Target];
																		if (!espvisual.Enabled)
																		{
																			goto IL_E7B;
																		}
																		for (;;)
																		{
																			IL_553:
																			position2 = gameObject.transform.position;
																			for (;;)
																			{
																				IL_539:
																				num = Vector3.Distance(position2, ESPComponent.MainCamera.transform.position);
																				IL_526:
																				while ((double)num >= 0.5)
																				{
																					for (;;)
																					{
																						IL_519:
																						if (num > espvisual.Distance)
																						{
																							goto IL_4FD;
																						}
																						for (;;)
																						{
																							IL_509:
																							vector = ESPComponent.MainCamera.WorldToScreenPoint(position2);
																							IL_4EA:
																							while (vector.z > 0f)
																							{
																								for (;;)
																								{
																									IL_4E0:
																									ESPTarget target = espobject.Target;
																									for (;;)
																									{
																										IL_4D6:
																										if (target <= ESPTarget.Zombies)
																										{
																											goto IL_3E3;
																										}
																										goto IL_4CC;
																										for (;;)
																										{
																											IL_454:
																											color = ColorUtilities.getColor("_" + espobject.Target);
																											for (;;)
																											{
																												IL_3DA:
																												stringBuilder = new StringBuilder();
																												for (;;)
																												{
																													IL_3D0:
																													ESPTarget target2 = espobject.Target;
																													for (;;)
																													{
																														IL_390:
																														switch (target2)
																														{
																														case ESPTarget.Players:
																															goto IL_5AE;
																														case ESPTarget.Zombies:
																															goto IL_724;
																														case ESPTarget.Items:
																															goto IL_786;
																														case ESPTarget.Sentries:
																															goto IL_7D7;
																														case ESPTarget.Beds:
																															goto IL_840;
																														case ESPTarget.ClaimFlags:
																															goto IL_8A4;
																														case ESPTarget.Vehicles:
																															goto IL_8D8;
																														case ESPTarget.Storage:
																															goto IL_9FA;
																														case ESPTarget.Generators:
																															goto IL_A4E;
																														case ESPTarget.Animals:
																															goto IL_ADD;
																														case ESPTarget.Farm:
																															goto IL_B4B;
																														case ESPTarget.Traps:
																															goto IL_B9C;
																														case ESPTarget.AirDrop:
																															goto IL_BEA;
																														default:
																														{
																															uint num3;
																															uint num2 = num3 * 2973310730u ^ 3581897595u;
																															for (;;)
																															{
																																switch ((num3 = (num2 ^ 1526056175u)) % 209u)
																																{
																																case 0u:
																																	goto IL_10F7;
																																case 1u:
																																	goto IL_ACB;
																																case 2u:
																																	goto IL_910;
																																case 3u:
																																	goto IL_B9C;
																																case 4u:
																																	goto IL_4D6;
																																case 5u:
																																case 169u:
																																	goto IL_1067;
																																case 6u:
																																	goto IL_79B;
																																case 7u:
																																	goto IL_C92;
																																case 8u:
																																	goto IL_509;
																																case 9u:
																																	num2 = (num3 * 374903410u ^ 1406606291u);
																																	continue;
																																case 10u:
																																	goto IL_D49;
																																case 11u:
																																	goto IL_B4B;
																																case 12u:
																																	goto IL_61C;
																																case 13u:
																																	goto IL_563;
																																case 14u:
																																	goto IL_FB2;
																																case 15u:
																																	goto IL_B02;
																																case 16u:
																																	goto IL_8B0;
																																case 17u:
																																	goto IL_C58;
																																case 18u:
																																	goto IL_D2E;
																																case 19u:
																																	goto IL_F5E;
																																case 20u:
																																	goto IL_C2D;
																																case 21u:
																																	goto IL_102D;
																																case 22u:
																																	goto IL_630;
																																case 23u:
																																	goto IL_DAB;
																																case 24u:
																																	goto IL_1017;
																																case 25u:
																																	goto IL_745;
																																case 26u:
																																	goto IL_FEE;
																																case 27u:
																																	goto IL_48F;
																																case 28u:
																																	goto IL_C6A;
																																case 29u:
																																	goto IL_390;
																																case 30u:
																																	return;
																																case 31u:
																																	goto IL_3DA;
																																case 32u:
																																	goto IL_D7F;
																																case 33u:
																																	goto IL_10C7;
																																case 34u:
																																	goto IL_AF6;
																																case 35u:
																																	goto IL_49A;
																																case 36u:
																																	goto IL_4EA;
																																case 37u:
																																	goto IL_5CC;
																																case 38u:
																																	goto IL_10A1;
																																case 39u:
																																	goto IL_82E;
																																case 40u:
																																	goto IL_8B9;
																																case 41u:
																																	goto IL_1061;
																																case 42u:
																																	goto IL_D91;
																																case 43u:
																																	return;
																																case 44u:
																																	goto IL_F19;
																																case 45u:
																																	goto IL_6CC;
																																case 46u:
																																	goto IL_F27;
																																case 47u:
																																	goto IL_57F;
																																case 48u:
																																	goto IL_D1C;
																																case 49u:
																																case 97u:
																																case 119u:
																																case 163u:
																																case 193u:
																																	goto IL_C16;
																																case 50u:
																																	goto IL_519;
																																case 51u:
																																	goto IL_B80;
																																case 52u:
																																	goto IL_821;
																																case 53u:
																																	goto IL_994;
																																case 54u:
																																	goto IL_B6D;
																																case 55u:
																																case 64u:
																																case 157u:
																																	goto IL_454;
																																case 56u:
																																	goto IL_F10;
																																case 57u:
																																	goto IL_99F;
																																case 58u:
																																	goto IL_9FA;
																																case 59u:
																																	goto IL_892;
																																case 60u:
																																	goto IL_CA7;
																																case 61u:
																																	goto IL_3E3;
																																case 62u:
																																	goto IL_EBA;
																																case 63u:
																																	goto IL_A4E;
																																case 65u:
																																	goto IL_94E;
																																case 66u:
																																	goto IL_446;
																																case 67u:
																																	goto IL_10C2;
																																case 68u:
																																	goto IL_553;
																																case 69u:
																																	goto IL_47A;
																																case 70u:
																																	goto IL_92D;
																																case 71u:
																																	goto IL_B8D;
																																case 72u:
																																	goto IL_9C2;
																																case 73u:
																																	goto IL_672;
																																case 74u:
																																	goto IL_9CF;
																																case 76u:
																																	goto IL_D69;
																																case 77u:
																																case 186u:
																																	goto IL_10DB;
																																case 78u:
																																	goto IL_EA5;
																																case 79u:
																																	goto IL_BBB;
																																case 80u:
																																	goto IL_3D0;
																																case 81u:
																																	goto IL_10E9;
																																case 82u:
																																	goto IL_885;
																																case 83u:
																																case 112u:
																																	goto IL_1059;
																																case 84u:
																																	goto IL_1078;
																																case 85u:
																																	goto IL_ABE;
																																case 86u:
																																	goto IL_8D8;
																																case 87u:
																																	goto IL_CDA;
																																case 88u:
																																	goto IL_B57;
																																case 89u:
																																	goto IL_86F;
																																case 90u:
																																	goto IL_F20;
																																case 91u:
																																	return;
																																case 92u:
																																	goto IL_FE4;
																																case 93u:
																																	goto IL_FAD;
																																case 94u:
																																	goto IL_1028;
																																case 95u:
																																	goto IL_739;
																																case 96u:
																																	goto IL_C71;
																																case 98u:
																																	goto IL_6B5;
																																case 99u:
																																	goto IL_C09;
																																case 100u:
																																	goto IL_B64;
																																case 101u:
																																	goto IL_9D9;
																																case 102u:
																																	goto IL_C24;
																																case 103u:
																																	goto IL_919;
																																case 104u:
																																	goto IL_BA5;
																																case 105u:
																																	goto IL_10A6;
																																case 106u:
																																	goto IL_A5A;
																																case 107u:
																																	goto IL_66B;
																																case 108u:
																																	goto IL_876;
																																case 109u:
																																	goto IL_840;
																																case 110u:
																																	goto IL_7D7;
																																case 111u:
																																	goto IL_F88;
																																case 113u:
																																	goto IL_FDC;
																																case 114u:
																																	goto IL_786;
																																case 115u:
																																	goto IL_4CC;
																																case 116u:
																																	goto IL_AA8;
																																case 117u:
																																	goto IL_E7B;
																																case 118u:
																																	goto IL_1011;
																																case 120u:
																																	goto IL_58E;
																																case 121u:
																																	goto IL_EA1;
																																case 122u:
																																	goto IL_FC0;
																																case 123u:
																																	goto IL_526;
																																case 124u:
																																	goto IL_9AC;
																																case 125u:
																																	goto IL_7E3;
																																case 126u:
																																	goto IL_D40;
																																case 127u:
																																	goto IL_B0F;
																																case 128u:
																																	goto IL_FB8;
																																case 129u:
																																	goto IL_D9E;
																																case 130u:
																																	goto IL_E84;
																																case 131u:
																																case 151u:
																																	goto IL_1024;
																																case 132u:
																																	goto IL_F55;
																																case 133u:
																																	goto IL_1021;
																																case 134u:
																																	goto IL_8E4;
																																case 135u:
																																	goto IL_ADD;
																																case 136u:
																																	goto IL_BDB;
																																case 137u:
																																	goto IL_E8D;
																																case 138u:
																																	goto IL_539;
																																case 139u:
																																	goto IL_8FD;
																																case 140u:
																																	goto IL_10E3;
																																case 141u:
																																	goto IL_7C5;
																																case 142u:
																																	goto IL_74E;
																																case 143u:
																																	goto IL_5E1;
																																case 144u:
																																	goto IL_10FC;
																																case 145u:
																																	goto IL_BFC;
																																case 146u:
																																	goto IL_AAF;
																																case 147u:
																																	goto IL_F6D;
																																case 148u:
																																	goto IL_774;
																																case 149u:
																																	goto IL_98D;
																																case 150u:
																																	goto IL_A06;
																																case 152u:
																																	goto IL_806;
																																case 153u:
																																	goto IL_C46;
																																case 154u:
																																	goto IL_5AE;
																																case 155u:
																																	goto IL_C36;
																																case 156u:
																																	goto IL_A3C;
																																case 158u:
																																	goto IL_65E;
																																case 159u:
																																	goto IL_4E0;
																																case 160u:
																																	goto IL_BB2;
																																case 161u:
																																	goto IL_70E;
																																case 162u:
																																	goto IL_107D;
																																case 164u:
																																	goto IL_8A4;
																																case 165u:
																																	goto IL_792;
																																case 166u:
																																	goto IL_AEA;
																																case 167u:
																																	goto IL_862;
																																case 168u:
																																	goto IL_4FD;
																																case 170u:
																																	goto IL_C4F;
																																case 171u:
																																	goto IL_A1C;
																																case 172u:
																																	goto IL_C80;
																																case 173u:
																																	goto IL_CAF;
																																case 174u:
																																	goto IL_8C6;
																																case 175u:
																																case 188u:
																																	goto IL_F94;
																																case 176u:
																																	goto IL_702;
																																case 177u:
																																	goto IL_E15;
																																case 178u:
																																	goto IL_B18;
																																case 179u:
																																	goto IL_FA1;
																																case 180u:
																																	goto IL_7F9;
																																case 181u:
																																	goto IL_5BB;
																																case 182u:
																																	goto IL_B39;
																																case 183u:
																																	goto IL_724;
																																case 184u:
																																	goto IL_EFE;
																																case 185u:
																																	goto IL_E94;
																																case 187u:
																																	goto IL_8F1;
																																case 189u:
																																	goto IL_D0B;
																																case 190u:
																																	goto IL_904;
																																case 191u:
																																	goto IL_A6E;
																																case 192u:
																																	goto IL_F7C;
																																case 194u:
																																	goto IL_C89;
																																case 195u:
																																	goto IL_ED0;
																																case 196u:
																																	goto IL_5A0;
																																case 197u:
																																	goto IL_80D;
																																case 198u:
																																	goto IL_BEA;
																																case 199u:
																																	goto IL_109B;
																																case 200u:
																																	goto IL_93A;
																																case 201u:
																																	goto IL_BF3;
																																case 202u:
																																	goto IL_84C;
																																case 203u:
																																	goto IL_A7B;
																																case 204u:
																																	goto IL_CE6;
																																case 205u:
																																	goto IL_5D8;
																																case 206u:
																																	goto IL_E09;
																																case 207u:
																																	goto IL_D72;
																																case 208u:
																																	goto IL_EBE;
																																}
																																goto Block_2;
																															}
																															break;
																														}
																														}
																													}
																												}
																											}
																										}
																										IL_3E3:
																										Vector3 localScale = gameObject.transform.localScale;
																										bounds = new Bounds(new Vector3(position2.x, position2.y + 1.1f, position2.z), new Vector3(localScale.x * 1.8f, localScale.y * 2.6f, localScale.z * 1.8f));
																										goto IL_454;
																										IL_446:
																										bounds = gameObject.GetComponent<Collider>().bounds;
																										goto IL_454;
																										IL_4CC:
																										if (target != ESPTarget.Vehicles)
																										{
																											goto IL_446;
																										}
																										goto IL_49A;
																										IL_47A:
																										Transform transform;
																										bounds.Encapsulate(transform.GetComponent<MeshRenderer>().bounds);
																										goto IL_454;
																										IL_48F:
																										if (!transform)
																										{
																											goto IL_454;
																										}
																										goto IL_47A;
																										IL_49A:
																										bounds = gameObject.transform.Find("Model_0").GetComponent<MeshRenderer>().bounds;
																										transform = gameObject.transform.Find("Model_1");
																										goto IL_48F;
																									}
																								}
																							}
																							goto IL_EA1;
																						}
																						IL_4FD:
																						if (espvisual.InfiniteDistance)
																						{
																							goto IL_509;
																						}
																						goto IL_EA1;
																					}
																				}
																				goto IL_EA1;
																			}
																		}
																	}
																}
															}
															break;
														}
														IL_EA1:
														i++;
														continue;
														goto IL_EA1;
														IL_5BB:
														Player player;
														if (!player.life.isDead)
														{
															goto IL_5CC;
														}
														goto IL_EA1;
														IL_5AE:
														player = (Player)espobject.Object;
														goto IL_5BB;
														IL_724:
														if (!((Zombie)espobject.Object).isDead)
														{
															goto IL_739;
														}
														goto IL_EA1;
														IL_8F1:
														InteractableVehicle interactableVehicle;
														if (interactableVehicle.health != 0)
														{
															goto IL_8FD;
														}
														goto IL_EA1;
														IL_8E4:
														interactableVehicle = (InteractableVehicle)espobject.Object;
														goto IL_8F1;
														IL_8D8:
														if (espvisual.Labels)
														{
															goto IL_8E4;
														}
														goto IL_C16;
														IL_904:
														if (!interactableVehicle.isLocked)
														{
															goto IL_910;
														}
														goto IL_EA1;
														IL_8FD:
														if (ESPOptions.FilterVehicleLocked)
														{
															goto IL_904;
														}
														goto IL_910;
														IL_AEA:
														Animal animal;
														if (!animal.isDead)
														{
															goto IL_AF6;
														}
														goto IL_EA1;
														IL_ADD:
														animal = (Animal)espobject.Object;
														goto IL_AEA;
														IL_E09:
														if (espvisual.LineToObject)
														{
															goto IL_E15;
														}
														goto IL_EA1;
														IL_DAB:
														string newValue = "<color=#" + ColorUtilities.getHex(string.Format("_{0}_Info", espobject.Target)) + ">";
														LabelLocation location;
														Vector2 vector2;
														DrawUtilities.DrawLabel(ESPComponent.ESPFont, location, vector2, stringBuilder.ToString().Replace("<color=#FFFFFF>", newValue), color, espvisual.BorderStrength, DrawUtilities.GetTextSize(espvisual, num));
														goto IL_E09;
														IL_D9E:
														stringBuilder.Append("</color>");
														goto IL_DAB;
														IL_D91:
														stringBuilder.Append("°\n");
														goto IL_D9E;
														IL_D7F:
														stringBuilder.Append((int)VectorUtilities.GetAngleDelta(position, forward, position2));
														goto IL_D91;
														IL_D72:
														stringBuilder.Append("Угол: ");
														goto IL_D7F;
														IL_D69:
														if (espvisual.ShowAngle)
														{
															goto IL_D72;
														}
														goto IL_D9E;
														IL_D49:
														stringBuilder.Insert(0, "<color=#FFFFFF>[" + (int)num + "]</color> ");
														goto IL_D69;
														IL_D40:
														if (espvisual.ShowDistance)
														{
															goto IL_D49;
														}
														goto IL_D69;
														IL_D2E:
														if (vector2.y < (float)Screen.height)
														{
															goto IL_D40;
														}
														goto IL_E09;
														IL_D1C:
														if (vector2.x < (float)Screen.width)
														{
															goto IL_D2E;
														}
														goto IL_E09;
														IL_D0B:
														if (vector2.y > 0f)
														{
															goto IL_D1C;
														}
														goto IL_E09;
														IL_CE6:
														location = espvisual.Location;
														Vector2[] rectangleLines;
														vector2 = DrawUtilities.Get2DW2SVector(rectangleLines, location);
														if (vector2.x > 0f)
														{
															goto IL_D0B;
														}
														goto IL_E09;
														IL_CDA:
														if (espvisual.Labels)
														{
															goto IL_CE6;
														}
														goto IL_E09;
														IL_CAF:
														Highlighter highlighter;
														highlighter.ConstantOn(ColorUtilities.getColor(string.Format("_{0}_Glow", espobject.Target)), 0.25f);
														goto IL_CDA;
														IL_CA7:
														highlighter.overlay = true;
														goto IL_CAF;
														IL_C92:
														highlighter = gameObject.AddComponent<Highlighter>();
														ESPComponent.Highlighters.Add(highlighter);
														goto IL_CA7;
														IL_C89:
														if (!highlighter)
														{
															goto IL_C92;
														}
														goto IL_CA7;
														IL_C80:
														highlighter = gameObject.GetComponent<Highlighter>();
														goto IL_C89;
														IL_C4F:
														if (!espvisual.Glow)
														{
															goto IL_C58;
														}
														goto IL_C80;
														IL_C46:
														DrawUtilities.PrepareRectangleLines(rectangleLines, color);
														goto IL_C4F;
														IL_C2D:
														if (espvisual.TwoDimensional)
														{
															goto IL_C46;
														}
														IL_C36:
														DrawUtilities.PrepareBoxLines(DrawUtilities.GetBoxVectors(bounds), color);
														goto IL_C4F;
														IL_C24:
														if (espvisual.Boxes)
														{
															goto IL_C2D;
														}
														goto IL_C4F;
														IL_C16:
														rectangleLines = DrawUtilities.GetRectangleLines(ESPComponent.MainCamera, bounds);
														goto IL_C24;
														IL_840:
														if (espvisual.Labels)
														{
															goto IL_84C;
														}
														goto IL_C16;
														IL_82E:
														stringBuilder.Append("<color=#FFFFFF>");
														goto IL_C16;
														IL_821:
														stringBuilder.Append("\n");
														goto IL_82E;
														IL_80D:
														InteractableSentry interactableSentry;
														stringBuilder.Append(ESPComponent.SentryName(interactableSentry.displayItem));
														goto IL_821;
														IL_806:
														if (ESPOptions.ShowSentryItem)
														{
															goto IL_80D;
														}
														goto IL_82E;
														IL_7F9:
														stringBuilder.Append("Турель\n");
														goto IL_806;
														IL_7E3:
														interactableSentry = (InteractableSentry)espobject.Object;
														if (espvisual.ShowName)
														{
															goto IL_7F9;
														}
														goto IL_806;
														IL_7D7:
														if (espvisual.Labels)
														{
															goto IL_7E3;
														}
														goto IL_C16;
														IL_7C5:
														stringBuilder.Append("<color=#FFFFFF>");
														goto IL_C16;
														IL_79B:
														stringBuilder.Append(((InteractableItem)espobject.Object).asset.itemName);
														stringBuilder.Append("\n");
														goto IL_7C5;
														IL_792:
														if (espvisual.ShowName)
														{
															goto IL_79B;
														}
														goto IL_7C5;
														IL_786:
														if (espvisual.Labels)
														{
															goto IL_792;
														}
														goto IL_C16;
														IL_774:
														stringBuilder.Append("<color=#FFFFFF>");
														goto IL_C16;
														IL_74E:
														stringBuilder.Append(((Zombie)espobject.Object).isMega ? "Мега Зомби" : "Зомби\n");
														goto IL_774;
														IL_745:
														if (espvisual.ShowName)
														{
															goto IL_74E;
														}
														goto IL_774;
														IL_739:
														if (espvisual.Labels)
														{
															goto IL_745;
														}
														goto IL_C16;
														IL_70E:
														color = ColorUtilities.getColor("_ESPFriendly");
														goto IL_C16;
														IL_702:
														if (FriendUtilities.IsFriendly(player))
														{
															goto IL_70E;
														}
														goto IL_C16;
														IL_6CC:
														bounds.size = new Vector3(bounds.size.x, bounds.size.y * 1.25f, bounds.size.z);
														goto IL_702;
														IL_6B5:
														bounds.size /= 2f;
														goto IL_6CC;
														IL_672:
														stringBuilder.Append((player.movement.getVehicle() != null) ? (player.movement.getVehicle().asset.name + "\n") : "Нет машины\n");
														goto IL_6B5;
														IL_66B:
														if (ESPOptions.ShowPlayerVehicle)
														{
															goto IL_672;
														}
														goto IL_6B5;
														IL_65E:
														stringBuilder.Append("\n");
														goto IL_66B;
														IL_630:
														stringBuilder.Append((player.equipment.asset != null) ? player.equipment.asset.itemName : "Нет оружия");
														goto IL_65E;
														IL_61C:
														stringBuilder.Append("<color=#FFFFFF>");
														if (ESPOptions.ShowPlayerWeapon)
														{
															goto IL_630;
														}
														goto IL_66B;
														IL_5E1:
														stringBuilder.Append(ESPOptions.FullName ? player.name : player.channel.owner.playerID.characterName);
														stringBuilder.Append("\n");
														goto IL_61C;
														IL_5D8:
														if (espvisual.ShowName)
														{
															goto IL_5E1;
														}
														goto IL_61C;
														IL_5CC:
														if (espvisual.Labels)
														{
															goto IL_5D8;
														}
														goto IL_6B5;
														IL_C71:
														Highlighter component;
														ESPComponent.Highlighters.Remove(component);
														goto IL_CDA;
														IL_C6A:
														UnityEngine.Object.DestroyImmediate(component);
														goto IL_C71;
														IL_C58:
														component = gameObject.GetComponent<Highlighter>();
														if (component)
														{
															goto IL_C6A;
														}
														goto IL_CDA;
														IL_E15:
														ESPVariables.DrawBuffer2.Enqueue(new ESPBox2
														{
															Color = color,
															Vertices = new Vector2[]
															{
																new Vector2((float)(Screen.width / 2), (float)Screen.height),
																new Vector2(vector.x, (float)Screen.height - vector.y)
															}
														});
														goto IL_EA1;
														IL_E84:
														Highlighter component2;
														if (component2)
														{
															goto IL_E8D;
														}
														goto IL_EA1;
														IL_E7B:
														component2 = gameObject.GetComponent<Highlighter>();
														goto IL_E84;
														IL_E94:
														ESPComponent.Highlighters.Remove(component2);
														goto IL_EA1;
														IL_E8D:
														UnityEngine.Object.DestroyImmediate(component2);
														goto IL_E94;
														IL_892:
														stringBuilder.Append("<color=#FFFFFF>");
														goto IL_C16;
														IL_885:
														stringBuilder.Append("\n");
														goto IL_892;
														IL_876:
														InteractableBed bed;
														stringBuilder.Append(ESPComponent.GetOwned(bed));
														goto IL_885;
														IL_86F:
														if (ESPOptions.ShowClaimed)
														{
															goto IL_876;
														}
														goto IL_892;
														IL_862:
														stringBuilder.Append("Кровать\n");
														goto IL_86F;
														IL_84C:
														bed = (InteractableBed)espobject.Object;
														if (espvisual.ShowName)
														{
															goto IL_862;
														}
														goto IL_86F;
														IL_8A4:
														if (espvisual.Labels)
														{
															goto IL_8B0;
														}
														goto IL_C16;
														IL_8C6:
														stringBuilder.Append("<color=#FFFFFF>");
														goto IL_C16;
														IL_8B9:
														stringBuilder.Append("Клейм флаг\n");
														goto IL_8C6;
														IL_8B0:
														if (espvisual.ShowName)
														{
															goto IL_8B9;
														}
														goto IL_8C6;
														IL_9CF:
														if (ESPOptions.ShowVehicleLocked)
														{
															goto IL_9D9;
														}
														goto IL_C16;
														IL_9C2:
														stringBuilder.Append("%\n");
														goto IL_9CF;
														IL_9AC:
														ushort num4;
														ushort num5;
														stringBuilder.Append((int)(100f * (float)num4 / (float)num5));
														goto IL_9C2;
														IL_99F:
														stringBuilder.Append("Топливо: ");
														goto IL_9AC;
														IL_994:
														interactableVehicle.getDisplayFuel(out num4, out num5);
														goto IL_99F;
														IL_98D:
														if (ESPOptions.ShowVehicleFuel)
														{
															goto IL_994;
														}
														goto IL_9CF;
														IL_94E:
														stringBuilder.Append("Жизни: ");
														stringBuilder.Append((int)(100f * (float)interactableVehicle.health / (float)interactableVehicle.asset.health));
														stringBuilder.Append("%\n");
														goto IL_98D;
														IL_93A:
														stringBuilder.Append("<color=#FFFFFF>");
														if (ESPOptions.ShowVehicleHealth)
														{
															goto IL_94E;
														}
														goto IL_98D;
														IL_92D:
														stringBuilder.Append("\n");
														goto IL_93A;
														IL_919:
														stringBuilder.Append(interactableVehicle.asset.name);
														goto IL_92D;
														IL_910:
														if (espvisual.ShowName)
														{
															goto IL_919;
														}
														goto IL_93A;
														IL_9D9:
														stringBuilder.Append(ESPComponent.GetLocked(interactableVehicle));
														stringBuilder.Append("\n");
														goto IL_C16;
														IL_9FA:
														if (espvisual.Labels)
														{
															goto IL_A06;
														}
														goto IL_C16;
														IL_A3C:
														stringBuilder.Append("<color=#FFFFFF>");
														goto IL_C16;
														IL_A1C:
														stringBuilder.Append(espobject.Object.name);
														stringBuilder.Append("\n");
														goto IL_A3C;
														IL_A06:
														stringBuilder.Append("Сундук ");
														if (espvisual.ShowName)
														{
															goto IL_A1C;
														}
														goto IL_A3C;
														IL_A4E:
														if (espvisual.Labels)
														{
															goto IL_A5A;
														}
														goto IL_C16;
														IL_ACB:
														stringBuilder.Append("<color=#FFFFFF>");
														goto IL_C16;
														IL_ABE:
														stringBuilder.Append("\n");
														goto IL_ACB;
														IL_AAF:
														InteractableGenerator interactableGenerator;
														stringBuilder.Append(ESPComponent.GetPowered(interactableGenerator));
														goto IL_ABE;
														IL_AA8:
														if (ESPOptions.ShowGeneratorPowered)
														{
															goto IL_AAF;
														}
														goto IL_ACB;
														IL_A7B:
														stringBuilder.Append((int)(100f * (float)interactableGenerator.fuel / (float)interactableGenerator.capacity));
														stringBuilder.Append("%\n");
														goto IL_AA8;
														IL_A6E:
														stringBuilder.Append("Топливо: ");
														goto IL_A7B;
														IL_A5A:
														interactableGenerator = (InteractableGenerator)espobject.Object;
														if (ESPOptions.ShowGeneratorFuel)
														{
															goto IL_A6E;
														}
														goto IL_AA8;
														IL_AF6:
														if (espvisual.Labels)
														{
															goto IL_B02;
														}
														goto IL_C16;
														IL_B39:
														stringBuilder.Append("<color=#FFFFFF>");
														goto IL_C16;
														IL_B18:
														stringBuilder.Append(animal.asset.animalName);
														stringBuilder.Append("\n");
														goto IL_B39;
														IL_B0F:
														if (espvisual.ShowName)
														{
															goto IL_B18;
														}
														goto IL_B39;
														IL_B02:
														stringBuilder.Append("Животное\n");
														goto IL_B0F;
														IL_B4B:
														if (espvisual.Labels)
														{
															goto IL_B57;
														}
														goto IL_C16;
														IL_B8D:
														stringBuilder.Append("<color=#FFFFFF>");
														goto IL_C16;
														IL_B80:
														stringBuilder.Append("\n");
														goto IL_B8D;
														IL_B6D:
														stringBuilder.Append(espobject.Object.name);
														goto IL_B80;
														IL_B64:
														if (espvisual.ShowName)
														{
															goto IL_B6D;
														}
														goto IL_B8D;
														IL_B57:
														stringBuilder.Append("Растение\n");
														goto IL_B64;
														IL_B9C:
														if (espvisual.Labels)
														{
															goto IL_BA5;
														}
														goto IL_C16;
														IL_BDB:
														stringBuilder.Append("<color=#FFFFFF>");
														goto IL_C16;
														IL_BBB:
														stringBuilder.Append(espobject.Object.name);
														stringBuilder.Append("\n");
														goto IL_BDB;
														IL_BB2:
														if (espvisual.ShowName)
														{
															goto IL_BBB;
														}
														goto IL_BDB;
														IL_BA5:
														stringBuilder.Append("Ловушка\n");
														goto IL_BB2;
														IL_BEA:
														if (espvisual.Labels)
														{
															goto IL_BF3;
														}
														goto IL_C16;
														IL_C09:
														stringBuilder.Append("<color=#FFFFFF>");
														goto IL_C16;
														IL_BF3:
														if (!espvisual.ShowName)
														{
															goto IL_C09;
														}
														IL_BFC:
														stringBuilder.Append("АирДроп\n");
														goto IL_C09;
													}
													goto IL_FA1;
												}
											}
										}
										IL_F10:
										if (!MiscOptions.ShowAimFOV)
										{
											goto IL_EFE;
										}
										IL_ED0:
										DrawUtilities.DrawCircle(ESPComponent.GLMat, Color.white, new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), VectorUtilities.FOVRadius(AimbotOptions.FOV));
										goto IL_EFE;
									}
									IL_F19:
									if (!MiscOptions.ShowSilentFOV)
									{
										goto IL_F55;
									}
									IL_F20:
									if (!RaycastOptions.SilentAimUseFOV)
									{
										goto IL_F55;
									}
									IL_F27:
									DrawUtilities.DrawCircle(ESPComponent.GLMat, Color.red, new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), VectorUtilities.FOVRadius(RaycastOptions.SilentAimFOV));
									goto IL_F55;
								}
							}
							return;
						}
						Block_2:
						return;
						IL_FA1:
						ESPComponent.GLMat.SetPass(0);
						IL_FAD:
						GL.PushMatrix();
						IL_FB2:
						GL.Begin(1);
						IL_FB8:
						int num6 = 0;
						goto IL_1067;
						IL_FC0:
						ESPBox2 espbox = ESPVariables.DrawBuffer2.Dequeue();
						GL.Color(espbox.Color);
						Vector2[] vertices = espbox.Vertices;
						IL_FDC:
						bool flag = true;
						int num7 = 0;
						goto IL_1017;
						IL_FE4:
						if (num7 >= vertices.Length - 1)
						{
							goto IL_1011;
						}
						IL_FEE:
						if (Vector2.Distance(vertices[num7 + 1], vertices[num7]) > (float)(Screen.width / 2))
						{
							goto IL_1021;
						}
						IL_1011:
						num7++;
						IL_1017:
						if (num7 >= vertices.Length)
						{
							goto IL_1024;
						}
						goto IL_FE4;
						IL_1021:
						flag = false;
						IL_1024:
						if (!flag)
						{
							goto IL_1061;
						}
						IL_1028:
						int num8 = 0;
						goto IL_1059;
						IL_102D:
						GL.Vertex3(vertices[num8].x, vertices[num8].y, 0f);
						num8++;
						IL_1059:
						if (num8 < vertices.Length)
						{
							goto IL_102D;
						}
						IL_1061:
						num6++;
						IL_1067:
						if (num6 < ESPVariables.DrawBuffer2.Count)
						{
							goto IL_FC0;
						}
						IL_1078:
						GL.End();
						IL_107D:
						GL.LoadProjectionMatrix(ESPComponent.MainCamera.projectionMatrix);
						GL.modelview = ESPComponent.MainCamera.worldToCameraMatrix;
						IL_109B:
						GL.Begin(1);
						IL_10A1:
						int num9 = 0;
						goto IL_10E9;
						IL_10A6:
						ESPBox espbox2 = ESPVariables.DrawBuffer.Dequeue();
						GL.Color(espbox2.Color);
						Vector3[] vertices2 = espbox2.Vertices;
						IL_10C2:
						int num10 = 0;
						goto IL_10DB;
						IL_10C7:
						GL.Vertex(vertices2[num10]);
						num10++;
						IL_10DB:
						if (num10 < vertices2.Length)
						{
							goto IL_10C7;
						}
						IL_10E3:
						num9++;
						IL_10E9:
						if (num9 < ESPVariables.DrawBuffer.Count)
						{
							goto IL_10A6;
						}
						IL_10F7:
						GL.End();
						IL_10FC:
						GL.PopMatrix();
						return;
					}
					return;
				}
			}
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000BEB8 File Offset: 0x0000A0B8
		[OnSpy]
		public static void DisableHighlighters()
		{
			foreach (Highlighter obj in ESPComponent.Highlighters)
			{
				UnityEngine.Object.DestroyImmediate(obj);
			}
			ESPComponent.Highlighters.Clear();
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00003B96 File Offset: 0x00001D96
		public static string SentryName(Item DisplayItem)
		{
			if (DisplayItem != null)
			{
				return Assets.find(EAssetType.ITEM, DisplayItem.id).name;
			}
			return "Нет оружия";
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00003BB2 File Offset: 0x00001DB2
		public static string GetLocked(InteractableVehicle Vehicle)
		{
			if (Vehicle.isLocked)
			{
				return "ЗАКРЫТ";
			}
			return "ОТКРЫТ";
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00003BC7 File Offset: 0x00001DC7
		public static string GetPowered(InteractableGenerator Generator)
		{
			if (Generator.isPowered)
			{
				return "ВКЛ";
			}
			return "ВЫКЛ";
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00003BDC File Offset: 0x00001DDC
		public static string GetOwned(InteractableBed bed)
		{
			if (bed.isClaimed)
			{
				return "ЗАНЯТО";
			}
			return "НЕ ЗАНЯТО";
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
