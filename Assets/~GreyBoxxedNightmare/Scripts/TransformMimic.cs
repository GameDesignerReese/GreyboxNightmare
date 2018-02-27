using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMimic : MonoBehaviour {
    public Transform Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Transform>().position = Player.position;
        gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(0, Player.eulerAngles.y, 0));
    }
}
