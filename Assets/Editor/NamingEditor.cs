using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Tools.Naming
{

public enum HeaderType
{
	Group,
	Item,
	Etc,
}


public class NamingEditor : EditorWindow
{
	HeaderType header;
	string NamingHeader;
	string n_Name;


	[MenuItem("Tools/NamingTool")]

	static void Init()
	{
		NamingEditor t_Editor = (NamingEditor)GetWindow(typeof(NamingEditor));
		t_Editor.Show();
	}

	void OnGUI()
	{
		SwitchEnum();
		header = (HeaderType)EditorGUILayout.EnumPopup("HeaderType:", header);
		n_Name = EditorGUILayout.TextField("Name", n_Name);

		EditorGUILayout.Space ();

		if (GUILayout.Button("Rename"))
		{
			GameObject newParent = new GameObject(NamingHeader + n_Name);

			GameObject[] hierarchyObj = Selection.gameObjects;

			for (int i = 0; i < hierarchyObj.Length; i++)
			{
				hierarchyObj[i].transform.SetParent(newParent.transform);
			}

		}
	}

	void SwitchEnum()
	{
		switch (header)

		{
		case HeaderType.Group:
			NamingHeader = "(Group) ";
			break;
		case HeaderType.Item:
			NamingHeader = "(Item) ";
			break;
		case HeaderType.Etc:
			NamingHeader = "(Etc) ";
			break;
		
		}
	}

	}

}