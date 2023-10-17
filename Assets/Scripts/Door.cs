using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private GameObject B;

    private GameObject Camera;
    private SpriteRenderer Sp;
    private GameObject Boss;

    private void Start() {
        Camera = GameObject.FindWithTag("MainCamera");
        Boss = GameObject.FindWithTag("BossFace");
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Player") {
            CameraFollow.Camera_isTracking = false;
            col.transform.position = new Vector3(0, -14, 0);
            Sp = GameObject.FindWithTag("BossGlass").GetComponent<SpriteRenderer>();
            StartCoroutine("FadeIN");
            Invoke("BossRoom", 3f);
            
        }
    }

    private void BossRoom() {
        Boss.SetActive(false);
        Camera.transform.position = new Vector3(0, -14, -10);
        B = GameObject.FindWithTag("Boss");
        Boss_AI BA = B.GetComponent<Boss_AI>();
        BA.enabled = true;
    }

    IEnumerator FadeIN() {
        float time = 0f;
        Vector3 V = new Vector3(Boss.transform.position.x, 1, Boss.transform.position.z);
        while(Boss.transform.position.y > 1) {
            time += Time.deltaTime * 0.5f;
            Boss.transform.position = Vector3.Lerp(Boss.transform.position, V, time);
            yield return 1.5f;
        }

        time = 0f;
        Color C = Sp.color;
        while (C.a < 1f) {
            time += Time.deltaTime / 2f;
            C.a = Mathf.Lerp(0f, 1f, time);
            Sp.color = C;    
            yield return null;
        }
    }
}
