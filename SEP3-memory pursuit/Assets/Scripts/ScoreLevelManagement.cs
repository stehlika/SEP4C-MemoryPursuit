using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLevelManagement : MonoBehaviour {

    [SerializeField] Text scoredPoints;
    [SerializeField] Text bestScore;
    private SceneManagement sceneManagement;

	// Use this for initialization
	void Start () {
        scoredPoints.text = DataManagement.Instance.userScore + " points";
        sceneManagement = GetComponent<SceneManagement>();
	}

    public void PlayAgain()
    {
        sceneManagement.NextScreen("RemeberScene");
    }

    public void GoToMenu()
    {
        sceneManagement.NextScreen("MenuScene");
    }
}
