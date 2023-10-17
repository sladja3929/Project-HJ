using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    public void GameStart() {
        SceneManager.LoadScene("Scene_Ingame", LoadSceneMode.Single);
    }

    public void GameQuit() {
        Application.Quit();
    }
}
