﻿using System;
using System.Reflection;
using SDG.Framework.Utilities;
using SDG.Unturned;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200007D RID: 125
	public class OV_PlayerInteract
	{
		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x0000456C File Offset: 0x0000276C
		// (set) Token: 0x060001D4 RID: 468 RVA: 0x0000457E File Offset: 0x0000277E
		public static Transform focus
		{
			get
			{
				return (Transform)OV_PlayerInteract.FocusField.GetValue(null);
			}
			set
			{
				OV_PlayerInteract.FocusField.SetValue(null, value);
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x0000458C File Offset: 0x0000278C
		// (set) Token: 0x060001D6 RID: 470 RVA: 0x0000459E File Offset: 0x0000279E
		public static Transform target
		{
			get
			{
				return (Transform)OV_PlayerInteract.TargetField.GetValue(null);
			}
			set
			{
				OV_PlayerInteract.TargetField.SetValue(null, value);
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x000045AC File Offset: 0x000027AC
		// (set) Token: 0x060001D8 RID: 472 RVA: 0x000045BE File Offset: 0x000027BE
		public static Interactable interactable
		{
			get
			{
				return (Interactable)OV_PlayerInteract.InteractableField.GetValue(null);
			}
			set
			{
				OV_PlayerInteract.InteractableField.SetValue(null, value);
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x000045CC File Offset: 0x000027CC
		// (set) Token: 0x060001DA RID: 474 RVA: 0x000045DE File Offset: 0x000027DE
		public static Interactable2 interactable2
		{
			get
			{
				return (Interactable2)OV_PlayerInteract.Interactable2Field.GetValue(null);
			}
			set
			{
				OV_PlayerInteract.Interactable2Field.SetValue(null, value);
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060001DB RID: 475 RVA: 0x000045EC File Offset: 0x000027EC
		// (set) Token: 0x060001DC RID: 476 RVA: 0x000045FE File Offset: 0x000027FE
		public static ItemAsset purchaseAsset
		{
			get
			{
				return (ItemAsset)OV_PlayerInteract.PurchaseAssetField.GetValue(null);
			}
			set
			{
				OV_PlayerInteract.PurchaseAssetField.SetValue(null, value);
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060001DD RID: 477 RVA: 0x0000460C File Offset: 0x0000280C
		private float salvageTime
		{
			get
			{
				if (MiscOptions.CustomSalvageTime)
				{
					return MiscOptions.SalvageTime;
				}
				if (!OptimizationVariables.MainPlayer.channel.owner.isAdmin)
				{
					return 8f;
				}
				return 1f;
			}
		}

		// Token: 0x060001DE RID: 478 RVA: 0x0000463C File Offset: 0x0000283C
		private void hotkey(byte button)
		{
			VehicleManager.swapVehicle(button);
		}

		// Token: 0x060001DF RID: 479 RVA: 0x00011DB4 File Offset: 0x0000FFB4
		[Override(typeof(PlayerInteract), "Update", BindingFlags.Instance | BindingFlags.NonPublic, 0)]
		public void OV_Update()
		{
			if (!DrawUtilities.ShouldRun())
			{
				return;
			}
			if (OptimizationVariables.MainPlayer.stance.stance != EPlayerStance.DRIVING)
			{
				if (OptimizationVariables.MainPlayer.stance.stance != EPlayerStance.SITTING)
				{
					if (!OptimizationVariables.MainPlayer.life.isDead && !OptimizationVariables.MainPlayer.workzone.isBuilding)
					{
						if (Time.realtimeSinceStartup - OV_PlayerInteract.lastInteract > 0.1f)
						{
							int num = 0;
							if (InteractionOptions.InteractThroughWalls && !PlayerCoroutines.IsSpying)
							{
								if (!InteractionOptions.NoHitBarricades)
								{
									num |= RayMasks.BARRICADE;
								}
								if (!InteractionOptions.NoHitItems)
								{
									num |= RayMasks.ITEM;
								}
								if (!InteractionOptions.NoHitResources)
								{
									num |= RayMasks.RESOURCE;
								}
								if (!InteractionOptions.NoHitStructures)
								{
									num |= RayMasks.STRUCTURE;
								}
								if (!InteractionOptions.NoHitVehicles)
								{
									num |= RayMasks.VEHICLE;
								}
								if (!InteractionOptions.NoHitEnvironment)
								{
									num |= (RayMasks.LARGE | RayMasks.MEDIUM | RayMasks.ENVIRONMENT | RayMasks.GROUND);
								}
							}
							else
							{
								num = RayMasks.PLAYER_INTERACT;
							}
							OV_PlayerInteract.lastInteract = Time.realtimeSinceStartup;
							float num2 = (InteractionOptions.InteractThroughWalls && !PlayerCoroutines.IsSpying) ? 20f : 4f;
							PhysicsUtility.raycast(new Ray(OptimizationVariables.MainCam.transform.position, OptimizationVariables.MainCam.transform.forward), out OV_PlayerInteract.hit, (OptimizationVariables.MainPlayer.look.perspective == EPlayerPerspective.THIRD) ? (num2 + 2f) : num2, num, QueryTriggerInteraction.UseGlobal);
						}
						Transform transform = (!(OV_PlayerInteract.hit.collider != null)) ? null : OV_PlayerInteract.hit.collider.transform;
						if (!(transform != OV_PlayerInteract.focus))
						{
							goto IL_3AD;
						}
						if (OV_PlayerInteract.focus != null && PlayerInteract.interactable != null)
						{
							InteractableDoorHinge componentInParent = OV_PlayerInteract.focus.GetComponentInParent<InteractableDoorHinge>();
							if (componentInParent != null)
							{
								HighlighterTool.unhighlight(componentInParent.door.transform);
							}
							else
							{
								HighlighterTool.unhighlight(PlayerInteract.interactable.transform);
							}
						}
						OV_PlayerInteract.focus = null;
						OV_PlayerInteract.target = null;
						OV_PlayerInteract.interactable = null;
						OV_PlayerInteract.interactable2 = null;
						if (!(transform != null))
						{
							goto IL_3AD;
						}
						OV_PlayerInteract.focus = transform;
						OV_PlayerInteract.interactable = OV_PlayerInteract.focus.GetComponentInParent<Interactable>();
						OV_PlayerInteract.interactable2 = OV_PlayerInteract.focus.GetComponentInParent<Interactable2>();
						if (!(PlayerInteract.interactable != null))
						{
							goto IL_3AD;
						}
						OV_PlayerInteract.target = PlayerInteract.interactable.transform.FindChildRecursive(<Module>.smethod_4<string>(1288142903u));
						if (!PlayerInteract.interactable.checkInteractable())
						{
							OV_PlayerInteract.target = null;
							OV_PlayerInteract.interactable = null;
							goto IL_3AD;
						}
						if (!PlayerUI.window.isEnabled)
						{
							goto IL_3AD;
						}
						if (!PlayerInteract.interactable.checkUseable())
						{
							Color color = Color.red;
							InteractableDoorHinge componentInParent2 = OV_PlayerInteract.focus.GetComponentInParent<InteractableDoorHinge>();
							if (componentInParent2 != null)
							{
								HighlighterTool.highlight(componentInParent2.door.transform, color);
								goto IL_3AD;
							}
							HighlighterTool.highlight(PlayerInteract.interactable.transform, color);
							goto IL_3AD;
						}
						else
						{
							Color color;
							if (!PlayerInteract.interactable.checkHighlight(out color))
							{
								color = Color.green;
							}
							InteractableDoorHinge componentInParent3 = OV_PlayerInteract.focus.GetComponentInParent<InteractableDoorHinge>();
							if (componentInParent3 != null)
							{
								HighlighterTool.highlight(componentInParent3.door.transform, color);
								goto IL_3AD;
							}
							HighlighterTool.highlight(PlayerInteract.interactable.transform, color);
							goto IL_3AD;
						}
					}
				}
			}
			if (OV_PlayerInteract.focus != null && PlayerInteract.interactable != null)
			{
				InteractableDoorHinge componentInParent4 = OV_PlayerInteract.focus.GetComponentInParent<InteractableDoorHinge>();
				if (componentInParent4 != null)
				{
					HighlighterTool.unhighlight(componentInParent4.door.transform);
				}
				else
				{
					HighlighterTool.unhighlight(PlayerInteract.interactable.transform);
				}
			}
			OV_PlayerInteract.focus = null;
			OV_PlayerInteract.target = null;
			OV_PlayerInteract.interactable = null;
			OV_PlayerInteract.interactable2 = null;
			IL_3AD:
			if (!OptimizationVariables.MainPlayer.life.isDead)
			{
				EPlayerMessage message;
				string text;
				Color color2;
				if (!(PlayerInteract.interactable != null))
				{
					if (OV_PlayerInteract.purchaseAsset != null && OptimizationVariables.MainPlayer.movement.purchaseNode != null && !PlayerUI.window.showCursor)
					{
						PlayerUI.hint(null, EPlayerMessage.PURCHASE, string.Empty, Color.white, new object[]
						{
							OV_PlayerInteract.purchaseAsset.itemName,
							OptimizationVariables.MainPlayer.movement.purchaseNode.cost
						});
					}
					else if (OV_PlayerInteract.focus != null && OV_PlayerInteract.focus.CompareTag(<Module>.smethod_7<string>(1695035590u)))
					{
						Player player = DamageTool.getPlayer(OV_PlayerInteract.focus);
						if (player != null && player != Player.player && !PlayerUI.window.showCursor)
						{
							PlayerUI.hint(null, EPlayerMessage.ENEMY, string.Empty, Color.white, new object[]
							{
								player.channel.owner
							});
						}
					}
				}
				else if (PlayerInteract.interactable.checkHint(out message, out text, out color2) && !PlayerUI.window.showCursor)
				{
					if (!PlayerInteract.interactable.CompareTag(<Module>.smethod_5<string>(59996598u)))
					{
						PlayerUI.hint((!(OV_PlayerInteract.target != null)) ? OV_PlayerInteract.focus : OV_PlayerInteract.target, message, text, color2, Array.Empty<object>());
					}
					else
					{
						PlayerUI.hint((!(OV_PlayerInteract.target != null)) ? OV_PlayerInteract.focus : OV_PlayerInteract.target, message, text, color2, new object[]
						{
							((InteractableItem)PlayerInteract.interactable).item,
							((InteractableItem)PlayerInteract.interactable).asset
						});
					}
				}
				EPlayerMessage message2;
				float data;
				if (PlayerInteract.interactable2 != null && PlayerInteract.interactable2.checkHint(out message2, out data) && !PlayerUI.window.showCursor)
				{
					PlayerUI.hint2(message2, (!OV_PlayerInteract.isHoldingKey) ? 0f : ((Time.realtimeSinceStartup - OV_PlayerInteract.lastKeyDown) / this.salvageTime), data);
				}
				if ((OptimizationVariables.MainPlayer.stance.stance == EPlayerStance.DRIVING || OptimizationVariables.MainPlayer.stance.stance == EPlayerStance.SITTING) && !Input.GetKey(KeyCode.LeftShift))
				{
					if (Input.GetKeyDown(KeyCode.F1))
					{
						this.hotkey(0);
					}
					if (Input.GetKeyDown(KeyCode.F2))
					{
						this.hotkey(1);
					}
					if (Input.GetKeyDown(KeyCode.F3))
					{
						this.hotkey(2);
					}
					if (Input.GetKeyDown(KeyCode.F4))
					{
						this.hotkey(3);
					}
					if (Input.GetKeyDown(KeyCode.F5))
					{
						this.hotkey(4);
					}
					if (Input.GetKeyDown(KeyCode.F6))
					{
						this.hotkey(5);
					}
					if (Input.GetKeyDown(KeyCode.F7))
					{
						this.hotkey(6);
					}
					if (Input.GetKeyDown(KeyCode.F8))
					{
						this.hotkey(7);
					}
					if (Input.GetKeyDown(KeyCode.F9))
					{
						this.hotkey(8);
					}
					if (Input.GetKeyDown(KeyCode.F10))
					{
						this.hotkey(9);
					}
				}
				if (Input.GetKeyDown(ControlsSettings.interact))
				{
					OV_PlayerInteract.lastKeyDown = Time.realtimeSinceStartup;
					OV_PlayerInteract.isHoldingKey = true;
				}
				if (Input.GetKeyDown(ControlsSettings.inspect))
				{
					if (ControlsSettings.inspect != ControlsSettings.interact)
					{
						if (OptimizationVariables.MainPlayer.equipment.canInspect)
						{
							OptimizationVariables.MainPlayer.channel.send(<Module>.smethod_6<string>(1705042596u), ESteamCall.SERVER, ESteamPacket.UPDATE_UNRELIABLE_BUFFER, Array.Empty<object>());
						}
					}
				}
				if (OV_PlayerInteract.isHoldingKey)
				{
					if (!Input.GetKeyUp(ControlsSettings.interact))
					{
						if (Time.realtimeSinceStartup - OV_PlayerInteract.lastKeyDown > this.salvageTime)
						{
							OV_PlayerInteract.isHoldingKey = false;
							if (!PlayerUI.window.showCursor && PlayerInteract.interactable2 != null)
							{
								PlayerInteract.interactable2.use();
							}
						}
					}
					else
					{
						OV_PlayerInteract.isHoldingKey = false;
						if (!PlayerUI.window.showCursor)
						{
							if (OptimizationVariables.MainPlayer.stance.stance != EPlayerStance.DRIVING)
							{
								if (OptimizationVariables.MainPlayer.stance.stance != EPlayerStance.SITTING)
								{
									if (OV_PlayerInteract.focus != null && PlayerInteract.interactable != null)
									{
										if (PlayerInteract.interactable.checkUseable())
										{
											PlayerInteract.interactable.use();
											return;
										}
										return;
									}
									else if (OV_PlayerInteract.purchaseAsset == null)
									{
										if (ControlsSettings.inspect != ControlsSettings.interact)
										{
											return;
										}
										if (OptimizationVariables.MainPlayer.equipment.canInspect)
										{
											OptimizationVariables.MainPlayer.channel.send(<Module>.smethod_4<string>(98505503u), ESteamCall.SERVER, ESteamPacket.UPDATE_UNRELIABLE_BUFFER, Array.Empty<object>());
											return;
										}
										return;
									}
									else
									{
										if (OptimizationVariables.MainPlayer.skills.experience >= OptimizationVariables.MainPlayer.movement.purchaseNode.cost)
										{
											OptimizationVariables.MainPlayer.skills.sendPurchase(OptimizationVariables.MainPlayer.movement.purchaseNode);
											return;
										}
										return;
									}
								}
							}
							VehicleManager.exitVehicle();
							return;
						}
						if (OptimizationVariables.MainPlayer.inventory.isStoring && OptimizationVariables.MainPlayer.inventory.shouldInteractCloseStorage)
						{
							PlayerDashboardUI.close();
							PlayerLifeUI.open();
							return;
						}
						if (PlayerBarricadeSignUI.active)
						{
							PlayerBarricadeSignUI.close();
							PlayerLifeUI.open();
							return;
						}
						if (PlayerBarricadeStereoUI.active)
						{
							PlayerBarricadeStereoUI.close();
							PlayerLifeUI.open();
							return;
						}
						if (PlayerBarricadeLibraryUI.active)
						{
							PlayerBarricadeLibraryUI.close();
							PlayerLifeUI.open();
							return;
						}
						if (PlayerBarricadeMannequinUI.active)
						{
							PlayerBarricadeMannequinUI.close();
							PlayerLifeUI.open();
							return;
						}
						if (PlayerNPCDialogueUI.active)
						{
							if (PlayerNPCDialogueUI.dialogueAnimating)
							{
								PlayerNPCDialogueUI.skipText();
								return;
							}
							if (PlayerNPCDialogueUI.dialogueHasNextPage)
							{
								PlayerNPCDialogueUI.nextPage();
								return;
							}
							PlayerNPCDialogueUI.close();
							PlayerLifeUI.open();
							return;
						}
						else
						{
							if (PlayerNPCQuestUI.active)
							{
								PlayerNPCQuestUI.closeNicely();
								return;
							}
							if (PlayerNPCVendorUI.active)
							{
								PlayerNPCVendorUI.closeNicely();
								return;
							}
						}
					}
				}
				return;
			}
		}

		// Token: 0x040001C1 RID: 449
		private static FieldInfo FocusField = typeof(PlayerInteract).GetField(<Module>.smethod_6<string>(1375592008u), ReflectionVariables.PrivateStatic);

		// Token: 0x040001C2 RID: 450
		private static FieldInfo TargetField = typeof(PlayerInteract).GetField(<Module>.smethod_5<string>(2807955658u), ReflectionVariables.PrivateStatic);

		// Token: 0x040001C3 RID: 451
		private static FieldInfo InteractableField = typeof(PlayerInteract).GetField(<Module>.smethod_7<string>(3128667123u), ReflectionVariables.PrivateStatic);

		// Token: 0x040001C4 RID: 452
		private static FieldInfo Interactable2Field = typeof(PlayerInteract).GetField(<Module>.smethod_6<string>(2524484185u), ReflectionVariables.PrivateStatic);

		// Token: 0x040001C5 RID: 453
		private static FieldInfo PurchaseAssetField = typeof(PlayerInteract).GetField(<Module>.smethod_5<string>(3643913391u), ReflectionVariables.PrivateStatic);

		// Token: 0x040001C6 RID: 454
		private static bool isHoldingKey;

		// Token: 0x040001C7 RID: 455
		private static float lastInteract;

		// Token: 0x040001C8 RID: 456
		private static float lastKeyDown;

		// Token: 0x040001C9 RID: 457
		private static RaycastHit hit;
	}
}
