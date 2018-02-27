using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchLazerSpawn : MonoBehaviour {
    public Transform NormalPosition;
    public Transform CrouchPosition;
    public GameObject Player;
	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () {
		if(Player.GetComponent<PlayerMovement>().CrouchToggle == true)
        {
            gameObject.GetComponent<Transform>().position = CrouchPosition.position;
        }
        else
        {
            gameObject.GetComponent<Transform>().position = NormalPosition.position;
        }
	}
}
