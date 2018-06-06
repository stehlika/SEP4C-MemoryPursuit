using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MestovyMenic : MonoBehaviour {
    [SerializeField] private GameObject levelManagement;

    private void Start()
    {
        levelManagement = GameObject.FindGameObjectWithTag("LevelManagement");

    }

    public void Zmen()
    {
        if (GetComponentInParent<OrderValidator>().OrderIsValid())
        {
            Debug.Log("mas 3x ano postupujes");
            if(levelManagement != null)
            {
                levelManagement.GetComponent<SceneManagement>().NextScreen("QuestionsDistractionScene");
            } else
            {
                Debug.LogWarning("nenaslo sa");
            }
           
        }
        else { Debug.Log("nepresiel si"); }
        
    }
}
