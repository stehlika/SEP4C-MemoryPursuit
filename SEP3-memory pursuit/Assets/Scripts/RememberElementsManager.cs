using System;
using System.Collections;
using System.Collections.Generic;
using Application;
using UnityEngine;
using UnityEngine.UI;

public class RememberElementsManager : MonoBehaviour {

    [SerializeField]
    private List<string> elements = new List<string>();

    [SerializeField]
    private GameType gameType;

    [SerializeField]
    private GameObject prefabToSpawn;

	// Use this for initialization
	void Start () {
        gameType = Helpers.RandomGameType();

        elements = DataManagement.Instance.GetLevelElements(gameType);

        elements.Shuffle();
        InstantiateElements();
	}

    private void InstantiateElements() 
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");

        foreach(string ele in elements)
        {
            GameObject newElement = Instantiate(prefabToSpawn);
            newElement.transform.SetParent(canvas.transform); 
       
            newElement.GetComponentInChildren<Text>().text = ele;
            
        }
    }

    public void RememberDone() 
    {
        Debug.LogWarning("Should load new scene");
        DataManagement.Instance.elements = elements;
        DataManagement.Instance.gameType = gameType;
        double tookTime = GetComponent<TimeManagement>().StopCounting();
        DataManagement.Instance.rememberElementsTime = tookTime;

        DataManagement.Instance.userScore += Convert.ToInt32(Math.Round(tookTime) * 10);

        // Commented out for debugging purpose     
        GetComponent<SceneManagement>().NextScreen("DistractionScene");
    }
}
