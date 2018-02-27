using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchUnderSurface : MonoBehaviour {
    public GameObject Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        RaycastHit hit;

        if(Physics.Raycast(gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().up, out hit, 2))
        {
            if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Default"))
            {
                Player.GetComponent<PlayerMovement>().PermanentCrouch = true;
            }
            else
            {
                Player.GetComponent<PlayerMovement>().PermanentCrouch = false;
            }
        }
        else
        {
            Player.GetComponent<PlayerMovement>().PermanentCrouch = false;
        }
	}
}
