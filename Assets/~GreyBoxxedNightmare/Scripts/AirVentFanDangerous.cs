using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AirVentFanDangerous : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter (Collider Col)
    {
        if(Col.gameObject.tag == "Player")
        {
            Col.gameObject.GetComponent<PlayerMovement>().PlayerHealth = 0;
            GameObject.Find("Airvent_Back_Screen").GetComponent<Image>().enabled = true;
            GameObject.Find("Airvent_Back_Screen").GetComponent<AudioSource>().Play(); 
        }
    }
}
