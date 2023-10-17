using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower_AI : MonoBehaviour {

    private Animator anim;
    private Data data;
    private Data P_data;
    private SpriteRenderer Sp;
    private Transform P_pos;

    private void Start() {
        anim = GetComponent<Animator>();
        P_data = GameObject.FindWithTag("Player").GetComponent<Data>();
        P_pos = GameObject.FindWithTag("Player").GetComponent<Transform>();
        data = GetComponent<Data>();
        Sp = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        Death();
        if(P_pos.position.x < transform.position.x) {
            Sp.flipX = false;
        }
        else {
            Sp.flipX = true;
        }
    }

    private void Death() {
        if(data.HP<=0) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Player") {
            anim.SetBool("isAttacking",true);
        }
        else if(col.tag == "Player_Bullet") {
            data.HP -= P_data.AD_1;
            StartCoroutine("HitBlink");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            anim.SetBool("isAttacking", false);
        }
    }

    private IEnumerator HitBlink() {
        Sp.color = new Color32(255, 255, 255, 90);
        yield return new WaitForSeconds(0.2f);
        Sp.color = new Color32(255, 255, 255, 255);
        yield return null;
    }
}
