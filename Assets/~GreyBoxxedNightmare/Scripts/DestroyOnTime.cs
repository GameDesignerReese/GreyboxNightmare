using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(GameObject.Find("REALITY_SYSTEM").GetComponent<RealitySystem>().FutureToggle == 0)
        {
            Destroy(gameObject);
        }
	}
}
