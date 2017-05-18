using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Tools.Handy
{

public class HandyEditor : EditorWindow 

	{
		public GameObject obj = null;
		Vector3 mousePos;
		bool itemPlacer;
		[MenuItem("Tools/HandyTool")]
		static void Init()
		{
			HandyEditor H_Editor = (HandyEditor)GetWindow(typeof(HandyEditor));
			H_Editor.Show();
		}

		void OnGUI()
		{
			

			GameObject[] hierarchyObj = Selection.gameObjects;

			if(GUILayout.Button("Reset Vector3"))
					{
						for (int i = 0; i < hierarchyObj.Length; i++)
						{
							hierarchyObj[i].transform.position = new Vector3(0,0,0);
						}
					}
			obj = (GameObject)EditorGUI.ObjectField (this.position, "Place", obj, typeof(GameObject));

			if(GUILayout.Button("Reset Rotation"))
			{
				for (int i = 0; i < hierarchyObj.Length; i++)
				{
					hierarchyObj[i].transform.rotation = new Quaternion(0,0,0,0);
				}
			}
			itemPlacer = EditorGUILayout.Toggle (itemPlacer);
			//if (itemPlacer) 
			//{
				
				if (obj) 
				{
					if (Input.GetMouseButtonDown (0) && mousePos != null) 
					{
						GameObject clone = Instantiate (obj, mousePos, Quaternion.identity);
					}
				//}
			}
		}

		void OnSceneGui()
		{
			mousePos = Event.current.mousePosition;
			mousePos.y = SceneView.currentDrawingSceneView.camera.pixelHeight - mousePos.y;
			mousePos = SceneView.currentDrawingSceneView.camera.ScreenToWorldPoint (mousePos);
			mousePos.y = -mousePos.y;
		}

	}
}
