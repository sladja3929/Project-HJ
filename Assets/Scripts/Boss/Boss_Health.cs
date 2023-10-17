using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour {

    public static bool Boss_D = false;
    private Data data;
    private Data P_data;
    private SpriteRenderer Sp;

    void Start() {
        data = GetComponent<Data>();
        GameObject Player = GameObject.FindWithTag("Player");
        P_data = Player.GetComponent<Data>();
        Sp = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        Death();
    }

    private void Death() {
        if (data.HP <= 0) {
            Destroy(gameObject);
            Boss_D = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player_Bullet") {
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
