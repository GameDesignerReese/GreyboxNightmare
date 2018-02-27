using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystem : MonoBehaviour {
    public float Waypoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter (Collider Col)
    {
        if(Col.gameObject.tag == "Enemy")
        {
            Col.gameObject.GetComponent<EnemyAI>().RandomWaypoint = Random.Range(0, 10);
        }
    }

    void OnTriggerStay(Collider Col)
    {
        if (Col.gameObject.tag == "Enemy")
        {
            if(Col.gameObject.GetComponent<EnemyAI>().RandomWaypoint == Waypoint)
            {
                Col.gameObject.GetComponent<EnemyAI>().RandomWaypoint = Random.Range(0, 10);
            }
        }
    }
}
