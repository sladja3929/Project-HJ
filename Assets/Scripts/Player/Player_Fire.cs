using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Fire : MonoBehaviour {

    public GameObject Missile;
    public float FireDelay=0.5f;
    private bool FireState;

    void Start() {
        FireState = true;
    }

    void Update() {
        Fire();
    }

    private void Fire() {
        if (FireState) {
            if(Input.GetKeyDown(KeyCode.X)) {

                StartCoroutine(DelayControl());
                Instantiate(Missile, transform.position, transform.rotation);
            }
        }
    }

    private IEnumerator DelayControl() {
        FireState = false;
        yield return new WaitForSeconds(FireDelay);
        FireState = true;
    }
}
