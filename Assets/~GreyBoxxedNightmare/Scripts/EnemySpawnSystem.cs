using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSystem : MonoBehaviour {
    public GameObject EnemyType;
    public GameObject EnemyClone;
    public bool SpawnEnemy = true;
    public float SpawnTime;
    public bool SetRespawnTime;
	// Use this for initialization
	void Start () {
        EnemyClone = null;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(EnemyClone != null)
        {
            if(EnemyClone.GetComponent<EnemyAI>().EnemyAlive == false)
            {
                if(SetRespawnTime == true)
                {
                    SpawnTime = 7;
                    EnemyClone = null;
                    SetRespawnTime = false;
                }
            }
        }
        else
        {
            SetRespawnTime = true;
        }

        if(SpawnTime <= 0)
        {
            if (SpawnEnemy == true)
            {
                EnemyClone = Instantiate(EnemyType, gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().rotation);
                SpawnEnemy = false;
            }
            SpawnTime = 0;
        }
        else
        {
            SpawnEnemy = true;
            SpawnTime -= Time.deltaTime * 1;
        }
	}
}
