using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelCreator : MonoBehaviour {
    [SerializeField]
    private OrderValidator orderValidator;
    [SerializeField]
    private List<string> AllElements;
    // TODO : here we have to do correct selection of distraction cities(currently we are only getting cities;
    // so maybe some switch statement would make sense.
	void Start () {
        AllElements = DataManagement.Instance.Cities;
        orderValidator =  GameObject.FindGameObjectWithTag("GameController").GetComponent<OrderValidator>();
        List<string> unvisitedElements =  new List<string>(AllElements);
        foreach (var item in GameObject.FindGameObjectsWithTag("Mesto"))
        {
            int randomIndex = Random.Range(0, unvisitedElements.Count);
            orderValidator.theRealCollection.Add(unvisitedElements[randomIndex]);
            item.GetComponentInChildren<Text>().text = AllElements[randomIndex];
            unvisitedElements.RemoveAt(randomIndex);
        }
        
	}
}
