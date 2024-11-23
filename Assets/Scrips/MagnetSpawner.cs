using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetSpawner : MonoBehaviour
{
    public List<GameObject> MagnetsTypes;
    public float spawnForce;
    public int magnetsToSpawn;

    private List<GameObject> magnets;
    private List<Rigidbody2D> magnetsRb;
    [HideInInspector] public int magnetsSpawned;

    public void Awake()
    {
        magnetsSpawned = 0;
        magnets = new List<GameObject>();
        magnetsRb = new List<Rigidbody2D>();
        for (int i = 0; i < MagnetsTypes.Count; i++)
        {
            int nextTypeOfMagnet = Random.Range(0, MagnetsTypes.Count);
            magnets.Add(Instantiate(MagnetsTypes[nextTypeOfMagnet], transform.position, transform.rotation ));
            if( !magnets[i].GetComponent<Horientation>().isNorth )
            {
                magnets[i].transform.Rotate( 0, 0, 180 );
            }

            magnets[i].SetActive(false);
            magnets[i].transform.SetParent(transform);
            magnetsRb.Add(magnets[i].GetComponent<Rigidbody2D>());
        }
    }

    public void Start()
    {
        SpawnMagnet();
    }

    public void SpawnMagnet()
    {
        int nextTypeOfMagnet = Random.Range(0, MagnetsTypes.Count);
        GameObject currMagnet = magnets[nextTypeOfMagnet];
        currMagnet.transform.position = transform.position;
        currMagnet.SetActive(true);
        Vector2 force = new Vector2(0, -spawnForce);
        magnetsRb[nextTypeOfMagnet].AddForce(force);
    }
}
