using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 offset { get; set; }

    public string playerLabel;

    public Transform[] waypoints;

    private float moveSpeed = 5f;

    [HideInInspector]
    public int waypointIndex { get; set; }
    public int moveToIndex = -1;

    public int startWayPoint { get; set; }

    public bool moveAllowed = false;
    public bool shortCut = false;

    // Start is called before the first frame update
    void Start()
    {
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

    public void init(int number)
	{
        playerLabel = "Player " + number;
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
                waypointIndex = index;
                Dice.coroutineAllowed = true;
			}
		}
	}
}
