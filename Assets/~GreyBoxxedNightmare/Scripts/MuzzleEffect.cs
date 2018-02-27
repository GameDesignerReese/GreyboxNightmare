using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleEffect : MonoBehaviour {
    public float RandomRotation;
    public float RandomValue = 90;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    void StartEffect()
    {
        RandomValue = Random.Range(-90, 1000);
        RandomRotation = Random.Range(0, 2);
        if (RandomRotation == 0)
        {
            gameObject.GetComponent<Transform>().Rotate(0, 0, RandomValue);
        }
        if (RandomRotation == 1)
        {
            gameObject.GetComponent<Transform>().Rotate(0, 0, -RandomValue);
        }
    }

    void EndEffect()
    {
        Destroy(gameObject);
    }
}
