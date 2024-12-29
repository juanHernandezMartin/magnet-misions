using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinamo : MonoBehaviour
{
    public Rigidbody2D rbDinamo;
    public float anSpeedToMagnetice;

    public Horientation electroMagnet;
    public GameObject northFacingImage;
    public GameObject southFacingImage;
    public GameObject deactivatedImage;

    public void Update()
    {
        if (rbDinamo.angularVelocity > anSpeedToMagnetice)
        {
            electroMagnet.Activated = true;
            electroMagnet.isNorth = true;
            northFacingImage.SetActive(true);
            southFacingImage.SetActive(false);
            deactivatedImage.SetActive(false);
            return;
        }

        if (rbDinamo.angularVelocity < -anSpeedToMagnetice)
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

        if( Input.GetKeyDown(KeyCode.P))
        {
            print(rbDinamo.angularVelocity);
        }
    }
}
