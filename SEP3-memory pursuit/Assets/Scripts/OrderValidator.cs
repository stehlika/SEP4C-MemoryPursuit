using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class OrderValidator : MonoBehaviour {
    [SerializeField]
    private string[] collection;
    public List<string> theRealCollection;


    public bool OrderIsValid()
    {
        theRealCollection = theRealCollection.OrderBy(x => x).ToList();
        collection = new string[theRealCollection.Count];
        List<PlaceHolder>allPlaceHolders = new List<PlaceHolder>();
        foreach (var item in GameObject.FindGameObjectsWithTag("PlaceHolder"))
        {
           allPlaceHolders.Add(item.GetComponent<PlaceHolder>());
        }
        allPlaceHolders.Sort();
        //populate the collection
        for (int i = 0; i < allPlaceHolders.Count; i++)
        {
            if (!(allPlaceHolders[i].GetGameObject() == null))
            {
                Debug.Log("som v placeholderi s id " + allPlaceHolders[i].getId());
                collection[i] = allPlaceHolders[i].GetGameObject().GetComponentInChildren<Text>().text;
            }
            
        }

        for(int i=0; i<collection.Length; i++)
        {
            Debug.Log("porovnavam :" + theRealCollection[i] + " and " + collection[i]);
            if (collection[i] == null || !(collection[i].Equals(theRealCollection[i])))
            {
                Debug.Log("FALSE");
                return false;
            }
        }
        Debug.Log("TRUE");
        return true;

    }   
}
