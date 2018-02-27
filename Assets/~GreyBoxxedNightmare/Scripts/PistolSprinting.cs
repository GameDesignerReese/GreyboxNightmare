using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolSprinting : MonoBehaviour {
    public Animator PutawayPivot;
    public GameObject Weapon_System;
    public GameObject Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Weapon_System.GetComponent<WeaponSystem>().WhichWeapon == 0)
        {
            Player.GetComponent<PlayerMovement>().AllowWeaponCameraSprint = false;
            if (Player.GetComponent<CharacterController>().isGrounded == true)
            {
                if (Player.GetComponent<PlayerMovement>().Sprinting == true)
                {
                    PutawayPivot.SetBool("Hide", true);
                    gameObject.GetComponent<Animator>().SetBool("Sprint", true);
                }
                else
                {
                    PutawayPivot.SetBool("Hide", false);
                    gameObject.GetComponent<Animator>().SetBool("Sprint", false);
                }
            }
            else
            {
                PutawayPivot.SetBool("Hide", false);
                gameObject.GetComponent<Animator>().SetBool("Sprint", false);
            }
        }
        else
        {
            Player.GetComponent<PlayerMovement>().AllowWeaponCameraSprint = true;
            gameObject.GetComponent<Animator>().SetBool("Sprint", false);
        }
	}
}
