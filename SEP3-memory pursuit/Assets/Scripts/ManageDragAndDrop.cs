using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageDragAndDrop : MonoBehaviour {

    private GameObject draggedObject;
    public void Drag()
    {
        if (draggedObject == null)
        {
            Debug.Log("I dont hold any object");
        }
        else
        {
            draggedObject.transform.position = Input.mousePosition;
        }
    }
    public void SetGameObject(GameObject obj)
    {
        draggedObject = obj;
    }
    public void Drop()
    {


        float distance=100;
        GameObject[] AllPlaces = GameObject.FindGameObjectsWithTag("PlaceHolder");
        foreach (var item in AllPlaces)
        {
            if (item.GetComponent<PlaceHolder>().GetGameObject() != null)
            {
                if (item.GetComponent<PlaceHolder>().GetGameObject().name.Equals(draggedObject.name))
                {
                    item.GetComponent<PlaceHolder>().Empty();
                }
            }

        }
        GameObject placeHolder = null ;
        foreach (var item in AllPlaces)
        {
            if (distance>Vector3.Distance(item.transform.position,draggedObject.transform.position) && !(item.GetComponent<PlaceHolder>().isTaken()))
            {
                Debug.Log("som tu a setujem novu distance ");
                distance = Vector3.Distance(item.transform.position, draggedObject.transform.position);
                placeHolder = item;
            }
        }
        if (placeHolder != null)
        {
            if (placeHolder.GetComponent<PlaceHolder>() != null)
            {
                placeHolder.GetComponent<PlaceHolder>().Setfull();
                placeHolder.GetComponent<PlaceHolder>().SetObjectHeld(draggedObject);
            }
            draggedObject.transform.position = placeHolder.transform.position;
        }

        
    }
}
