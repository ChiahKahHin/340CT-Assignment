using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    private ArrayList players;
    private int waypointIndex = 0;
    private Transform highscoreContainer;
    private Transform highscoreTemplate;
    private List<scoreBoard> scoreList;
    private List<Transform> transformList;

    // Start is called before the first frame update
    void Start()
    {
        highscoreContainer = transform.Find("HighscoreContainer");
        highscoreTemplate = highscoreContainer.Find("HighscoreTemplate");
        highscoreTemplate.gameObject.SetActive(false);

        scoreList = new List<scoreBoard>();
        foreach (GameObject player in GameControl.players)
        {
            Player playerComponent = player.GetComponent<Player>();
            waypointIndex = playerComponent.waypointIndex - 1;
            scoreList.Add(new scoreBoard { player = playerComponent.playerLabel, score = playerComponent.scores + waypointIndex * 100});
        }

        for (int i = 0; i < scoreList.Count; i++)
        {
            for (int j = i + 1; j < scoreList.Count; j++)
            {
                if (scoreList[j].score > scoreList[i].score)
                {
                    scoreBoard temp = scoreList[i];
                    scoreList[i] = scoreList[j];
                    scoreList[j] = temp;
                }
            }
        }

        transformList = new List<Transform>();
        foreach (scoreBoard score in scoreList)
        {
            displayRank(score, highscoreContainer, transformList);
        }

    }

    private void displayRank(scoreBoard scoreBoard, Transform container, List<Transform> transformList)
    {
        float templateHeight = 80f;

        Transform transform = Instantiate(highscoreTemplate, container);
        RectTransform rectTransform = transform.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        transform.gameObject.SetActive(true);

        int ranking = transformList.Count + 1;
        string rankingString;
        switch (ranking)
        {
            case 1: 
                rankingString = "1st"; 
                break;
            case 2: 
                rankingString = "2nd";
                break;
            case 3: 
                rankingString = "3rd";
                break;
            default: 
                rankingString = ranking + "th";
                break;
        }

        

        transform.Find("rankNumber").GetComponent<Text>().text = rankingString;

        string name = scoreBoard.player;
        transform.Find("player").GetComponent<Text>().text = name;

        int score = scoreBoard.score;
        transform.Find("score").GetComponent<Text>().text = score.ToString();

        switch (ranking)
        {
            case 1:
                transform.Find("rankNumber").GetComponent<Text>().color = Color.yellow;
                transform.Find("player").GetComponent<Text>().color = Color.yellow;
                transform.Find("score").GetComponent<Text>().color = Color.yellow;
                break;

            case 2:
                
                transform.Find("rankNumber").GetComponent<Text>().color = Color.gray;
                transform.Find("player").GetComponent<Text>().color = Color.gray;
                transform.Find("score").GetComponent<Text>().color = Color.gray;
                break;

            case 3:
                
                transform.Find("rankNumber").GetComponent<Text>().color = Color.red;
                transform.Find("player").GetComponent<Text>().color = Color.red;
                transform.Find("score").GetComponent<Text>().color = Color.red;
                break;

            default:
                transform.Find("rankNumber").GetComponent<Text>().color = Color.white;
                transform.Find("player").GetComponent<Text>().color = Color.white;
                transform.Find("score").GetComponent<Text>().color = Color.white;
                break;
        }






        transformList.Add(transform);
    }

    private class scoreBoard
    {
        public string player;
        public int score; 
    }

}
