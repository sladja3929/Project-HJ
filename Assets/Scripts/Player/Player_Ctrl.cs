using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ctrl : MonoBehaviour {

    public bool isJumping = false;
    bool PressJ = false;
    public float Speed = 5f;
    public float jumpPower = 1f;
    public static bool isLeft = false;
    private float axis=0;

    Animator anim;
    Rigidbody2D rigid;
    SpriteRenderer rend;

    private void Awake() {
        rigid = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
    }

    void Update() {
        axis = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            PressJ = true;
            anim.SetTrigger("doJump");
            anim.SetBool("isJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            anim.SetBool("isSitting", true);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow)) {
            anim.SetBool("isSitting", false);
        }

        if (Input.GetKeyDown(KeyCode.X)) {
            anim.SetTrigger("doAttack");
        }
    }


    private void FixedUpdate() {
        Move();
        Jump();
    }

    private void Move() {
        if(axis < 0) {
            isLeft = true;
            anim.SetBool("isMoving", true);
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
            transform.localScale = new Vector3(-2, 1.5f, 1);
        }
        else if(axis > 0) {
            isLeft = false;
            anim.SetBool("isMoving", true);
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
            transform.localScale = new Vector3(2, 1.5f, 1);
        }
        else {
            anim.SetBool("isMoving", false);
        }
    }

    private void Jump() {
        if(isJumping || !PressJ) {
            return;
        }
        isJumping = true;
        Vector2 jumpVelocity = new Vector2(0, jumpPower);
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
        PressJ = false;
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Ground" || other.tag == "Head") {
            isJumping = false;
            anim.SetBool("isJumping", false);
        }
    }
}
