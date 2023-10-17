using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet_Move : MonoBehaviour {

    public static bool P_Trace = false;
    public float MoveSpeed = 8f;

    Vector2 Dir;
    private GameObject Player;

    void Start () {
        Player = GameObject.FindWithTag("Player");
        Dir = (Player.transform.position - transform.position);
    }
	
	// Update is called once per frame
	void Update () {
        if(!P_Trace) {
            transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
        }
        else {
            Trace();
        }
    }

    private void Trace() {
        transform.Translate(Dir.normalized * MoveSpeed * Time.deltaTime);
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player" || col.tag == "Ground") {
            Destroy(gameObject);
        }
    }
}
