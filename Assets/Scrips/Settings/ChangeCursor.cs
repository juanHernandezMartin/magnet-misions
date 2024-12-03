using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    public GameObject cursorP1Prefab;
    private GameObject customCursorP1;

    public void Start()
    {
        Cursor.visible = false;
        customCursorP1 = Instantiate( cursorP1Prefab, transform.position, transform.rotation);
    }

    public void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = -5;
        customCursorP1.transform.position = worldPosition;
    }
}
