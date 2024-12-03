using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public BaterryCableEnd leftPlug;
    public BaterryCableEnd rightPlug;
    public Horientation electroMagnet;
    public GameObject northFacingImage;
    public GameObject southFacingImage;
    public GameObject deactivatedImage;


    public void Update()
    {
        if (leftPlug.isPlugedLeftCable && rightPlug.isPlugedRightCable)
        {
            electroMagnet.Activated = true;
            electroMagnet.isNorth = true;
            northFacingImage.SetActive(true);
            southFacingImage.SetActive(false);
            deactivatedImage.SetActive(false);
            return;
        }

        if (leftPlug.isPlugedRightCable && rightPlug.isPlugedLeftCable)
        {
            electroMagnet.Activated = true;
            electroMagnet.isNorth = false;
            northFacingImage.SetActive(false);
            southFacingImage.SetActive(true);
            deactivatedImage.SetActive(false);
            return;
        }

        electroMagnet.Activated = false;
        northFacingImage.SetActive(false);
        southFacingImage.SetActive(false);
        deactivatedImage.SetActive(true);
    }
}
