using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGroup : MonoBehaviour
{
	public RectTransform RectTransform{ get; set; }
	public void Init()
	{
		RectTransform = GetComponent<RectTransform>();
	}


}
