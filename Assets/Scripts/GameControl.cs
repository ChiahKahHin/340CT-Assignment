using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static ArrayList players;
    public static ArrayList playersTurn;
    public static bool gameOver = false;
    public static int numberOfPlayers = 4;
    public static int diceSideThrown = 0;

    public static int whoseTurn = 0;

    private static Dictionary<int, int> shortCut = new Dictionary<int, int>()
    {
        [8] = 29,
        [22] = 61,
        [23] = 17,
        [45] = 5,
        [52] = 33,
        [54] = 68,
        [65] = 97,
        [67] = 28,
        [72] = 93,
        [90] = 50,
        [99] = 24,
    };
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        players = new ArrayList();
        playersTurn = new ArrayList();
        for (i = 0; i < numberOfPlayers; i++)
		{
            int playerID = i + 1;
            GameObject obj = GameObject.Find("Player" + playerID);
            GameObject scoreLabel = GameObject.Find("Player" + playerID + "Score");
            GameObject turnLabel = GameObject.Find("Player" + playerID + "Turn");
            obj.gameObject.SetActive(true);
            scoreLabel.gameObject.SetActive(true);
            obj.GetComponent<Player>().moveAllowed = false;
            obj.GetComponent<Player>().init(playerID, scoreLabel);
            players.Add(obj);
            playersTurn.Add(turnLabel);
        }
        for (; i < 4; i++)
        {
            int temp = i + 1;
            GameObject obj = GameObject.Find("Player" + temp);
            GameObject scoreLabel = GameObject.Find("Player" + temp + "Score");
            GameObject icon = GameObject.Find("Player" + temp + "Icon");
            GameObject labelTurn = GameObject.Find("Player" + temp + "Turn");
            scoreLabel.gameObject.SetActive(false);
            icon.gameObject.SetActive(false);
            obj.gameObject.SetActive(false);
            labelTurn.gameObject.SetActive(false);
        }
        nextPlayer();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
            return;
        foreach (GameObject player in players)
		{
            Player playerComponent = player.GetComponent<Player>();
            //playerComponent.scores;
            if (playerComponent.waypointIndex == playerComponent.waypoints.Length)
            {
                gameOver = true;
                Debug.Log("Game Over");
                StartCoroutine(GameOver());
                break;
            }
            if (playerComponent.waypointIndex > playerComponent.startWayPoint + diceSideThrown)
			{
                playerComponent.moveAllowed = false;
                playerComponent.startWayPoint = playerComponent.waypointIndex - 1;
                if (shortCut.ContainsKey(playerComponent.startWayPoint))
				{
                    StartCoroutine(MoveShortCut(playerComponent));
				}
                else
                {
                    StartCoroutine(StartMCQ());
                }

			}
		}
    }

    public static void nextPlayer()
	{
        for (int i = 0; i < players.Count; i++)
        {
            (playersTurn[i] as GameObject).gameObject.SetActive(whoseTurn == i ? true : false); 
        }
        Dice.coroutineAllowed = true;
    }

    public IEnumerator MoveShortCut(Player playerComponent)
	{
        yield return new WaitForSeconds(0.3f);
        playerComponent.shortCut = true;
        playerComponent.moveToIndex = shortCut[playerComponent.startWayPoint];
    }

    public static IEnumerator StartMCQ()
	{
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MCQScene", LoadSceneMode.Additive);
	}

    private IEnumerator GameOver()
	{
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Leaderboard", LoadSceneMode.Additive);
        // code here
    }
    
    public static IEnumerator EndMCQ(int obtainedScore)
	{
        yield return new WaitForSeconds(2f);
        SceneManager.UnloadScene("MCQScene");
        (players[whoseTurn] as GameObject).GetComponent<Player>().addScore(obtainedScore);
        whoseTurn = (whoseTurn + 1) % players.Count;
    }

    public static void MovePlayer()
	{
        (players[whoseTurn] as GameObject).GetComponent<Player>().moveAllowed = true;
    }

}
