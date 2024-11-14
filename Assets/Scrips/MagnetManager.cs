using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MagnetManager : MonoBehaviour
{
    public List<GameObject> magnets;


    [HideInInspector] public UnityEvent reload;
    public static MagnetManager instance;

    void Awake()
    {
        instance = this;
        reload = new UnityEvent();
    }
}
