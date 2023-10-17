using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Move : MonoBehaviour {

    public float MoveSpeed = 10f;
    private bool Left;

    private void Start() {
        if(Player_Ctrl.isLeft) {
            Left = true;
        }
        else {
            Left = false;
        }
    }

    void Update () {
        BulletMove();
	}

    private void BulletMove() {
        if(Left) {
            transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
        }
        else
        transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy" || other.tag == "Ground" || other.tag == "shield") {
            Destroy(gameObject);
        }
    }
}
