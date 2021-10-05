using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MCQ : MonoBehaviour
{
    public List<Questions> QnA;
    public GameObject[] options;
    public GameObject MessagePanel;
    public int currentQuestion;
    public int tempQuestion;

    public Text QuestionTxt;

    private void Start()
    {
        generateQuestion();
        MessagePanel.SetActive(false);
    }

    public void correct(string message)
    {
        MessagePanel.SetActive(true);
        MessagePanel.transform.GetChild(0).GetComponent<Text>().text = message;

        StartCoroutine(stop());
        
        //QnA.RemoveAt(currentQuestion);
        //generateQuestion();
    }

    void setAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].answers[i];

            if(QnA[currentQuestion].correctAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        MessagePanel.SetActive(false);

        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            if(currentQuestion != tempQuestion)
            {
                tempQuestion = currentQuestion;
            }
            else
            {
                currentQuestion++;
            }

            QuestionTxt.text = QnA[currentQuestion].questions;
            setAnswer();
        }
        else
        {
            Debug.Log("Out of Questions");
        }
    }

    public IEnumerator stop()
    {
        yield return new WaitForSeconds(20f);
        //generateQuestion();
    }
}
