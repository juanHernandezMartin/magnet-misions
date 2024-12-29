using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string nextSceneName;

    public void OnMouseUp()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}