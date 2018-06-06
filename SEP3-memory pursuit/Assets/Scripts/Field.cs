using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour {

    [SerializeField] int expectedValue;
    [SerializeField] GameObject levelManagement;

    private void Start()
    {
        levelManagement = GameObject.FindGameObjectWithTag("LevelManagement");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     //   MajongStone stone = collision.GetComponent<MajongStone>();
     //   if (stone != null)
     //       levelManagement.GetComponent<LevelAssignment>().addNumberFromUser(stone.value);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
     //   MajongStone stone = collision.GetComponent<MajongStone>();
     //   if(stone != null)
     //       levelManagement.GetComponent<LevelAssignment>().removeNumberFromUser(stone.value);
    }
}
