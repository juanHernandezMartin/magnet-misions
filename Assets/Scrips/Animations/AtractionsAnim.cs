using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;


public class AtractionsAnim : MagnetAnim
{
    public Transform magnetTop;
    public Transform magnetBot;
    public bool animAtStart;
    public float animTime;
    public float animPause;

    private float scaleMult = 4.8f;
    private Vector3 oroginalPosTopMagnet;
    private Vector3 oroginalPosBotMagnet;

    public void Start()
    {
        oroginalPosTopMagnet = magnetTop.position;
        oroginalPosBotMagnet = magnetBot.position;
        if (animAtStart)
        {
            AnimateMagnets();
        }
    }

    public new void AnimateMagnets()
    {
        float targetY = (magnetTop.position.y + magnetBot.position.y) / 2f;

        float targetYTop = targetY + scaleMult * magnetBot.localScale.x;
        Tween topTween = magnetTop.DOMoveY(targetYTop, animTime);
        topTween.SetEase(Ease.InExpo);

        float targetYBot = targetY - scaleMult * magnetBot.localScale.x;
        Tween botTween = magnetBot.DOMoveY(targetYBot, animTime);
        botTween.SetEase(Ease.InExpo);

        botTween.OnComplete(() =>
        {
            Tween nothingTween = magnetTop.DOMoveY(magnetTop.position.y, animPause);
            nothingTween.OnComplete(() =>
            {
                magnetTop.position = oroginalPosTopMagnet;
                magnetBot.position = oroginalPosBotMagnet;
                AnimateMagnets();
            });
        });
    }
}


