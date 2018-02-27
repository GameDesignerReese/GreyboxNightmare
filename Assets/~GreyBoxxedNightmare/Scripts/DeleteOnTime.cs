using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnTime : MonoBehaviour {
    public float DeleteTime = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DeleteTime -= Time.deltaTime * 1;

        if(DeleteTime < 0)
        {
            Destroy(gameObject);
        }
	}
}
