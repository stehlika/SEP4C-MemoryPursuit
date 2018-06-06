using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class VerifyElementsManager : MonoBehaviour {
    [SerializeField] List<string> elements = new List<string>();
    [SerializeField] GameObject prefabToSpawn;
    [SerializeField] List<string> verfieidElements = new List<string>();


	// Use this for initialization
	void Start () {
        elements = DataManagement.Instance.GetLevelElementsForVerification();

        elements.Shuffle();
        InstantiateElements();
		
	}

    private void InstantiateElements()
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");

        foreach (string ele in elements)
        {
            GameObject newElement = Instantiate(prefabToSpawn);
            newElement.transform.SetParent(canvas.transform);

            newElement.GetComponentInChildren<Text>().text = ele;

        }
    }

    public void VerifyDone()
    {
        var verifiedButtons = GameObject.FindGameObjectsWithTag("MarkSeen");
        foreach(GameObject gmObj in verifiedButtons)
        {
            string btnText = gmObj.GetComponentInChildren<Text>().text;
            verfieidElements.Add(btnText);
        }

        int rightAnswers = CheckRightAnswers(verfieidElements);

        double tookTime = GetComponent<TimeManagement>().StopCounting();

        DataManagement.Instance.rememberElementsTime = tookTime;
        DataManagement.Instance.userScore += Convert.ToInt32(Math.Round(tookTime) * 10);
        DataManagement.Instance.userScore += rightAnswers * 19;

        GetComponent<SceneManagement>().NextScreen("ScoreScene");

    }


    private int CheckRightAnswers(List<string> answers)
    {
        int counter = 0;
        foreach(string answer in answers)
        {
            foreach(string reqired in DataManagement.Instance.elements)
                if (answer == reqired)
                    counter++;
        }

        return counter;
    }
}
