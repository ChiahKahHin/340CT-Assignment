using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector3 offset { get; set; }

    public string playerLabel;

    public Transform[] waypoints;

    private float moveSpeed = 8f;

    public GameObject scoreLabel;

    public int scores = 0;

    [HideInInspector]
    public int waypointIndex { get; set; }
    public int moveToIndex = -1;

    public int startWayPoint { get; set; }

    public bool moveAllowed = false;
    public bool shortCut = false;

    // Start is called before the first frame update
    void Start()
    {
        scores = 0;
        offset = transform.position - waypoints[0].transform.position;
        offset = new Vector3(offset.x, offset.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAllowed)
            move();
        if (shortCut)
            moveTo(moveToIndex);
    }

    public void init(int number, GameObject label)
	{
        playerLabel = "Player " + number;
        scoreLabel = label;
        scoreLabel.GetComponent<Text>().text = "Score: 0";
    }

	private void move()
	{
	    if (waypointIndex < waypoints.Length)
		{
            transform.position = Vector2.MoveTowards(
                transform.position, 
                waypoints[waypointIndex].transform.position + offset,
                moveSpeed * Time.deltaTime
            );

            if (transform.position == waypoints[waypointIndex].transform.position + offset)
			{
                waypointIndex += 1;
			}
		}
	}

	private void moveTo(int index)
	{
	    if (waypointIndex < waypoints.Length)
		{
            transform.position = Vector2.MoveTowards(
                transform.position, 
                waypoints[index].transform.position + offset,
                moveSpeed * Time.deltaTime
            );

            if (transform.position == waypoints[index].transform.position + offset)
			{
                moveToIndex = -1;
                shortCut = false;
                startWayPoint = index;
                waypointIndex = startWayPoint + 1;
                StartCoroutine(GameControl.StartMCQ());
            }
		}
	}

    public void addScore(int scores)
	{
        StartCoroutine(scoreCountUp(scores));
	}

    private IEnumerator scoreCountUp(int scores)
	{
        yield return new WaitForSeconds(1f);
        while (scores > 0)
		{
            int rand = Random.Range(10, 19);
            int temp = Mathf.Min(rand, scores);
            this.scores += temp;
            scores -= temp;
            scoreLabel.GetComponent<Text>().text = "Score: " + this.scores;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        GameControl.nextPlayer();
	}
}
