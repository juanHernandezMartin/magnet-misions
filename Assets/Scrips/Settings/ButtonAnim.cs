using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ButtonAnim : MonoBehaviour
{
    public float sizeIncrease;
    public float timeToScale;
    private Vector3 originalSize;

    public void Awake()
    {
        originalSize = transform.localScale;
    }

    public void OnMouseEnter()
    {
        transform.DOScale(originalSize * sizeIncrease, timeToScale);
    }

    public void OnMouseExit()
    {
        transform.DOScale(originalSize, timeToScale);
    }
}
