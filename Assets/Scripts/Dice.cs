using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    public static bool coroutineAllowed = true;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("diceSides/");
        rend.sprite = diceSides[5];
    }
	private void OnMouseDown()
	{
		if (!GameControl.gameOver && coroutineAllowed)
		{
            StartCoroutine("RollDice");
		}
	}

    private IEnumerator RollDice()
	{
        coroutineAllowed = false;
        int randomDiceNumber = 0;
        for (int i = 0; i < 20; i++)
		{
            randomDiceNumber = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceNumber];
            yield return new WaitForSeconds(0.05f);
		}
        GameControl.diceSideThrown = randomDiceNumber + 1;
        GameControl.MovePlayer();
	}
}
