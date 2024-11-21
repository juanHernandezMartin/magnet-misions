using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public string nexteSceneName;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("GoalMagnet") )
        {
            SceneManager.LoadScene(nexteSceneName);
        }
    }
}
