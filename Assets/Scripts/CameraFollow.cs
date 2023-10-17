using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public static bool Camera_isTracking = true;
    private GameObject Player;
    public float MoveSpeed;
    public float LeftGap;

    private void Start() {
        Player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate() {
        if(Player.transform.position.x >= -1.7f && Camera_isTracking) {
            float targetX = Mathf.Lerp(transform.position.x, Player.transform.position.x, MoveSpeed * Time.deltaTime);
            transform.position = new Vector3(targetX + LeftGap, transform.position.y, transform.position.z);
        }
       
    }

}