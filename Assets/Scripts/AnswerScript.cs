using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public MCQ mcq;
    private int score;
    
    public void Answer()
    {
        GameObject.Find("A_button").GetComponent<Button>().interactable = false;
        GameObject.Find("B_button").GetComponent<Button>().interactable = false;
        GameObject.Find("C_button").GetComponent<Button>().interactable = false;
        GameObject.Find("D_button").GetComponent<Button>().interactable = false;
        if(isCorrect)
        {
            score = 500;
            Debug.Log("Correct Answer");
            mcq.correct();
        }
        else
        {
            score = 0;
            Debug.Log("Wrong Answer");
            mcq.correct();
        }
        StartCoroutine(GameControl.EndMCQ(score));
    }
}
