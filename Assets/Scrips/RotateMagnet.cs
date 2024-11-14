using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RotateMagnet : MonoBehaviour
{
    public GameObject mainMagnet;
    public float timeToRotate;

    private bool isRotated = true;
    private Horientation mainMagnetHorientation;

    public void Awake()
    {
        mainMagnetHorientation = mainMagnet.GetComponent<Horientation>();
    }


    private void OnMouseUp()
    {
        Vector3 rotationMagnet = Vector3.back * 180 * Convert.ToInt32(isRotated);
        mainMagnet.transform.DORotate(rotationMagnet, timeToRotate);
        isRotated = !isRotated;
        mainMagnetHorientation.isNorth = !mainMagnetHorientation.isNorth;
    }
}
