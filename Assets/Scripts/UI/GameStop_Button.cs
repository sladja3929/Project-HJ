using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStop_Button : MonoBehaviour {

    public static bool GameStopped = false;
    public GameObject GameStopUI;

    public void GameRetry() {
        SceneManager.LoadScene("Scene_Ingame", LoadSceneMode.Single);
    }

    public void GameExit() {
        Application.Quit();
    }

    public void GameReturn() {
        Time.timeScale = 1f;
        GameStopped = false;
        GameStopUI.SetActive(false);
    }

    public void GameStop() {
        GameStopped = true;
    }
}