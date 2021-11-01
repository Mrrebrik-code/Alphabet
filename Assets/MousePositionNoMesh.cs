using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MousePositionNoMesh : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public bool IsEnterMouse = false;

	public void OnMouseEnter()
	{
		IsEnterMouse = false;

	}

	public void OnMouseExit()
	{
		IsEnterMouse = true;
	}
	public void OnPointerEnter(PointerEventData eventData)
	{
		
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		
	}
}
