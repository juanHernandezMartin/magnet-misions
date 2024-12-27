using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;



public class RepulsionAnim : MagnetAnim
{
    public Transform magnetTop;
    public Transform magnetBot;
    public bool animAtStart;
    public float animDistance;
    public float animTime;
    public float animPause;

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

        float targetYTot = magnetTop.position.y + animDistance;
        Tween topTween = magnetTop.DOMoveY(targetYTot, animTime);
        topTween.SetEase(Ease.InOutQuad);

        float targetYBot = magnetBot.position.y - animDistance;
        Tween botTween = magnetBot.DOMoveY(targetYBot, animTime);
        botTween.SetEase(Ease.InOutQuad);

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

