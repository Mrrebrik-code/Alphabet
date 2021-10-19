using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MousePositionNoMesh : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public bool IsEnterMouse = false;
	public void OnPointerEnter(PointerEventData eventData)
	{
		IsEnterMouse = false;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		IsEnterMouse = true;
	}
}
