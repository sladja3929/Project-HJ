using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cockroach_AI : MonoBehaviour {

    public float radiusTime;
    public float MoveSpeed;
    private Cockroach_Head HeadScript;
    private Animator anim;
    private int Movement;
    private SpriteRenderer Sp;

    private void Start() {
        HeadScript = GetComponentInChildren<Cockroach_Head>();
        anim = GetComponent<Animator>();
        StartCoroutine("AICycle");
        Sp = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        Death();
    }

    private void FixedUpdate() {
        Move();
    }

    private void Move() {
        if(Movement == 0) {
            return;
        }
        else if(Movement == 1) {
            transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
            Sp.flipX = true;
        }
        else if(Movement == 2) {
            transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
            Sp.flipX = false;
        }
    }

    IEnumerator AICycle() {
        Movement = 1;
        anim.SetBool("isMoving", true);
        yield return new WaitForSeconds(radiusTime);
        Movement = 0;
        anim.SetBool("isMoving", false);
        yield return new WaitForSeconds(1f);
        Movement = 2;
        anim.SetBool("isMoving", true);
        yield return new WaitForSeconds(radiusTime*2);
        Movement = 0;
        anim.SetBool("isMoving", false);
        yield return new WaitForSeconds(1f);
        Movement = 1;
        anim.SetBool("isMoving", true);
        yield return new WaitForSeconds(radiusTime);
        StartCoroutine("AICycle");
    }

    private void Death() {
        if(!HeadScript.isDead) {
            return;
        }
        Destroy(gameObject);
    }
}
