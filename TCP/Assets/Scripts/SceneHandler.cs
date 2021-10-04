using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public int ReturnSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

}
