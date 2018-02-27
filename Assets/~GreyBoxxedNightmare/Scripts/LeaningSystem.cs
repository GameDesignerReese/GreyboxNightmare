using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaningSystem : MonoBehaviour {
    public Animator WeaponCameraPivot;
    public bool LeaningLeft;
    public bool LeaningRight;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButton("Sprint"))
        {
            LeaningLeft = false;
            LeaningRight = false;
        }

        if (LeaningLeft == true)
        {
            WeaponCameraPivot.SetBool("Left", true);
            gameObject.GetComponent<Animator>().SetBool("Left", true);
            if (Input.GetButtonDown("LeanLeft"))
            {
                LeaningLeft = false;
            }
            if (Input.GetButtonDown("LeanRight"))
            {
                LeaningLeft = false;
            }
        }
        else
        {
            if (LeaningRight == false)
            {
                WeaponCameraPivot.SetBool("Left", false);
                gameObject.GetComponent<Animator>().SetBool("Left", false);
                if (Input.GetButtonDown("LeanLeft"))
                {
                    LeaningLeft = true;
                }
            }
        }

        if (LeaningRight == true)
        {
            WeaponCameraPivot.SetBool("Right", true);
            gameObject.GetComponent<Animator>().SetBool("Right", true);
            if (Input.GetButtonDown("LeanLeft"))
            {
                LeaningRight = false;
            }

            if (Input.GetButtonDown("LeanRight"))
            {
                LeaningRight = false;
            }
        }
        else
        {
            if (LeaningLeft == false)
            {
                WeaponCameraPivot.SetBool("Right", false);
                gameObject.GetComponent<Animator>().SetBool("Right", false);
                if (Input.GetButtonDown("LeanRight"))
                {
                    LeaningRight = true;
                }
            }
        }
    }
}
