using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteAnimationImage : MonoBehaviour
{
    public Image image;
    public Sprite[] sprites;
    public float rate = 0.1f;
    public bool allowAnimation = true;

    int currentSpriteIndex = 0;

    void Start()
    {
        currentSpriteIndex = -1;
        StartCoroutine(Animating());
    }

    IEnumerator Animating()
    {
        while (true)
        {
            if (!allowAnimation)
            {
                if(currentSpriteIndex != 0)
                {
                    currentSpriteIndex = 0;
                    image.sprite = sprites[currentSpriteIndex];
                }
            }
            else
            {
                if(currentSpriteIndex < 0)
                {
                    currentSpriteIndex = 0;
                }
                else
                {
                    currentSpriteIndex++;
                    if(currentSpriteIndex >= sprites.Length)
                    {
                        currentSpriteIndex = 0;
                    }
                }

                image.sprite = sprites[currentSpriteIndex];
            }

            yield return new WaitForSeconds(rate);
        }
    }

    private void Reset()
    {
        image = GetComponent<Image>();
    }
}
