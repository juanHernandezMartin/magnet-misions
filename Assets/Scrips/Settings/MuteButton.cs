using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteButton : MonoBehaviour
{
    public GameObject mutedImage;
    public GameObject unMutedImage;

    private bool isMuted = false;

    public static MuteButton Instance { get; private set; }

    public void Update()
    {
        if (isMuted)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }

    public void OnMouseUp()
    {
        isMuted = !isMuted;
        mutedImage.SetActive(!mutedImage.activeSelf);
        unMutedImage.SetActive(!unMutedImage.activeSelf);
    }
}
