using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static ArrayList players;
    public static bool gameOver = false;
    public static int numberOfPlayers = 3;
    public static int diceSideThrown = 0;
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
        for (i = 0; i < numberOfPlayers; i++)
		{
            int playerID = i + 1;
            GameObject obj = GameObject.Find("Player" + playerID);
            obj.gameObject.SetActive(true);
            obj.GetComponent<Player>().moveAllowed = false;
            obj.GetComponent<Player>().init(playerID);
            obj.GetComponent<Renderer>().enabled = true;
            players.Add(obj);
		}
        for (; i < 4; i++)
        {
            int temp = i + 1;
            GameObject obj = GameObject.Find("Player" + temp);
            obj.GetComponent<Renderer>().enabled = false;
            obj.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject player in players)
		{
            Player playerComponent = player.GetComponent<Player>();
            if (playerComponent.waypointIndex > playerComponent.startWayPoint + diceSideThrown)
			{
                playerComponent.moveAllowed = false;
                playerComponent.startWayPoint = playerComponent.waypointIndex - 1;
                if (shortCut.ContainsKey(playerComponent.startWayPoint))
				{
                    StartCoroutine("WaitFor", playerComponent);
				}
                else
				{
                    Dice.coroutineAllowed = true;
				}
			}

            if (playerComponent.waypointIndex == playerComponent.waypoints.Length)
			{
                gameOver = true;
                break;
			}
		}
    }

    public IEnumerator WaitFor(Player playerComponent)
	{
        yield return new WaitForSeconds(0.3f);
        playerComponent.shortCut = true;
        playerComponent.moveToIndex = shortCut[playerComponent.startWayPoint];
    }

    public static void MovePlayer(int playerID)
	{
        (players[playerID] as GameObject).GetComponent<Player>().moveAllowed = true;
	}
}
