using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectionControl : MonoBehaviour {
    public bool Updating;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Updating == true)
        {
            gameObject.GetComponent<ReflectionProbe>().refreshMode = UnityEngine.Rendering.ReflectionProbeRefreshMode.EveryFrame;
        }
        else
        {
            gameObject.GetComponent<ReflectionProbe>().refreshMode = UnityEngine.Rendering.ReflectionProbeRefreshMode.OnAwake;
        }
	}
}
