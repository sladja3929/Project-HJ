using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

    private GameObject Closed;
    public GameObject Opened;

    private void Start() {
        Closed = GameObject.FindWithTag("Door");
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Player") {
            Instantiate(Opened, Closed.transform.position, Closed.transform.rotation);
            Destroy(Closed);
            Destroy(gameObject);
        }
    }
}
