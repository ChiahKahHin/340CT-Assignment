using UnityEngine;

public class Player
{
    public float offsetX { get; set; }
    public float offsetY { get; set; }
    public float step { get; set; }
    private GameObject playerObject { get; set; }

    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 1f;

    [HideInInspector]
    public int waypointIndex = 0;

    public bool moveAllowed = false;
    
    public Player(int player)
	{
        step = 0;
        switch (player)
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

    public void configure(int playerID)
	{

	}
}
