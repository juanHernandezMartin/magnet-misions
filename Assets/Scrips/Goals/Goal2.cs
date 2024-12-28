using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal2 : MonoBehaviour
{
    public string tagName;
    public string nexteSceneName;
    public MagnetSpawner spawner;
    public bool isNorth;

    private AudioSource audioGoal;

    public void Start()
    {
        audioGoal = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag(tagName))
        {
            spawner.magnetsSpawned++;
            audioGoal.Play();
            AnimateMagnetEnd();
        }
    }


    private void AnimateMagnetEnd()
    {
        GameObject magnet = spawner.magnets[spawner.nextTypeOfMagnet];
        Rigidbody2D magnetRb = spawner.magnetsRb[spawner.nextTypeOfMagnet];

        magnetRb.isKinematic = true;
        BoxCollider2D colMagnet = magnet.GetComponent<BoxCollider2D>();
        colMagnet.enabled = false;
        //magnet.transform.position = transform.position + (Vector3.up * 2);
        Vector3 targetPos = transform.position + (Vector3.up * 2);
        Tween magnetMov = magnet.transform.DOMove(targetPos, 1);
        magnetMov.OnComplete(() =>
        {
            magnet.SetActive(false);
            magnetRb.isKinematic = false;
            colMagnet.enabled = true;
            if (spawner.magnetsSpawned == spawner.magnetsToSpawn)
            {
                SceneManager.LoadScene(nexteSceneName);
            }
            else
            {
                spawner.SpawnMagnet();
            }
        });
    }
}
