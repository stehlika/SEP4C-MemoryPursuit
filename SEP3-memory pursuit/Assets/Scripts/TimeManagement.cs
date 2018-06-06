using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TimeManagement : MonoBehaviour {

    private DateTime startTime;
    private DateTime endTime;
    private DateTime timeDifference;
    [SerializeField] private int TimeBudget;
    [SerializeField] private double difference;
    private Coroutine calculateTime = null;

	// Use this for initialization
	void Start () {
        
        if (DataManagement.Instance.difficulty == Application.Difficulty.Easy)
            TimeBudget = 30;
        if (DataManagement.Instance.difficulty == Application.Difficulty.Moderate)
            TimeBudget = 20;
        if (DataManagement.Instance.difficulty == Application.Difficulty.Hard)
            TimeBudget = 10;

        startTime = DateTime.Now;
		
        calculateTime = StartCoroutine (CalculateTime());    
	}

    public int TimeDifference() {
        difference = (DateTime.Now - startTime).TotalSeconds;
        return TimeBudget - Convert.ToInt32(Math.Round(difference));
    }

    IEnumerator CalculateTime()
    {
        while (true || calculateTime != null)
        {
            int timeRemaining = TimeDifference();
            if (timeRemaining <= 0) {
                StopCoroutine(calculateTime);
                GameObject levelManagement = GameObject.FindGameObjectWithTag("LevelManagement");
                if (levelManagement != null)
                {
                    calculateTime = null;
                    endTime = DateTime.Now;
                    levelManagement.GetComponent<RememberElementsManager>().RememberDone();
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public double StopCounting() 
    {
        StopCoroutine(calculateTime);
        calculateTime = null;
        endTime = DateTime.Now;
        return (endTime - startTime).TotalSeconds;
    }
}