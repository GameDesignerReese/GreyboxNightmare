using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackDetector : MonoBehaviour {
    public GameObject EnemyRoot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (EnemyRoot.GetComponent<EnemyAI>().FutureEnemy == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().forward, out hit, 100))
            {
                if (hit.transform.gameObject.tag == "Player")
                {
                    if (EnemyRoot.GetComponent<EnemyAI>().Patrolling == false)
                    {
                        EnemyRoot.GetComponent<EnemyAI>().Attacking = true;
                    }
                }
                else
                {
                    EnemyRoot.GetComponent<EnemyAI>().Attacking = false;
                }
            }
            else
            {
                EnemyRoot.GetComponent<EnemyAI>().Attacking = false;
            }
        }
	}

    void OnTriggerStay(Collider Col)
    {
        if(Col.gameObject.tag == "Player")
        {
            if (EnemyRoot.GetComponent<EnemyAI>().Patrolling == false)
            {
                EnemyRoot.GetComponent<EnemyAI>().Attacking = true;
            }
        }
    }

    void OnTriggerExit(Collider Col)
    {
        if (Col.gameObject.tag == "Player")
        {
            EnemyRoot.GetComponent<EnemyAI>().Attacking = false;
        }
    }
}
