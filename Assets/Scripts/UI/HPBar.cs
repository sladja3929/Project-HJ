using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {

    Data P_data;
    private Image HPbar;
    public float MaxHP;

	void Start () {
        HPbar = gameObject.GetComponent<Image>();
        P_data = GameObject.FindWithTag("Player").GetComponent<Data>();
    }
	
	void Update () {
        HPbar.fillAmount = P_data.HP / MaxHP;
	}
}
