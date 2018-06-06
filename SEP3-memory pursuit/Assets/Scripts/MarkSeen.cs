using UnityEngine;
using UnityEngine.UI;

public class MarkSeen : MonoBehaviour {

    [SerializeField] private Color newColor = Color.blue;

    public void Mark()
    {
        gameObject.tag = "MarkSeen";
        gameObject.GetComponent<Image>().color = newColor;
    }
}
