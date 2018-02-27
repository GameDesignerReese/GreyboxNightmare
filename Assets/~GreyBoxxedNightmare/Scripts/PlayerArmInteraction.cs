using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmInteraction : MonoBehaviour {
    public GameObject Player;
    public GameObject PunchSound;
    public GameObject RaycastCamera;
    public GameObject HITMARK_HIT;
    public GameObject TiltCameraPivot;
    public GameObject Player_Pistol_Sprint;
    public Transform Audio_Container;
    public GameObject TimeTravelSound;
    public Animation Time_Travel_Effect;
    public Animator PutawayPivot;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (gameObject.GetComponent<Animation>().IsPlaying("MeleeAttack") == false)
        {
            if (Input.GetButtonDown("Melee"))
            {
                gameObject.GetComponent<Animation>().Play("MeleeAttack");
            }
        }

        if (gameObject.GetComponent<Animation>().IsPlaying("TimeTravel") == false)
        {
            if (Input.GetButtonDown("TimeTravel"))
            {
                gameObject.GetComponent<Animation>().Play("TimeTravel");
            }
        }
    }

    void Punch()
    {
        if (RaycastCamera.GetComponent<RaycastHandler>().CurrentAttackable != null)
        {
            if (RaycastCamera.GetComponent<RaycastHandler>().CurrentAttackable.tag == "Enemy")
            {
                Instantiate(HITMARK_HIT);
                GameObject PunchSoundObject = Instantiate(PunchSound, Audio_Container.position, Audio_Container.rotation);
                PunchSoundObject.GetComponent<Transform>().parent = Audio_Container;
                RaycastCamera.GetComponent<RaycastHandler>().CurrentAttackable.GetComponent<EnemyAI>().EnemyHealth -= 100;
            }
        }
    }

    void TimeTravel()
    {
        GameObject TimeTravelSoundObject = Instantiate(TimeTravelSound);
        TimeTravelSoundObject.GetComponent<Transform>().parent = Audio_Container;
        GameObject.Find("REALITY_SYSTEM").GetComponent<RealitySystem>().FutureToggle += 1;
        if (GameObject.Find("REALITY_SYSTEM").GetComponent<RealitySystem>().FutureToggle == 1)
        {
            GameObject.Find("REALITY_SYSTEM").GetComponent<RealitySystem>().TravelledToFuture = true;
            Time_Travel_Effect.Play("TimeTravelEffectFuture");
        }
        else
        {
            GameObject.Find("REALITY_SYSTEM").GetComponent<RealitySystem>().TravelledToPast = true;
            Time_Travel_Effect.Play("TimeTravelEffect");
        }
    }

    void HideWeapons()
    {
        Player.GetComponent<PlayerMovement>().AllowSprintPivot = false;
        TiltCameraPivot.GetComponent<LeaningSystem>().LeaningLeft = false;
        TiltCameraPivot.GetComponent<LeaningSystem>().LeaningRight = false;
        Player_Pistol_Sprint.SetActive(false);
        PutawayPivot.SetBool("Hide", true);
    }

    void UnHideWeapons()
    {
        Player.GetComponent<PlayerMovement>().AllowSprintPivot = true;
        Player_Pistol_Sprint.SetActive(true);
        PutawayPivot.SetBool("Hide", false);
    }
}
