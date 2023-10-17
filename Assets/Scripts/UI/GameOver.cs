using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        Player_Health.Dead = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(Player_Health.Dead) {
            CameraFollow.Camera_isTracking = true;
            Time.timeScale = 0;
            StartCoroutine("Delay");
            SceneManager.LoadScene("Scene_Ingame", LoadSceneMode.Single);
        }
        if(Boss_Health.Boss_D) {
            Application.Quit();
        }
	}

    IEnumerator Delay() {
        yield return new WaitForSeconds(5f);
    }
}
