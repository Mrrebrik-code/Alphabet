using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsGroups : MonoBehaviour
{
    public RectTransform[] panels;
    public GameObject[] panelsIcons;
    public Button leftArrow, rightArrow;
    public float panelsDistance, panelsSpeed = 2f;

    Vector3 startDragPosition;
    float currentSwipeTime;
    bool isDragging = false;
    bool isMoving = false;
    int currentPanelIndex;

    const float swipeTime = 1f;
    const float swipeDistance = 100f;

    private void Start()
    {
        SetPositionGroup();
        currentPanelIndex = 0;
        SetIcons();
    }

    private void Update()
    {
        if (isDragging)
        {
            if (StopTouch())
            {
                isDragging = false;
                float distance = GetTouchPosition().x - startDragPosition.x;
                if (Mathf.Abs(distance) >= swipeDistance && currentSwipeTime <= swipeTime)
                {
                    if (distance > 0f)
                    {
                        MovePanels(false);
                    }
                    else if (distance < 0f)
                    {
                        MovePanels(true);
                    }
                }
            }
            else
            {
                Vector3 touchPos = GetTouchPosition();
                if (touchPos == startDragPosition)
                {
                    currentSwipeTime = 0f;
                    startDragPosition = touchPos;
                }
                else
                {
                    currentSwipeTime += Time.deltaTime;
                }
            }
        }
        else
        {
            if (StartTouch())
            {
                startDragPosition = GetTouchPosition();
                currentSwipeTime = 0f;
                isDragging = true;
            }
        }
    }

    private void SetPositionGroup()
	{
		for (int i = 0; i < panels.Length; i++)
		{
            if (i == 0) continue;

            panels[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(panels[i - 1].GetComponent<RectTransform>().anchoredPosition.x + 2000, panels[i].GetComponent<RectTransform>().anchoredPosition.y);
		}
	}

    public void Left()
    {
        MovePanels(false);
    }

    public void Right()
    {
        MovePanels(true);
    }

    void MovePanels(bool toRight)
    {
        if (isMoving)
        {
            return;
        }

        int nextPanelIndex;

        if (toRight)
        {
            nextPanelIndex = currentPanelIndex + 1;
            if(nextPanelIndex >= panels.Length)
            {
                return;
            }
        }
        else
        {
            nextPanelIndex = currentPanelIndex - 1;
            if (nextPanelIndex < 0)
            {
                return;
            }
        }

        StartCoroutine(MovingPanels(nextPanelIndex));
    }

    IEnumerator MovingPanels(int nextPanelIndex)
    {
        isMoving = true;

        RectTransform panel1 = panels[currentPanelIndex];
        RectTransform panel2 = panels[nextPanelIndex];

        Vector3 panel1StartPos, panel1EndPos, panel2EndPos, panel2StartPos;
        panel1StartPos = panel1.anchoredPosition;
        panel2StartPos = panel2.anchoredPosition;
        panel1EndPos = panel1.anchoredPosition;
        panel2EndPos = panel2.anchoredPosition;

        if (nextPanelIndex > currentPanelIndex)
        {
            panel1EndPos.x -= panelsDistance;

            panel2EndPos.x -= panelsDistance;
        }
        else
        {
            panel1EndPos.x += panelsDistance;

            panel2EndPos.x += panelsDistance;
        }

        for (float t = 0f; t <= 1f; t += Time.deltaTime * panelsSpeed)
        {
            panel1.anchoredPosition = Vector3.Lerp(panel1StartPos, panel1EndPos, t);
            panel2.anchoredPosition = Vector3.Lerp(panel2StartPos, panel2EndPos, t);
            yield return null;
        }

        panel1.anchoredPosition = panel1EndPos;
        panel2.anchoredPosition = panel2EndPos;

        isMoving = false;
        currentPanelIndex = nextPanelIndex;

        SetIcons();
    }

    void SetIcons()
    {
        for (int i = 0; i < panelsIcons.Length; i++)
        {
            if(i == currentPanelIndex)
            {
                panelsIcons[i].transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else
            {
                panelsIcons[i].transform.localScale = new Vector3(0.6f, 0.6f, 1f);
            }
        }

        leftArrow.interactable = currentPanelIndex > 0;
        rightArrow.interactable = currentPanelIndex < (panels.Length - 1);
    }

    bool StartTouch()
    {
        if (Input.touchSupported)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    return true;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                return true;
            }
        }

        return false;
    }

    bool StopTouch()
    {
        if (Input.touchSupported)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Ended)
                {
                    return true;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                return true;
            }
        }

        return false;
    }

    Vector3 GetTouchPosition()
    {
        if (Input.touchSupported)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                return touch.position;
            }
        }
        else
        {
            return Input.mousePosition;
        }

        return Vector3.zero;
    }
}
