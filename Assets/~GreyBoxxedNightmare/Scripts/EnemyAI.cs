using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
    public bool FutureEnemy;
    public GameObject AmmoPickup;
    public GameObject ArmorPickup;
    public GameObject CurrentEnvironment;
    public GameObject WAYPOINTS;
    public Transform Player;
    public Animator EnemyAnimator;
    public GameObject Blood;
    public GameObject BloodSound;
    public Animator CharacterPivot;
    public GameObject HITMARK_KILL;
    public float EnemyHealth = 100;
    public bool EnemyAlive = true;
    public float DeleteTime = 5;
    public bool Patrolling = true;
    public float RandomWaypoint;
    public bool Attacking;
    public bool StartPatrol = true;
    public float RandomScore;
    public AudioClip[] SearchVoices;
    public AudioClip[] AttackVoices;
    public AudioClip[] DeadVoices;
    public float SpeakTime;
    public bool AllowVoices = true;
    public float RandomPickup;
    public Transform PlayerLookAt;
    // Use this for initialization
    void Start ()
    {
        if(FutureEnemy == true)
        {
            gameObject.GetComponent<Transform>().parent = GameObject.Find("REALITY_SYSTEM").GetComponent<RealitySystem>().Future.GetComponent<Transform>();
        }
        else
        {
            gameObject.GetComponent<Transform>().parent = GameObject.Find("REALITY_SYSTEM").GetComponent<RealitySystem>().Past.GetComponent<Transform>();
        }
        WAYPOINTS = GameObject.Find("WAYPOINTS");
        Player = GameObject.Find("Player_Controller").GetComponent<Transform>();
        RandomWaypoint = Random.Range(0, 10);
	}
	
	// Update is called once per frame

    void Voices()
    {
        if (SpeakTime <= 0)
        {
            if (Patrolling == true)
            {
                gameObject.GetComponent<AudioSource>().clip = SearchVoices[Random.Range(0, SearchVoices.Length)];
            }
            else
            {
                gameObject.GetComponent<AudioSource>().clip = AttackVoices[Random.Range(0, AttackVoices.Length)];
            }
            gameObject.GetComponent<AudioSource>().Play();
            SpeakTime = Random.Range(2, 10);
        }
        else
        {
            SpeakTime -= Time.deltaTime * 1;
        }
    }

	void Update ()
    {
        if (AllowVoices == true)
        {
            Voices();
        }

        if(DeleteTime < 0)
        {
            Destroy(gameObject);
        }

		if(EnemyHealth <= 0)
        {
            if (EnemyAlive == true)
            {
                RandomScore = Random.Range(100, 200);
                GameObject.Find("GAME_DATA").GetComponent<GameData>().Highscore += RandomScore;
                GameObject.Find("GAME_DATA").GetComponent<GameData>().Kills += 1;
                GameObject.Find("SCORE_DISPLAY").GetComponent<ScoreDisplay>().Points = RandomScore;
                GameObject.Find("SCORE_DISPLAY").GetComponent<ScoreDisplay>().PointsDecrease = RandomScore;
                GameObject.Find("SCORE_DISPLAY").GetComponent<Animation>().Play("ScoreAdd");
                if(GameObject.Find("REALITY_SYSTEM").GetComponent<RealitySystem>().KilledAnEnemy == false)
                {
                    GameObject.Find("REALITY_SYSTEM").GetComponent<RealitySystem>().KilledAnEnemy = true;
                }
                GameObject.Find("WAVE_SYSTEM").GetComponent<WaveSystem>().EnemiesKilled += 1;
                gameObject.GetComponent<NavMeshAgent>().enabled = false;
                Attacking = false;
                EnemyAnimator.SetBool("Attack", false);
                EnemyAnimator.SetBool("Run", false);
                GameObject HitMarker = Instantiate(HITMARK_KILL);
                gameObject.GetComponent<Collider>().enabled = false;
                AllowVoices = false;
                gameObject.GetComponent<AudioSource>().clip = DeadVoices[Random.Range(0, DeadVoices.Length)];
                gameObject.GetComponent<AudioSource>().Play();
                if (FutureEnemy == false)
                {
                    RandomPickup = Random.Range(0, 5);
                    if (RandomPickup == 1)
                    {
                        Instantiate(AmmoPickup, gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().rotation);
                    }
                    if (RandomPickup == 2)
                    {
                        Instantiate(ArmorPickup, gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().rotation);
                    }
                }
                EnemyAlive = false;
            }

            if(FutureEnemy == false)
            {
                EnemyAnimator.SetBool("Dead", true);
            }
            CharacterPivot.SetBool("Dead", true);
            DeleteTime -= Time.deltaTime * 1;
            EnemyHealth = 0;
        }
        else
        {
            EnemyAlive = true;

            if (FutureEnemy == true)
            {
                if (GameObject.Find("REALITY_SYSTEM").GetComponent<RealitySystem>().TravelledToFuture == true)
                {
                    if (StartPatrol == true)
                    {
                        if(FutureEnemy == true)
                        {
                            Attacking = false;
                        }
                        if (gameObject.GetComponent<NavMeshAgent>().enabled == true)
                        {
                            gameObject.GetComponent<NavMeshAgent>().speed = 3.5f;
                        }
                        Patrolling = true;
                        StartPatrol = false;
                    }
                }
                else
                {
                    Patrolling = false;
                    StartPatrol = true;
                }
            }
            else
            {
                if (GameObject.Find("REALITY_SYSTEM").GetComponent<RealitySystem>().TravelledToPast == true)
                {
                    if (StartPatrol == true)
                    {
                        if (FutureEnemy == false)
                        {
                            Attacking = false;
                        }
                        if (gameObject.GetComponent<NavMeshAgent>().enabled == true)
                        {
                            gameObject.GetComponent<NavMeshAgent>().speed = 3.5f;
                        }
                        Patrolling = true;
                        StartPatrol = false;
                    }
                }
                else
                {
                    Patrolling = false;
                    StartPatrol = true;
                }
            }


            if(Attacking == false)
            {
                gameObject.GetComponent<NavMeshAgent>().enabled = true;
            }

            if (Patrolling == true)
            {
                EnemyAnimator.SetBool("Run", true);
                if (gameObject.GetComponent<NavMeshAgent>().enabled == true)
                {
                    if (RandomWaypoint == 0)
                    {
                        gameObject.GetComponent<NavMeshAgent>().SetDestination(WAYPOINTS.GetComponent<WaypointContainer>().Waypoints[0].position);
                    }
                    if (RandomWaypoint == 1)
                    {
                        gameObject.GetComponent<NavMeshAgent>().SetDestination(WAYPOINTS.GetComponent<WaypointContainer>().Waypoints[1].position);
                    }
                    if (RandomWaypoint == 2)
                    {
                        gameObject.GetComponent<NavMeshAgent>().SetDestination(WAYPOINTS.GetComponent<WaypointContainer>().Waypoints[2].position);
                    }
                    if (RandomWaypoint == 3)
                    {
                        gameObject.GetComponent<NavMeshAgent>().SetDestination(WAYPOINTS.GetComponent<WaypointContainer>().Waypoints[3].position);
                    }
                    if (RandomWaypoint == 4)
                    {
                        gameObject.GetComponent<NavMeshAgent>().SetDestination(WAYPOINTS.GetComponent<WaypointContainer>().Waypoints[4].position);
                    }
                    if (RandomWaypoint == 5)
                    {
                        gameObject.GetComponent<NavMeshAgent>().SetDestination(WAYPOINTS.GetComponent<WaypointContainer>().Waypoints[5].position);
                    }
                    if (RandomWaypoint == 6)
                    {
                        gameObject.GetComponent<NavMeshAgent>().SetDestination(WAYPOINTS.GetComponent<WaypointContainer>().Waypoints[6].position);
                    }
                    if (RandomWaypoint == 7)
                    {
                        gameObject.GetComponent<NavMeshAgent>().SetDestination(WAYPOINTS.GetComponent<WaypointContainer>().Waypoints[7].position);
                    }
                    if (RandomWaypoint == 8)
                    {
                        gameObject.GetComponent<NavMeshAgent>().SetDestination(WAYPOINTS.GetComponent<WaypointContainer>().Waypoints[8].position);
                    }
                    if (RandomWaypoint == 9)
                    {
                        gameObject.GetComponent<NavMeshAgent>().SetDestination(WAYPOINTS.GetComponent<WaypointContainer>().Waypoints[9].position);
                    }
                }
            }
            else
            {
                if(FutureEnemy == true)
                {
                    GameObject.Find("REALITY_SYSTEM").GetComponent<RealitySystem>().TravelledToFuture = false;
                }
                else
                {
                    GameObject.Find("REALITY_SYSTEM").GetComponent<RealitySystem>().TravelledToPast = false;
                }

                if (Attacking == false)
                {
                    EnemyAnimator.SetBool("Attack", false);
                    EnemyAnimator.SetBool("Run", true);
                    gameObject.GetComponent<NavMeshAgent>().enabled = true;
                    if (gameObject.GetComponent<NavMeshAgent>().enabled == true)
                    {
                        gameObject.GetComponent<NavMeshAgent>().SetDestination(Player.position);
                    }
                }
                else
                {
                    EnemyAnimator.SetBool("Attack", true);
                    EnemyAnimator.SetBool("Run", false);
                    gameObject.GetComponent<NavMeshAgent>().enabled = false;
                    if (FutureEnemy == false)
                    {
                        gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, PlayerLookAt.eulerAngles.y, 0);
                    }
                }
            }

            if (FutureEnemy == false)
            {
                PlayerLookAt.GetComponent<Transform>().LookAt(Player.GetComponent<Transform>());
            }
        }
	}
}
