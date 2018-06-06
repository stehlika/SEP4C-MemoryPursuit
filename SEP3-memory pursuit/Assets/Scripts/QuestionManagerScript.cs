using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionManagerScript : MonoBehaviour {

    public Question[] questions;
    private static List<Question> unansweredQuestions;
    private Question currentQuestion;
    [SerializeField]
    private float delay=0.1f;
    [SerializeField]
    private Text questionReference;
    [SerializeField]
    Image imgCorrect;
    [SerializeField]
    Image imgWrong;
    [SerializeField]
    Canvas canvas;
    [SerializeField] private GameObject levelManagement;


    //TODO : finish so that the questions are taken from the DataManagement not created in serialized field.
    void Start()
    {
        levelManagement = GameObject.FindGameObjectWithTag("LevelManagement");
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }
        PickRandomQuestion();
        Debug.Log("current Question is" + currentQuestion.content + "is " + currentQuestion.isTrue);
    }

    void PickRandomQuestion()
    {
        int randomIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomIndex];
        questionReference.text = currentQuestion.content;
    }
    public void userSelectedTrue()
    {
        if (currentQuestion.isTrue)
        {
            Instantiate(imgCorrect, canvas.transform);
            canvas.GetComponent<GraphicRaycaster>().enabled = false;
            Debug.Log("correct");
            DataManagement.Instance.counterForQuestions++;
        }
        else
        {
            Instantiate(imgWrong, canvas.transform);
            canvas.GetComponent<GraphicRaycaster>().enabled = false;
            Debug.Log("Wrong");
            DataManagement.Instance.counterForQuestions++;
        }
        if (DataManagement.Instance.difficulty == Application.Difficulty.Easy && DataManagement.Instance.counterForQuestions == 1)
        {
            levelManagement.GetComponent<SceneManagement>().NextScreen("VerificationScene");
        }
        else
        {
            StartCoroutine(NextQuestion());
        }
    }
    public void userSelectedFalse()
    {
        if (!currentQuestion.isTrue)
        {
            
            Instantiate(imgCorrect, canvas.transform);
            canvas.GetComponent<GraphicRaycaster>().enabled = false;
            Debug.Log("correct");
            DataManagement.Instance.counterForQuestions++;
        }
        else
        {
            Instantiate(imgWrong, canvas.transform);
            canvas.GetComponent<GraphicRaycaster>().enabled = false;
            Debug.Log("Wrong");
            DataManagement.Instance.counterForQuestions++;
        }
        if (DataManagement.Instance.difficulty == Application.Difficulty.Easy && DataManagement.Instance.counterForQuestions==1)
        {
            levelManagement.GetComponent<SceneManagement>().NextScreen("VerificationScene");
        }
        else
        {
            StartCoroutine(NextQuestion());
        }
        
        
    }
    IEnumerator NextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
