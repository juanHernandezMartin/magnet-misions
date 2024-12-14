using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


namespace ManetsAnims
{
    public class RepulsionAnim : MonoBehaviour
    {
        public GameObject magnetTop;
        public GameObject magnetBot;
        public bool animAtStart;
        public float animDistance;
        public float animTime;


        public void Start()
        {
            if (animAtStart)
            {
                AnimateMagnets();
            }
        }

        public void AnimateMagnets()
        {

            float targetYTot = magnetTop.transform.position.y + animDistance;
            Tween topTween = magnetTop.transform.DOMoveY( targetYTot, animTime );
            topTween.SetEase(Ease.InOutQuad);

            float targetYBot = magnetBot.transform.position.y - animDistance;
            Tween botTween = magnetBot.transform.DOMoveY( targetYBot, animTime );
            botTween.SetEase(Ease.InOutQuad);
        }
    }
}
