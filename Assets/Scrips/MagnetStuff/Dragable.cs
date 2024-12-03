using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    public bool grabbed;
    public Rigidbody2D rbMagnet;
    //public bool allowHorizontal;
    //public bool allowVertical;

    public void Awake()
    {
        grabbed = false;
    }

    public void OnMouseDown()
    {
        grabbed = true;
    }

    public void OnMouseUp()
    {
        grabbed = false;
    }

    public void Update()
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
}
