using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cockroach_Head : MonoBehaviour {

    public bool isDead = false;
 
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Player") {
            isDead = true;
        }
    }
}
