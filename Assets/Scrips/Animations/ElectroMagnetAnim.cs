using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct AnimTimes
{
    public float batery;
    public float electroMagnet;
}



public class ElectroMagnetAnim : MagnetAnim
{
    public GameObject electroMagnetLeft;
    public GameObject magnetRight;
    public GameObject battery;
    public GameObject batteryAnchor;
    public bool animAtStart;
    public AnimTimes animTimes;

    private float scaleMult = 4.8f;

    public void Start()
    {
        if (animAtStart)
        {
            AnimateMagnets();
        }
    }

    public new void AnimateMagnets()
    {
        /*
        float targetY = (magnetTop.transform.position.y + magnetBot.transform.position.y) /2f;

        float targetYTop = targetY + scaleMult*magnetBot.transform.localScale.x;
        Tween topTween = magnetTop.transform.DOMoveY( targetYTop, animTime );
        topTween.SetEase(Ease.InExpo);

        float targetYBot = targetY - scaleMult*magnetBot.transform.localScale.x;
        Tween botTween = magnetBot.transform.DOMoveY( targetYBot, animTime );
        botTween.SetEase(Ease.InExpo);
        */
    }
}

