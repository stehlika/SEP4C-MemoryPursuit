using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {
    [SerializeField] private string SceneName;

    public void NextScreen()
    {
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
    }

    public void NextScreen(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
