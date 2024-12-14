using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

namespace ManetsAnims
{
    public class AtractionsAnim : MonoBehaviour
    {
        public GameObject magnetTop;
        public GameObject magnetBot;
        public bool animAtStart;
        public float animTime;

        private float scaleMult = 4.8f;

        public void Start()
        {
            if (animAtStart)
            {
                AnimateMagnets();
            }
        }

        public void AnimateMagnets()
        {
            float targetY = (magnetTop.transform.position.y + magnetBot.transform.position.y) /2f;

            float targetYBot = targetY - scaleMult*magnetBot.transform.localScale.x;
            Tween botTween = magnetBot.transform.DOMoveY( targetYBot, animTime );
            botTween.SetEase(Ease.InExpo);

            float targetYTop = targetY + scaleMult*magnetBot.transform.localScale.x;
            Tween topTween = magnetTop.transform.DOMoveY( targetYTop, animTime );
            topTween.SetEase(Ease.InExpo);
        }
    }
}

