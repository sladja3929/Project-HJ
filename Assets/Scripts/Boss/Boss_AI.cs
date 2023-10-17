using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_AI : MonoBehaviour {

    public GameObject Bullet;
    public float MoveSpeed;
    public GameObject B;
    public GameObject S;

    private Animator anim;
    private int rand;
    private bool isPattern = false;
    private float MoveMent = 0;

	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Pattern();
	}

    private void FixedUpdate() {
        Move();
    }

    private void Pattern() {
        if(isPattern) {
            return;
        }
        rand = Random.Range(1, 4);
        if (rand == 1) {
            StartCoroutine("UpDown");
            StartCoroutine("Shoot");
        }
        else if (rand == 2) StartCoroutine("Trace");
        else if (rand == 3) StartCoroutine("Beam");
    }

    private void Move() {
        if (MoveMent == 0) return;
        if (MoveMent == 2) transform.Translate(Vector3.up * MoveSpeed * Time.deltaTime);
        if (MoveMent == 1) transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime);


    }
    private IEnumerator Shoot() {
        anim.SetBool("isPattern", true);

        for (int i = 0; i < 6; i++) {
            anim.SetTrigger("isBlow");
            Instantiate(Bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(1f);
        }

        anim.SetBool("isPattern", false);
        yield return new WaitForSeconds(2f);
    }

    private IEnumerator UpDown() {
        isPattern = true;

        MoveMent = 1;
        yield return new WaitForSeconds(3.5f);
        MoveMent = 2;
        yield return new WaitForSeconds(3.5f);
        MoveMent = 0;

        isPattern = false;
    }

    private IEnumerator Trace() {
        isPattern = true;
        anim.SetBool("isPattern", true);
        BossBullet_Move.P_Trace = true;

        for (int i = 0; i < 6; i++) {
            anim.SetTrigger("isBlow");
            Instantiate(Bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(1.3f);
        }

        BossBullet_Move.P_Trace = false;
        anim.SetBool("isPattern", false);
        isPattern = false;
        yield return new WaitForSeconds(2f);
    }

    private IEnumerator Beam() {
        isPattern = true;
        anim.SetBool("isPattern", true);

        S.SetActive(true);
        anim.SetBool("isTeeth", true);
        yield return new WaitForSeconds(3f);
        S.SetActive(false);
        B.SetActive(true);
        yield return new WaitForSeconds(1f);
        B.SetActive(false);
        anim.SetBool("isTeeth", false);
        

        anim.SetBool("isPattern", false);
        anim.SetTrigger("stand");
        isPattern = false;
        yield return new WaitForSeconds(2f);

    }
}
