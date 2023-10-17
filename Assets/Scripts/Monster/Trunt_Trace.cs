using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trunt_Trace : MonoBehaviour {

	public bool T_isTracing = false;
    public Vector2 Dir;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            T_isTracing = true;
            if (other.gameObject.transform.position.x < transform.position.x) {
                Dir = Vector2.left;
            }
            else {
                Dir = Vector2.right;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            T_isTracing = false;
        }
    }
}
