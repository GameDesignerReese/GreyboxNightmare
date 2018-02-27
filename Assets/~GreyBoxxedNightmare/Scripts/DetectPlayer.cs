using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour {
    public GameObject EnemyRoot;
    public GameObject CurrentlySeeing;
    public bool BackRaycast;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(BackRaycast == false)
        {
            RaycastHit hit;

            if(Physics.Raycast(gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().forward, out hit, 100))
            {
                if(hit.transform.gameObject.tag == "Player")
                {
                    EnemyRoot.GetComponent<EnemyAI>().Patrolling = false;
                }

                CurrentlySeeing = hit.transform.gameObject;
            }
        }
        else
        {
            RaycastHit hit2;

            if (Physics.Raycast(gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().forward, out hit2, 10))
            {
                if (hit2.transform.gameObject.tag == "Player")
                {
                    EnemyRoot.GetComponent<EnemyAI>().Patrolling = false;
                }
            }
        }
	}
}
