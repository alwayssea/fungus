﻿using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;

namespace Fungus
{

	public class FungusScriptMenuItems
	{
		[MenuItem("Tools/Fungus/Create/Fungus Script")]
		static void CreateFungusScript()
		{
			SpawnPrefab("FungusScript");
		}

		public static GameObject SpawnPrefab(string prefabName)
		{
			GameObject prefab = Resources.Load<GameObject>(prefabName);
			if (prefab == null)
			{
				return null;
			}

			GameObject go = PrefabUtility.InstantiatePrefab(prefab) as GameObject;

			Camera sceneCam = SceneView.currentDrawingSceneView.camera;

			Vector3 pos = sceneCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10f));
			pos.z = 0f;
			go.transform.position = pos;

			Selection.activeGameObject = go;
			
			Undo.RegisterCreatedObjectUndo(go, "Create Object");

			return go;
		}
	}

}