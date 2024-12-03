using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaterryCableEnd : MonoBehaviour
{
    //[HideInInspector]
    public bool isPlugedLeftCable;
    public bool isPlugedRightCable;
    public float AtractionForce;
    public GameObject currCable;


    private Rigidbody2D rbCable;

    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
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

                //currCable.transform.position = transform.position;
            }
        }

        if (Input.GetMouseButtonDown(0) && currCable != null)
        {
            isPlugedLeftCable = false;
            isPlugedRightCable = false;
        }

        if( rbCable != null && ( isPlugedLeftCable || isPlugedRightCable ) )
        {
            Vector3 forceDir = currCable.transform.position;
            forceDir = transform.position - forceDir;
            rbCable.AddForce( forceDir * AtractionForce * Time.deltaTime );
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("LeftCable") || col.CompareTag("RightCable"))
        {
            currCable = col.gameObject;
            rbCable = col.gameObject.GetComponent<Rigidbody2D>();
        }
    }


    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("LeftCable"))
        {
            currCable = null;
            rbCable = null;
        }

        if (col.CompareTag("RightCable"))
        {
            currCable = null;
            rbCable = null;
        }
    }

}
