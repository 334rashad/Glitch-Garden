using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int waitSeconds = 3;
    int currentSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(waitSeconds);
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex+1);
    }

    public void LoadLoosingScene()
    {
        SceneManager.LoadScene("Loose Screen");
    }
}
