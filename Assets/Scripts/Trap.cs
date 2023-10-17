using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    private Animator anim;
    private BoxCollider2D[] Box;

    private void Start() {
        anim = GetComponent<Animator>();
        Box = GetComponents<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            anim.SetTrigger("doClose");
            Box[0].enabled = false;
            Box[1].enabled = false;
        }
    }
}
