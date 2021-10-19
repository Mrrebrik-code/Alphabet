using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScrollingLevelsToMenu))]
[CanEditMultipleObjects]
public class ScrollingLevelsToMenuEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		ScrollingLevelsToMenu _srollingLevelsToMenu = (ScrollingLevelsToMenu)target;
		if (GUILayout.Button("SetPosition"))
		{
			_srollingLevelsToMenu.SetPosition();
		}
	}
}
