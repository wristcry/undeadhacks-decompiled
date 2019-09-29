using System;
using UnityEngine;

namespace UndeadHacks
{
	// Token: 0x0200005C RID: 92
	[Component]
	public class MirrorCameraComponent : MonoBehaviour
	{
		// Token: 0x06000163 RID: 355 RVA: 0x00004112 File Offset: 0x00002312
		[OnSpy]
		public static void Disable()
		{
			MirrorCameraComponent.WasEnabled = MirrorCameraOptions.Enabled;
			MirrorCameraOptions.Enabled = false;
			UnityEngine.Object.Destroy(MirrorCameraComponent.cam_obj);
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0000412E File Offset: 0x0000232E
		[OffSpy]
		public static void Enable()
		{
			MirrorCameraOptions.Enabled = MirrorCameraComponent.WasEnabled;
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000413A File Offset: 0x0000233A
		public void Update()
		{
			if (!MirrorCameraComponent.cam_obj || !MirrorCameraComponent.subCam)
			{
				return;
			}
			if (!MirrorCameraOptions.Enabled)
			{
				MirrorCameraComponent.subCam.enabled = false;
				return;
			}
			MirrorCameraComponent.subCam.enabled = true;
		}

		// Token: 0x06000166 RID: 358 RVA: 0x000037BE File Offset: 0x000019BE
		private void Start()
		{
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0000F49C File Offset: 0x0000D69C
		private void OnGUI()
		{
			if (MirrorCameraOptions.Enabled)
			{
				GUI.color = new Color(1f, 1f, 1f, 0f);
				MirrorCameraComponent.viewport = GUILayout.Window(99, MirrorCameraComponent.viewport, new GUI.WindowFunction(this.DoMenu), "Mirror Camera", Array.Empty<GUILayoutOption>());
				GUI.color = Color.white;
			}
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0000F500 File Offset: 0x0000D700
		private void DoMenu(int windowID)
		{
			if (MirrorCameraComponent.cam_obj == null || MirrorCameraComponent.subCam == null)
			{
				MirrorCameraComponent.cam_obj = new GameObject();
				if (MirrorCameraComponent.subCam != null)
				{
					UnityEngine.Object.Destroy(MirrorCameraComponent.subCam);
				}
				MirrorCameraComponent.subCam = MirrorCameraComponent.cam_obj.AddComponent<Camera>();
				MirrorCameraComponent.subCam.CopyFrom(OptimizationVariables.MainCam);
				MirrorCameraComponent.cam_obj.transform.position = OptimizationVariables.MainCam.gameObject.transform.position;
				MirrorCameraComponent.cam_obj.transform.rotation = OptimizationVariables.MainCam.gameObject.transform.rotation;
				MirrorCameraComponent.cam_obj.transform.Rotate(0f, 180f, 0f);
				MirrorCameraComponent.subCam.transform.SetParent(OptimizationVariables.MainCam.transform, true);
				MirrorCameraComponent.subCam.enabled = true;
				MirrorCameraComponent.subCam.rect = new Rect(0.6f, 0.6f, 0.4f, 0.4f);
				MirrorCameraComponent.subCam.depth = 99f;
				UnityEngine.Object.DontDestroyOnLoad(MirrorCameraComponent.cam_obj);
			}
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			GUILayout.FlexibleSpace();
			GUILayout.Label("Mirror Camera", Array.Empty<GUILayoutOption>());
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			float x = (MirrorCameraComponent.viewport.x + 5f) / (float)Screen.width;
			float num = (MirrorCameraComponent.viewport.y + 5f) / (float)Screen.height;
			float width = (MirrorCameraComponent.viewport.width - 10f) / (float)Screen.width;
			float num2 = (MirrorCameraComponent.viewport.height - 10f) / (float)Screen.height;
			num = 1f - num;
			num -= num2;
			MirrorCameraComponent.subCam.rect = new Rect(x, num, width, num2);
			Drawing.DrawRect(new Rect(0f, 0f, MirrorCameraComponent.viewport.width, 5f), Color.black);
			Drawing.DrawRect(new Rect(0f, 0f, 5f, MirrorCameraComponent.viewport.height), Color.black);
			Drawing.DrawRect(new Rect(0f, 0f + (MirrorCameraComponent.viewport.height - 5f), MirrorCameraComponent.viewport.width, 5f), Color.black);
			Drawing.DrawRect(new Rect(0f + (MirrorCameraComponent.viewport.width - 5f), 0f, 5f, MirrorCameraComponent.viewport.height), Color.black);
			GUI.DragWindow();
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000F79C File Offset: 0x0000D99C
		public static void FixCam()
		{
			if (MirrorCameraComponent.cam_obj != null && MirrorCameraComponent.subCam != null)
			{
				MirrorCameraComponent.cam_obj.transform.position = OptimizationVariables.MainCam.gameObject.transform.position;
				MirrorCameraComponent.cam_obj.transform.rotation = OptimizationVariables.MainCam.gameObject.transform.rotation;
				MirrorCameraComponent.cam_obj.transform.Rotate(0f, 180f, 0f);
				MirrorCameraComponent.subCam.transform.SetParent(OptimizationVariables.MainCam.transform, true);
				MirrorCameraComponent.subCam.depth = 99f;
				MirrorCameraComponent.subCam.enabled = true;
			}
		}

		// Token: 0x04000147 RID: 327
		public static Rect viewport = new Rect(1075f, 10f, (float)(Screen.width / 4), (float)(Screen.height / 4));

		// Token: 0x04000148 RID: 328
		public static GameObject cam_obj;

		// Token: 0x04000149 RID: 329
		public static Camera subCam;

		// Token: 0x0400014A RID: 330
		public static bool WasEnabled;
	}
}
