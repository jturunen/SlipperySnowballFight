using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame2()
    {
        PlayerPrefs.SetInt("PlayerAmount", 2);

        ChangeScene();
    }

    public void PlayGame3()
    {
        PlayerPrefs.SetInt("PlayerAmount", 3);

        ChangeScene();
    }

    public void PlayGame4()
    {
        PlayerPrefs.SetInt("PlayerAmount", 4);

        ChangeScene();
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
