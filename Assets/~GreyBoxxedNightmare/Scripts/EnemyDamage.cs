using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    public GameObject WAVE_SYSTEM;
    public GameObject EnemyRoot;
    public GameObject EnemyFireSound;
    public float Damage;
    // Use this for initialization
    void Start () {
        WAVE_SYSTEM = GameObject.Find("WAVE_SYSTEM");
        if (EnemyRoot.GetComponent<EnemyAI>().FutureEnemy == true)
        {
            Damage = WAVE_SYSTEM.GetComponent<WaveSystem>().ZombieDamage;
        }
        else
        {
            Damage = WAVE_SYSTEM.GetComponent<WaveSystem>().SoldierDamage;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ZombieAttack()
    {
        if (EnemyRoot.GetComponent<EnemyAI>().Player.GetComponent<PlayerMovement>().PlayerArmor == 0)
        {
            GameObject.Find("Blood_Effect_Hit").GetComponent<Animation>().Play("GetHit");
            EnemyRoot.GetComponent<EnemyAI>().Player.GetComponent<PlayerMovement>().PlayerHealth -= Damage;
        }
        else
        {
            GameObject.Find("Armor_Effect_Hit").GetComponent<Animation>().Play("GetHit");
            EnemyRoot.GetComponent<EnemyAI>().Player.GetComponent<PlayerMovement>().PlayerArmor -= Damage;
        }
    }

    void ShootAt()
    {
        GameObject EnemyFireSoundObject = Instantiate(EnemyFireSound, gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().rotation);
        EnemyFireSoundObject.GetComponent<Transform>().parent = gameObject.GetComponent<Transform>();
        RaycastHit HitArmed;
        if (Physics.Raycast(gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().forward, out HitArmed, 100))
        {
            if (HitArmed.transform.tag == "Player")
            {
                if (EnemyRoot.GetComponent<EnemyAI>().Player.GetComponent<PlayerMovement>().PlayerArmor == 0)
                {
                    GameObject.Find("Blood_Effect_Hit").GetComponent<Animation>().Play("GetHit");
                    EnemyRoot.GetComponent<EnemyAI>().Player.GetComponent<PlayerMovement>().PlayerHealth -= Damage;
                }
                else
                {
                    GameObject.Find("Armor_Effect_Hit").GetComponent<Animation>().Play("GetHit");
                    EnemyRoot.GetComponent<EnemyAI>().Player.GetComponent<PlayerMovement>().PlayerArmor -= Damage;
                }
            }
        }
    }
}
