using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee_Trace : MonoBehaviour {

    public bool B_isTracing = false;
    public Vector2 Dir;

    private void Start() {
        B_isTracing = false;
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player") {
            B_isTracing = true;
            Dir = other.transform.position - transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            B_isTracing = false;
        }
    }
}
