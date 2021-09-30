using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float offsetX { get; set; }
    public float offsetY { get; set; }
    public GameObject playerObject { get; set; }

    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 1f;

    [HideInInspector]
    public int waypointIndex { get; set; }

    public bool moveAllowed = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAllowed)
            move();
    }

    public void init(int playerID)
	{
        waypointIndex = 0;
        switch (playerID)
        {
            case 1:
                offsetX = 1f;
                offsetY = 1f;
                break;
            case 2:
                offsetX = -1f;
                offsetY = 1f;
                break;
            case 3:
                offsetX = 1f;
                offsetY = -1f;
                break;
            default:
                offsetX = -1f;
                offsetY = -1f;
                break;
        }
    }

	private void move()
	{
	    if (waypointIndex < waypoints.Length)
		{
            transform.position = Vector2.MoveTowards(
                transform.position, 
                waypoints[waypointIndex].transform.position, 
                moveSpeed * Time.deltaTime
            );

            if (transform.position == waypoints[waypointIndex].transform.position)
			{
                waypointIndex += 1;
			}
		}
	}
}
