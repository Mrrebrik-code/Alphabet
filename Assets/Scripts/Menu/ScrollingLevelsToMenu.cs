using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingLevelsToMenu : MonoBehaviour
{
	public static int CountGroups;

	[SerializeField] private LevelGroup[] LevelGroups;
	[SerializeField] private float _spacing = 2000f;

	public void SetPosition()
	{
		CountGroups = LevelGroups.Length;
		for (int i = 0; i < LevelGroups.Length; i++)
		{
			LevelGroups[i].Init();
			if (i == 0) continue;

			var position = LevelGroups[i - 1].RectTransform.anchoredPosition;
			LevelGroups[i].RectTransform.anchoredPosition = new Vector2(position.x + _spacing, position.y);
		}
	}


}
