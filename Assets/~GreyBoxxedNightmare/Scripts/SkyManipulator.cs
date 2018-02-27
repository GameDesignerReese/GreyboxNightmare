using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyManipulator : MonoBehaviour {
    public GameObject REALITY_SYSTEM;
    public Material PastSky;
    public Material FutureSky;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(REALITY_SYSTEM.GetComponent<RealitySystem>().FutureToggle == 1)
        {
            gameObject.GetComponent<Skybox>().material = FutureSky;
        }
        else
        {
            gameObject.GetComponent<Skybox>().material = PastSky;
        }
	}
}
