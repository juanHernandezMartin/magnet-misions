using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MagnetSpawner : MonoBehaviour
{
    public List<GameObject> MagnetsTypes;
    public int magnetsToSpawn;
    public int currentLevel = -1;

    [HideInInspector] public List<GameObject> magnets;
    [HideInInspector] public List<Rigidbody2D> magnetsRb;
    [HideInInspector] public List<SpriteRenderer> magnetsRender;
    [HideInInspector] public int magnetsSpawned;
    [HideInInspector] public int nextTypeOfMagnet;


    public void Awake()
    {
        magnetsSpawned = 0;
        magnets = new List<GameObject>();
        magnetsRb = new List<Rigidbody2D>();
        magnetsRender = new List<SpriteRenderer>();

        for (int i = 0; i < MagnetsTypes.Count; i++)
        {
            int nextTypeOfMagnet = Random.Range(0, MagnetsTypes.Count);
            magnets.Add(Instantiate(MagnetsTypes[nextTypeOfMagnet], transform.position, transform.rotation));
            if (!magnets[i].GetComponent<Horientation>().isNorth)
            {
                magnets[i].transform.Rotate(0, 0, 180);
            }

            magnets[i].SetActive(false);
            magnets[i].transform.SetParent(transform);
            magnetsRb.Add(magnets[i].GetComponent<Rigidbody2D>());
            magnetsRender.Add(magnets[i].GetComponent<Horientation>().rnd);
        }
    }

    public void Start()
    {
        SpawnMagnet();
    }

    public void SpawnMagnet()
    {
        nextTypeOfMagnet = Random.Range(0, MagnetsTypes.Count);
        GameObject currMagnet = magnets[nextTypeOfMagnet];
        currMagnet.transform.position = transform.position;
        currMagnet.SetActive(true);

        AnimateMagnetStart(currMagnet, magnetsRb[nextTypeOfMagnet]);
    }

    private void AnimateMagnetStart(GameObject magnet, Rigidbody2D magnetRb)
    {
        magnetRb.isKinematic = true;
        BoxCollider2D colMagnet = magnet.GetComponent<BoxCollider2D>();
        colMagnet.enabled = false;
        magnet.transform.position = transform.position + (Vector3.up * 2);
        Tween magnetMov = magnet.transform.DOMove(transform.position, 1);
        magnetMov.OnComplete(() =>
        {
            magnetRb.isKinematic = false;
            colMagnet.enabled = true;
        });
    }
}
