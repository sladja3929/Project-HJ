using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trunt_AI : MonoBehaviour {

    public float MoveSpeed;
    private Animator anim;
    private Trunt_Trace T_TraceScript;
    private bool isMoving = false;

	void Start () {
        anim = GetComponent<Animator>();
        T_TraceScript = GetComponentInChildren<Trunt_Trace>();
	}
	
	void Update () {
        TraceAI();
	}

    void FixedUpdate() {
        Move();
    }
    
    private void TraceAI() {
        if (T_TraceScript.T_isTracing) {
            anim.SetBool("isTracing", true);
            StartCoroutine("MoveAI");
        }
        else {
            anim.SetBool("isTracing", false);
            anim.SetBool("isMoving", false);
            isMoving = false;
            StartCoroutine("Delay");
        }
    }

    IEnumerator MoveAI() {
        yield return new WaitForSeconds(0.4f);
        if(T_TraceScript.T_isTracing) {
            isMoving = true;
        }
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(0.5f);
    }

    private void Move() {
        if(!isMoving) {
            return;
        }
        anim.SetBool("isMoving", true);
        transform.Translate(T_TraceScript.Dir * MoveSpeed * Time.deltaTime);
    }

}
