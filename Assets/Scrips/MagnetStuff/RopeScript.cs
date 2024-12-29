using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    public Transform magnetEnd;
    public Transform batteryEnd;
    public float scaleMult;

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

        Vector3 posToMoveY = transform.position;
        posToMoveY.y = ( magnetEnd.position.y + batteryEnd.position.y) / 2;
        transform.position = posToMoveY;

        transform.right = magnetEnd.position - transform.position;

        Vector3 scaleToSet = transform.localScale;
        scaleToSet.x = Vector3.Distance(magnetEnd.position, batteryEnd.position ) * scaleMult;
        transform.localScale = scaleToSet;
    }
}
