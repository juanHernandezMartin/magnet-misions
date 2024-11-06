using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    private bool grabbed;
    public Rigidbody2D rbMagnet;
    //public bool allowHorizontal;
    //public bool allowVertical;

    private void Awake()
    {
        grabbed = false;
    }

    private void OnMouseDown()
    {
        grabbed = true;
    }

    private void OnMouseUp()
    {
        grabbed = false;
    }

    private void Update()
    {
        if (grabbed)
        {
            rbMagnet.velocity = Vector2.zero;
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            worldPosition.z = 0;

            //transform.position = worldPosition;

            //Vector3 newVelocity = worldPosition - transform.position;
            //rb.velocity = Vector3.Lerp(rb.velocity, newVelocity, 2 * Time.deltaTime);
            rbMagnet.velocity = (worldPosition - transform.position) * 20;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.gameObject.CompareTag("NoGrab"))
        {
            grabbed = false;
        }

        if (col.transform.gameObject.CompareTag("Placed"))
        {
            grabbed = false;
        }

        if (col.transform.gameObject.CompareTag("NewGameIndicator"))
        {
            grabbed = false;
        }
    }
}
