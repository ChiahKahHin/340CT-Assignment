using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public MCQ mcq;

    public float timeValue, maxTime, maxScore = 1000F;
    public Text timeText;
    public static bool isAnswer;

    void Start()
    {
        isAnswer = false;
        timeValue = maxTime = 30F;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAnswer)
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
                Debug.Log(timeValue);
            }
            else
            {
                timeValue = 0F;
                isAnswer = true;
                Answer();
            }

            DisplayTime(timeValue);
        }
        
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        Color color;

        ColorUtility.TryParseHtmlString("#FF0000", out color);

        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = timeToDisplay % 1 * 100;
        if (timeToDisplay < 5)
        {
            timeText.color = color;
        }
        timeText.text = string.Format("{0:00}:{1:00}", seconds, milliseconds);
    }

    public void Answer()
    {
        isAnswer = true;
        int timeScore = 0;
        if(isCorrect)
        {
            timeScore = (int)(maxScore * (timeValue / maxTime));

            Debug.Log(timeValue);
            mcq.correct("Correct Answer");
        }
        else
        {
            timeScore = 0;
            Debug.Log("Wrong Answer");
            mcq.correct("Wrong Answer");
        }
        ButtonAnimation();
        StartCoroutine(GameControl.EndMCQ(timeScore));
    }

    public void ButtonAnimation()
    {
        GameObject.Find("A_button").GetComponent<Animator>().Play("AButtonLeft");
        GameObject.Find("B_button").GetComponent<Animator>().Play("BButtonRight");
        GameObject.Find("C_button").GetComponent<Animator>().Play("CButtonLeft");
        GameObject.Find("D_button").GetComponent<Animator>().Play("DButtonRight");
        GameObject.Find("TimerPanel").GetComponent<Animator>().Play("TimerPanelCorner");
        GameObject.Find("MessagePanel").GetComponent<Animator>().Play("MessagePanelEnlarge");
    }
}
