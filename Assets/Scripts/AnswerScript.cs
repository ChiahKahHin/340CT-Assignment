using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public MCQ mcq;

    public void Answer()
    {
        if(isCorrect)
        {
            Debug.Log("Correct Answer");
            mcq.correct("Correct Answer");
        }
        else
        {
            Debug.Log("Wrong Answer");
            mcq.correct("Wrong Answer");
        }
        test();
    }

    public void test()
    {
        Debug.Log(4);
        GameObject.Find("A_button").GetComponent<Animator>().Play("AButtonLeft");
        GameObject.Find("B_button").GetComponent<Animator>().Play("BButtonRight");
        GameObject.Find("C_button").GetComponent<Animator>().Play("CButtonLeft");
        GameObject.Find("D_button").GetComponent<Animator>().Play("DButtonRight");
        GameObject.Find("MessagePanel").GetComponent<Animator>().Play("MessagePanelEnlarge");
    }
}
