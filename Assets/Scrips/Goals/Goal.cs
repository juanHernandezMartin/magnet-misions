using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public string nexteSceneName;
    public int goalMagnetsOnScene;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("GoalMagnet"))
        {
            goalMagnetsOnScene--;
            Destroy(col.gameObject);

            if (goalMagnetsOnScene == 0)
            {
                SceneManager.LoadScene(nexteSceneName);
            }
        }
    }
}
