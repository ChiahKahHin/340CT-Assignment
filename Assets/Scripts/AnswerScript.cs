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
        if(isCorrect)
        {
            score = 500;
            Debug.Log("Correct Answer");
            mcq.correct("Correct Answer");
        }
        else
        {
            score = 0;
            Debug.Log("Wrong Answer");
            mcq.correct("Wrong Answer");
        }
        ButtonAnimation();
        StartCoroutine(GameControl.EndMCQ(score));
    }

    public void ButtonAnimation()
    {
        GameObject.Find("A_button").GetComponent<Animator>().Play("AButtonLeft");
        GameObject.Find("B_button").GetComponent<Animator>().Play("BButtonRight");
        GameObject.Find("C_button").GetComponent<Animator>().Play("CButtonLeft");
        GameObject.Find("D_button").GetComponent<Animator>().Play("DButtonRight");
        GameObject.Find("MessagePanel").GetComponent<Animator>().Play("MessagePanelEnlarge");
    }
}
