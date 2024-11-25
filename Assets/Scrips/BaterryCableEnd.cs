using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaterryCableEnd : MonoBehaviour
{
    //[HideInInspector]
    public bool isPlugedLeftCable;
    public bool isPlugedRightCable;
    public GameObject currCable;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("LeftCable"))
        {
            currCable = col.gameObject;
        }

        if (col.CompareTag("RightCable"))
        {
            currCable = col.gameObject;
        }
    }


    public void OnMouseUp()
    {
        if (currCable != null)
        {
            if (currCable.CompareTag("LeftCable"))
            {
                isPlugedLeftCable = true;
            }

            if (currCable.CompareTag("RightCable"))
            {
                isPlugedRightCable = true;
            }

            currCable.transform.position = transform.position;
        }
    }

    public void OnMouseDown()
    {
        isPlugedLeftCable = false;
        isPlugedRightCable = false;
    }


    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("LeftCable"))
        {
            currCable = null;
        }

        if (col.CompareTag("RightCable"))
        {
            currCable = null;
        }
    }

}
