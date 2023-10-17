using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee_AI : MonoBehaviour {

    public float MoveSpeed;
    private Animator anim;
    private Bee_Trace B_TraceScript;
    private Data data;
    private Data P_data;
    private SpriteRenderer Sp;
    private Transform P_pos;
    private bool Visible = false;
    private AudioSource Aud;

    void Start() {
        anim = GetComponent<Animator>();
        B_TraceScript = GetComponentInChildren<Bee_Trace>();
        P_data = GameObject.FindWithTag("Player").GetComponent<Data>();
        data = GetComponent<Data>();
        Sp = GetComponent<SpriteRenderer>();
        P_pos = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Aud = GetComponent<AudioSource>();
    }

    private void Update() {
        Death();
        if (P_pos.position.x < transform.position.x) {
            Sp.flipX = false;
        }
        else {
            Sp.flipX = true;
        }
    }

    private void Death() {
        if (data.HP <= 0) {
            Destroy(gameObject);
        }
    }

    void FixedUpdate() {
        Move();
        if (Visible && !B_TraceScript.B_isTracing) {
            transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
        }
    }

    private void Move() {
        if (!B_TraceScript.B_isTracing) {
            return;
        }
        anim.SetBool("isMoving", true);
        transform.Translate(B_TraceScript.Dir.normalized * MoveSpeed * Time.deltaTime);
    }

    private void OnBecameVisible() {
        Visible = true;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            Aud.Play();
            Destroy(gameObject);
        }
        else if (col.tag == "Player_Bullet") {
            data.HP -= P_data.AD_1;
            StartCoroutine("HitBlink");
        }
    }

    private IEnumerator HitBlink() {
        Sp.color = new Color32(255, 255, 255, 90);
        yield return new WaitForSeconds(0.2f);
        Sp.color = new Color32(255, 255, 255, 255);
        yield return null;
    }
}
