using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NavigatorToScroll))]
public class NavigatorToScrollEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		NavigatorToScroll _navigator = (NavigatorToScroll)target;

		if (GUILayout.Button("Build"))
		{
			_navigator.Build();
		}

	}
}
