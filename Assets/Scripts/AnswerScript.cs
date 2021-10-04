using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public MCQ mcq;

    public void Answer()
    {
        GameObject.Find("A_button").GetComponent<Button>().interactable = false;
        GameObject.Find("B_button").GetComponent<Button>().interactable = false;
        GameObject.Find("C_button").GetComponent<Button>().interactable = false;
        GameObject.Find("D_button").GetComponent<Button>().interactable = false;
        if(isCorrect)
        {
            Debug.Log("Correct Answer");
            mcq.correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
            mcq.correct();
        }
    }
}
