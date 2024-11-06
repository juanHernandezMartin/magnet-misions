using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RotateMagnet : MonoBehaviour
{
    public Magnet mainMagnet;
    public float timeToRotate;

    private void OnMouseUp()
    {
        Vector3 rotationMagnet = Vector3.back * 180 * Convert.ToInt32(mainMagnet.isNorth);
        mainMagnet.gameObject.transform.DORotate(rotationMagnet, timeToRotate);
        mainMagnet.isNorth = !mainMagnet.isNorth;
    }
}
