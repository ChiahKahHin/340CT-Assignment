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
    }
}
