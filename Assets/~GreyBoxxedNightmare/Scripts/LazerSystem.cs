using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerSystem : MonoBehaviour {
    public float DeleteTime = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Transform>().Translate(Vector3.left * 1.3f);

        DeleteTime -= Time.deltaTime * 1;

        if(DeleteTime < 0)
        {
            Destroy(gameObject);
        }
	}
}
