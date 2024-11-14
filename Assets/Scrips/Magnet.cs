using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public Horientation horientation;
    public float magnetStrenht;
    public LayerMask magnetLayer;
    public Rigidbody2D rb;
    public List<GameObject> magnetsAround;
    public List<Horientation> magnetsAroundH;


    public void OnTriggerEnter2D(Collider2D col)
    {
        if ((magnetLayer.value & (1 << col.gameObject.layer)) != 0)
        {
            magnetsAround.Add(col.gameObject);
            magnetsAroundH.Add(col.gameObject.GetComponent<Horientation>());
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (magnetsAround.Contains(col.gameObject))
        {
            magnetsAroundH.Remove(col.gameObject.GetComponent<Horientation>());
            magnetsAround.Remove(col.gameObject);
        }
    }

    public void Update()
    {
        for( int magnetIndex = 0; magnetIndex < magnetsAround.Count; magnetIndex++ )
        {
            treatMaget( magnetsAround[magnetIndex], magnetsAroundH[magnetIndex] );
        }
    }

    public void treatMaget( GameObject targetMagnet, Horientation targetHor )
    {
        bool isAtractive = horientation.isNorth == targetHor.isNorth;
    }

}