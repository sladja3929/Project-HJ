using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_Anim : MonoBehaviour {

    Animator anim;

	void Start () {
        anim = GetComponentInParent<Animator>();
	}

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Player") {
            anim.SetBool("isClosing", true);
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.tag == "Player") {
            anim.SetBool("isClosing", false);
        }
    }
}
