using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal2 : MonoBehaviour
{
    public string nexteSceneName;
    public MagnetSpawner spawner;
    public bool isNorth;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("GoalMagnet"))
        {
            if (col.gameObject.GetComponent<Horientation>().isNorth == isNorth)
            {
                spawner.magnetsSpawned++;
                col.gameObject.SetActive(false);

                if (spawner.magnetsSpawned == spawner.magnetsToSpawn)
                {
                    SceneManager.LoadScene(nexteSceneName);
                }
                else
                {
                    spawner.SpawnMagnet();
                }
            }
        }
    }
}