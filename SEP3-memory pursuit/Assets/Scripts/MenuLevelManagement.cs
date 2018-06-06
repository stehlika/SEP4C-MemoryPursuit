using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Application;
using UnityEngine.UI;

public class MenuLevelManagement : MonoBehaviour {

    [SerializeField] GameObject playBtn;
    [SerializeField] GameObject instructionsBtn;
    [SerializeField] GameObject changeDiffBtn;

    private GameObject levelManagement;


	// Use this for initialization
	void Start () 
    {
        levelManagement = GameObject.FindGameObjectWithTag("LevelManagement");
	}

    public void StartGame()
    {        
        if (levelManagement != null)
            levelManagement.GetComponent<SceneManagement>().NextScreen("RememberScene");
    }

    public void ChangeDifficulty()
    {
        if (DataManagement.Instance.difficulty == Difficulty.Easy)
        {
            DataManagement.Instance.difficulty = Difficulty.Moderate;
            changeDiffBtn.GetComponentInChildren<Text>().text = "Moderate";
        } 
        else if (DataManagement.Instance.difficulty == Difficulty.Moderate)
        {
            DataManagement.Instance.difficulty = Difficulty.Hard;
            changeDiffBtn.GetComponentInChildren<Text>().text = "Hard";
        } 
        else if(DataManagement.Instance.difficulty == Difficulty.Hard)
        {
            DataManagement.Instance.difficulty = Difficulty.Easy;
            changeDiffBtn.GetComponentInChildren<Text>().text = "Easy";
        } else {
            DataManagement.Instance.difficulty = Difficulty.Easy;
            changeDiffBtn.GetComponentInChildren<Text>().text = "Easy";
        }
        
    }
    
    public void ShowInstructions()
    {
        if (levelManagement != null)
            levelManagement.GetComponent<SceneManagement>().NextScreen("InstructionsScene");
    }
}
