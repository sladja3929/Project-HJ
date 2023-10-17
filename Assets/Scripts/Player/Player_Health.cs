using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour {

    public static bool Dead = false;
    public static bool isDamaged = false;
    public AudioSource Heated;
    public AudioSource Poisoned;

    private AudioSource Aud;
    private Rigidbody2D Rb;
    private SpriteRenderer Sp;
    private Data P_data;
    private Vector2 D_Velocity = Vector2.zero;
    private Player_Ctrl ControlScript;

    void Start () {
        Sp = GetComponent <SpriteRenderer> ();
        Rb = GetComponent<Rigidbody2D>();
        P_data = GetComponent<Data>();
        ControlScript = GetComponent<Player_Ctrl>();
	}
	
	// Update is called once per frame
	void Update () {
		if(P_data.HP<=0) {
            Death();
        }
	}

    private void Death() {
        Dead = true;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Enemy" && !isDamaged) {
            Damaged(col);
        }
        else if(col.tag == "Mushroom") {
            P_data.HP -= 20;
            Poisoned.Play();
            StartCoroutine("Poison");
        }
        else if(col.tag == "Trap" && !isDamaged) {
            Aud = col.GetComponent<AudioSource>();
            Aud.Play();
            Damaged(col);
        }
        else if (col.tag == "B_Bullet" && !isDamaged) {
            Damaged(col);
        }
        else if (col.tag == "Beam" && !isDamaged) {
            isDamaged = true;
            Data E_data = col.GetComponent<Data>();
            P_data.HP -= E_data.AD_2;

            if (col.gameObject.transform.position.x < transform.position.x) {
                D_Velocity = new Vector2(5f, 7f);
            }
            else {
                D_Velocity = new Vector2(-5f, 7f);
            }

            StartCoroutine("HitBlink");
            isDamaged = false;
        }
    }

    private void Damaged(Collider2D Enemy) {
        isDamaged = true;
        Data E_data = Enemy.GetComponent<Data>();
        P_data.HP -= E_data.AD_1;

        if(Enemy.gameObject.transform.position.x < transform.position.x) {
            D_Velocity = new Vector2(5f, 7f);
        }
        else {
            D_Velocity = new Vector2(-5f, 7f);
        }
        
        StartCoroutine("HitBlink");
        isDamaged = false;
    }

    private IEnumerator HitBlink() {

        ControlScript.enabled = false;
        Rb.velocity = new Vector2(0, 0);
        Rb.AddForce(D_Velocity, ForceMode2D.Impulse);
        Sp.color = new Color32(255, 255, 255, 90);
        yield return new WaitForSeconds(0.5f);
        Sp.color = new Color32(255, 255, 255, 255);
        yield return null;
        ControlScript.enabled = true;

    }

    private IEnumerator Poison() {
        Sp.color = new Color32(160, 32, 240, 255);
        yield return new WaitForSeconds(2f);
        Sp.color = new Color32(255, 255, 255, 255);
        yield return null;

    }
}
