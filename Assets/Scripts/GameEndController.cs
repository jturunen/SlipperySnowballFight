using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndController : MonoBehaviour {

    public GameObject[] playersLeft;

    public Canvas canvasGameEnd;

	// Update is called once per frame
	void Update () {
        
        playersLeft = GameObject.FindGameObjectsWithTag("Player");

		if (playersLeft.Length == 1)
        {
            string playerName = playersLeft[0].name;

            Debug.Log(playerName + " won!");

            GameEnded(playerName);
        }
	}

    public void GameEnded(string playerName)
    {
        canvasGameEnd.enabled = true;
    }

    public void RestartGame()
    {
        Debug.Log("Game restarted");
        canvasGameEnd.enabled = false;
    }

    public void ReturnToMainMenu()
    {
        Debug.Log("Return to main menu");
    }
}
