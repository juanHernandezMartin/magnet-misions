using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DinamoAnimation : MagnetAnim
{
    public GameObject electroMagnetLeft;
    public Transform magnetRight;
    public Transform dinamo;
    public bool animAtStart;
    public AnimTimes animTimes;
    public GameObject ActivatedMode;
    public float dinamoSpeed;

    private Vector3 electroMagnetOriginalPosition;
    private Vector3 rightMagnetOriginalPosition;

    private float scaleMult = 4.8f;

    public void OnEnable()
    {
        if (animAtStart)
        {
            AnimateMagnets();
        }

        electroMagnetOriginalPosition = electroMagnetLeft.transform.position;
        rightMagnetOriginalPosition = magnetRight.position;
    }

    public new void AnimateMagnets()
    {
        ActivatedMode.SetActive(false);
        Tween nothingTween = dinamo.DOMove(dinamo.position, animTimes.bateryTime);
        nothingTween.OnComplete(() =>
        {
            AtractElectroMagnet();
        });
    }

    public void AtractElectroMagnet()
    {
        Vector3 dinamoRotation = dinamo.eulerAngles;
        dinamoRotation.z += dinamoSpeed * 360;
        dinamo.DORotate(dinamoRotation, animTimes.electroMagnetTime + 1, RotateMode.FastBeyond360);


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
        Vector3 dinamoRotation = dinamo.eulerAngles;
        dinamoRotation.z -= dinamoSpeed * 360;
        dinamo.DORotate(dinamoRotation, animTimes.electroMagnetTime + 1, RotateMode.FastBeyond360);


        Vector3 eulersOfMagnetInside = ActivatedMode.transform.eulerAngles;
        eulersOfMagnetInside.z += 180;
        ActivatedMode.transform.eulerAngles = eulersOfMagnetInside;
        ActivatedMode.SetActive(true);

        Tween leftTween = electroMagnetLeft.transform.DOMoveX(electroMagnetOriginalPosition.x, animTimes.electroMagnetTime);
        Tween rightTween = magnetRight.transform.DOMoveX(rightMagnetOriginalPosition.x, animTimes.electroMagnetTime);

        rightTween.OnComplete(() =>
        {
            ActivatedMode.SetActive(false);
            AnimateBaterryBack(true);
        });
    }

    public void AnimateBaterryBack(bool isNextAtract)
    {
        ActivatedMode.SetActive(false);
        Tween nothingTween = dinamo.DOMove(dinamo.position, animTimes.bateryTime);
        nothingTween.OnComplete(() =>
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
    }
}
