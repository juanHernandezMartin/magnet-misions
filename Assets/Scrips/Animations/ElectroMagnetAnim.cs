using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[Serializable]
public struct AnimTimes
{
    public float bateryTime;
    public float electroMagnetTime;
}



public class ElectroMagnetAnim : MagnetAnim
{
    public GameObject electroMagnetLeft;
    public Transform magnetRight;
    public Transform battery;
    public Transform batteryPlug;
    public bool animAtStart;
    public AnimTimes animTimes;
    public GameObject ActivatedMode;

    private Vector3 originalBatteryPosition;
    private Vector3 originalPlugPosition;
    private Vector3 electroMagnetOriginalPosition;
    private Vector3 rightMagnetOriginalPosition;

    private float scaleMult = 4.8f;

    public void Start()
    {
        if (animAtStart)
        {
            AnimateMagnets();
        }

        originalPlugPosition = batteryPlug.position;
        originalBatteryPosition = battery.position;
        electroMagnetOriginalPosition = electroMagnetLeft.transform.position;
        rightMagnetOriginalPosition = magnetRight.position;
    }

    public new void AnimateMagnets()
    {
        ActivatedMode.SetActive(false);
        //Tween batteryTween = battery.DOMove(batteryPlug.position, animTimes.bateryTime);
        Tween batteryTween = batteryPlug.DOMove(battery.position, animTimes.bateryTime);
        batteryTween.OnComplete(() =>
        {
            AtractElectroMagnet();
        });
    }

    public void AtractElectroMagnet()
    {
        Vector3 eulersOfMagnetInside = ActivatedMode.transform.eulerAngles;
        eulersOfMagnetInside.z += 180;
        ActivatedMode.transform.eulerAngles = eulersOfMagnetInside;

        ActivatedMode.SetActive(true);
        float targetX = (electroMagnetLeft.transform.position.x + magnetRight.transform.position.x) / 2f;

        float targetXLeft = targetX - scaleMult * electroMagnetLeft.transform.localScale.x;
        Tween leftTween = electroMagnetLeft.transform.DOMoveX(targetXLeft, animTimes.electroMagnetTime);
        leftTween.SetEase(Ease.InExpo);

        float targetXRight = targetX + scaleMult * electroMagnetLeft.transform.localScale.x;
        Tween rightTween = magnetRight.transform.DOMoveX(targetXRight, animTimes.electroMagnetTime);
        rightTween.SetEase(Ease.InExpo);

        rightTween.OnComplete(() =>
        {
            ActivatedMode.SetActive(false);
            AnimateBaterryBack(false);
        });
    }

    public void RepelElectroMagnet()
    {
        Vector3 eulersOfMagnetInside = ActivatedMode.transform.eulerAngles;
        eulersOfMagnetInside.z += 180;
        ActivatedMode.transform.eulerAngles = eulersOfMagnetInside;
        ActivatedMode.SetActive(true);
        Tween leftTween = electroMagnetLeft.transform.DOMoveX(electroMagnetOriginalPosition.x, animTimes.electroMagnetTime);
        //leftTween.SetEase(Ease.InExpo);

        Tween rightTween = magnetRight.transform.DOMoveX(rightMagnetOriginalPosition.x, animTimes.electroMagnetTime);
        //rightTween.SetEase(Ease.InExpo);

        rightTween.OnComplete(() =>
        {
            ActivatedMode.SetActive(false);
            AnimateBaterryBack(true);
        });
    }

    public void AnimateBaterryBack(bool isNextAtract)
    {
        Tween moveBackBaterry = batteryPlug.DOMove(originalPlugPosition, animTimes.bateryTime);
        moveBackBaterry.OnComplete(() =>
        {
            Vector3 baterryRotation = battery.eulerAngles;
            baterryRotation.z += 180;
            Tween rotateBaterry = battery.DORotate(baterryRotation, animTimes.bateryTime);
            rotateBaterry.OnComplete(() =>
            {
                Tween maoveInBaterry = batteryPlug.DOMove(battery.position, animTimes.bateryTime);
                maoveInBaterry.OnComplete(() =>
                {
                    if (isNextAtract)
                    {
                        AtractElectroMagnet();
                    }
                    else
                    {
                        RepelElectroMagnet();
                    }
                });
            });
        });
    }

}

