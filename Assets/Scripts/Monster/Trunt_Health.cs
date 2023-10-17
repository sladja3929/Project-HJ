using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trunt_Health : MonoBehaviour {

    private Data data;
    private Data P_data;
    private Trunt_Trace TraceScript;
    private SpriteRenderer Sp;

	void Start () {
        data = GetComponent<Data>();
        GameObject Player = GameObject.FindWithTag("Player");
        P_data = Player.GetComponent<Data>();
        TraceScript = GetComponentInChildren<Trunt_Trace>();
        Sp = GetComponent<SpriteRenderer>();
	}

    private void Update() {
        Death();
    }

    private void Death() {
        if(data.HP <= 0) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D (Collider2D col) {
		if(col.tag == "Player_Bullet" && TraceScript.T_isTracing) {
            data.HP -= P_data.AD_1;
            StartCoroutine("HitBlink");
        }
	}

    private IEnumerator HitBlink() {
        Sp.color = new Color32(255, 255, 255, 90);
        yield return new WaitForSeconds(0.2f);
        Sp.color = new Color32(255, 255, 255, 255);
        yield return null;
    }
}
