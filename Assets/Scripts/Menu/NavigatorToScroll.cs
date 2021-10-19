using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigatorToScroll : MonoBehaviour
{
	[SerializeField] private Transform _content;

	[SerializeField] private GameObject _leftArrow;
	[SerializeField] private GameObject _rightArrow;
	[SerializeField] private GameObject _toggleLevel;

	

	private List<GameObject> _toggles = new List<GameObject>();

	public void Build()
	{
		var count = ScrollingLevelsToMenu.CountGroups + 2;
		_toggles.ForEach(item => DestroyImmediate(item));
		_toggles = new List<GameObject>();
		

		for (int i = 0; i < count; i++)
		{
			if (i == 0) _toggles.Add(Instantiate(_leftArrow, _content));
			else if(i == count - 1) _toggles.Add(Instantiate(_rightArrow, _content));
			else _toggles.Add(Instantiate(_toggleLevel, _content));
		}
	}

}
