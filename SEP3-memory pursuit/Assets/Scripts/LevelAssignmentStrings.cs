using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LevelAssignmentStrings : MonoBehaviour {
    
    [SerializeField] private List<String> assignments = new List<String>();
 
    private void Start()
    {


        Debug.Log(assignments.ToString());
        assignments.Shuffle();
        Debug.Log(assignments.ToString());

        foreach (String assign  in assignments)
        {
            /*
            Vector2 newPosition = new Vector2(xPosition, yPosition);
            Instantiate(assign, newPosition, Quaternion.identity);
            yPosition -= 1f;
            */
        }
    }

    public void NextScreen() {
        Debug.Log("Should load new screen");
       // TimeManagement
        SceneManager.LoadScene("DistractionScene", LoadSceneMode.Single);
    }
}
