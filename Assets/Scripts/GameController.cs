using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] playersLeft;
    public GameObject[] playersInGame;
    public GameObject canvasGameEnd;
    public GameObject canvasGame;

    public Text textPlayerWon;

    public bool gameOver;

    // Game begins
    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (PlayerPrefs.GetInt("PlayerAmount") == 2)
        {
            GameObject.Find("Player 3").SetActive(false);
            GameObject.Find("Player 4").SetActive(false);
        }
        else if (PlayerPrefs.GetInt("PlayerAmount") == 3)
        {
            GameObject.Find("Player 4").SetActive(false);
        }

        Debug.Log("Level Loaded with " + PlayerPrefs.GetInt("PlayerAmount") + " players");
        Debug.Log(scene.name);
        Debug.Log(mode);
    }


    void OnStart()
    {
        gameOver = false;
    }

    // During gameplay
    // Update is called once per frame
    void Update()
    {

        playersLeft = GameObject.FindGameObjectsWithTag("Player");

        if (!gameOver)
        {
            if (playersLeft.Length == 1)
            {
                string playerName = playersLeft[0].name;

                Debug.Log(playerName + " won!");

                GameEnded(playerName);
            }
        }
    }


    // Game end
    public void GameEnded(string playerName)
    {
        GameObject[] playerControls = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject player in playerControls)
        {
            player.SetActive(false);
        }

        gameOver = true;
        canvasGameEnd.SetActive(true);
        canvasGame.SetActive(false);
        textPlayerWon.text = playerName + " WINS!";
    }


    // Button functionalities
    public void RestartGame()
    {
        Debug.Log("Game restarted");
        canvasGameEnd.SetActive(false);
        canvasGame.SetActive(true);
        gameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        Debug.Log("Return to main menu");
        gameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
