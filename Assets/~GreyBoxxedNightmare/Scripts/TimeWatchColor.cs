using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWatchColor : MonoBehaviour
{
    public Material PastColor;
    public Material FutureColor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(GameObject.Find("REALITY_SYSTEM").GetComponent<RealitySystem>().FutureToggle == 1)
        {
            gameObject.GetComponent<Renderer>().material = FutureColor;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material = PastColor;
        }
	}
}
