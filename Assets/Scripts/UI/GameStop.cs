using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStop : MonoBehaviour {

    public GameObject GameStopUI;

    private void Awake() {
        GameStop_Button.GameStopped = false;
        Time.timeScale = 1f;
        GameStopUI.SetActive(false);
    }
    void Update() {
        if (GameStop_Button.GameStopped) {
            GameStopUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
}