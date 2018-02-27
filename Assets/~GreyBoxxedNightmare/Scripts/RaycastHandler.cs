using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHandler : MonoBehaviour {
    public GameObject BulletHole;
    public GameObject CurrentObject;
    public GameObject CurrentAttackable;
    public RaycastHit Hit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        RaycastHit Hit;

        if(Physics.Raycast(gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().forward, out Hit, 100))
        {
            CurrentObject = Hit.transform.gameObject;
        }
        else
        {
            CurrentObject = null;
        }

        RaycastHit Hit2;

        if (Physics.Raycast(gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().forward, out Hit2, 2))
        {
            CurrentAttackable = Hit.transform.gameObject;
        }
        else
        {
            CurrentAttackable = null;
        }
    }
}
