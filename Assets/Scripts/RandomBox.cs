using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBox : MonoBehaviour {

    public GameObject Item;
    private Vector2 Spawn;
    private bool isUsing = false;

    private void Start() {
        Spawn = new Vector2(transform.position.x, transform.position.y+0.7f);
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Player" && !isUsing) {
            Instantiate(Item, Spawn, transform.rotation);
            isUsing = true;
        }
    }
}
