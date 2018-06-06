using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHolder : MonoBehaviour, IComparable<PlaceHolder> {
    [SerializeField]
    private bool isFilled = false;
    [SerializeField]
    private GameObject objectHeld;
    [SerializeField]
    private int id;

    public int getId()
    {
        return id;
    }
    public void Setfull()
    {
        isFilled = true;
    }
    public void Empty()
    {
        isFilled = false;
        objectHeld = null;
    }
    public bool isTaken()
    {
        return isFilled;
    }
    public void SetObjectHeld(GameObject gameObject)
    {
        this.objectHeld = gameObject;
    }
    public GameObject GetGameObject()
    {
        return objectHeld;
    }

    public int CompareTo(PlaceHolder other)
    {
        
        if (this.id > other.id) return 1;
        if (this.id == other.id) return 0;
        return -1;
    }
    public int GetId()
    {
        return id;
    }
}
