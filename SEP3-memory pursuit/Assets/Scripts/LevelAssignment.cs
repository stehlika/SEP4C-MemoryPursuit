using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAssignment : MonoBehaviour {

/*    [SerializeField] private List<int> assignedNumbers = new List<int>();
    [SerializeField] private List<int> userNumbers = new List<int>();

	// Use this for initialization
	void Start () {
        GameObject[] majongStones = GameObject.FindGameObjectsWithTag("MajongStone");
        foreach (GameObject stone in majongStones) {
            assignedNumbers.Add(stone.GetComponent<MajongStone>().value);
        }

        assignedNumbers.Sort();
	}

    public void addNumberFromUser(int number) {
        userNumbers.Add(number);
        if (assignedNumbers.Count == userNumbers.Count) {
            Debug.LogWarning("All numbers are filled");
            if(allNumbersFilled()) {
                // end game
                Debug.LogWarning("Numbers are correct");
            } else {
                Debug.LogWarning("Numbers are wrongly assigned");
            }
        }
    } 

    public void removeNumberFromUser(int number) {
        userNumbers.Remove(number);
    }


    public bool allNumbersFilled() {
        for (int i = 0; i < assignedNumbers.Count; i++) {
            if (assignedNumbers[i] != userNumbers[i])
                return false;
        }
        return true;
    }
*/
}
