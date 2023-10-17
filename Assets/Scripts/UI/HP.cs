using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour {

    Text text;
    Data P_data;

    void Start () {
        text = GetComponent<Text>();
        P_data = GameObject.FindWithTag("Player").GetComponent<Data>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = P_data.HP.ToString();
	}
}
