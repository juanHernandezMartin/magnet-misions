using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject parent;
    public Horientation horientation;
    public float magnetStrenht;
    public LayerMask magnetLayer;
    public Rigidbody2D rb;
    public List<Transform> magnetsAround;
    public List<Horientation> magnetsAroundH;


    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == parent)
        {
            return;
        }

        if ((magnetLayer.value & (1 << col.gameObject.layer)) != 0)
        {
            magnetsAround.Add(col.gameObject.transform);
            magnetsAroundH.Add(col.gameObject.GetComponent<Horientation>());
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (magnetsAround.Contains(col.gameObject.transform))
        {
            magnetsAroundH.Remove(col.gameObject.GetComponent<Horientation>());
            magnetsAround.Remove(col.gameObject.transform);
        }
    }

    public void Update()
    {
        for (int magnetIndex = 0; magnetIndex < magnetsAround.Count; magnetIndex++)
        {
            if (magnetsAroundH[magnetIndex].Activated)
            {
                treatMaget(magnetsAround[magnetIndex], magnetsAroundH[magnetIndex]);
            }
        }
    }

    public void treatMaget(Transform targetMagnet, Horientation targetHor)
    {

        float distance = Vector3.Distance(transform.position, targetMagnet.position);
        float forceMultiplier = magnetStrenht;
        bool isAtractive = horientation.isNorth == targetHor.isNorth;

        if (!isAtractive)
        {
            forceMultiplier = -forceMultiplier;
        }

        float force = forceMultiplier * magnetStrenht / (distance * distance);

        if (targetMagnet.position.y < transform.position.y)
        {
            //
        }

        force = -force;

        Vector3 forceDirection = transform.position - targetMagnet.position;

        rb.AddForce(forceDirection * force * Time.deltaTime);
    }

}