using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    public Transform magnetEnd;
    public Transform batteryEnd;

    // Start is called before the first frame update
    public void Start()
    {
        Vector3 posToMove = transform.position;
        posToMove.y = ( magnetEnd.position.y + batteryEnd.position.y) / 2;
        transform.position = posToMove;
    }

    // Update is called once per frame
    public void Update()
    {
        Vector3 posToMove = transform.position;
        posToMove.x = ( magnetEnd.position.x + batteryEnd.position.x) / 2;
        transform.position = posToMove;

        transform.right = magnetEnd.position - transform.position;
    }
}
