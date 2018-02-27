using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    //public float timeBetweenAttacks = 0.5f;
    //public Slider EnemyHealthBar;
    //public EnemyAttack attackScript;

    public Transform player;
    private NavMeshAgent nav;
    public Transform enemy;

    public bool isFollowing;

    public float minDist;
    public float maxDist;
    public float moveSpeed;

    public float enemyTimer;
    public float enemyMaxTime;

    public bool lightDetect;
    public bool enemyDetect;
    //bool isDead = false;

    public void Start()
    {
        enemyDetect = false;
        lightDetect = false;
        //Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        Transform enemy = GameObject.FindGameObjectWithTag("Ghost").transform;
        enemyTimer = enemyMaxTime;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        nav = GetComponent<NavMeshAgent>();
        isFollowing = false;
    }

    void Update()
    {
        EnemySearch();
        EnemyFollowPlayer();
        EnemyFollow();
        EnemyDet();
        EnemyDeath();
    }

    void EnemyFollowPlayer()
    {
        if (isFollowing == true)
        {
            nav.SetDestination(player.transform.position);
        }
        if (isFollowing != true)
        {
            transform.position = transform.position;
        }
    }

    void EnemySearch()
    {
        if (Vector3.Distance(transform.position, player.transform.position) >= minDist && Vector3.Distance(transform.position, player.transform.position) <= maxDist)
        {
            isFollowing = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
		if (col.tag == "Flashlight" || col.tag == "FlashlightBlue")
        {
            enemyDetect = false;
            lightDetect = true;
            enemyTimer = enemyMaxTime;
        }
    }

    void OnTriggerStay(Collider col)
    {
		if (col.tag == "Flashlight" || col.tag == "FlashlightBlue")
        {
            enemyDetect = false;
            lightDetect = true;
            enemyTimer = (enemyTimer - 1 * Time.deltaTime);
        }
    }

    void OnTriggerExit(Collider col)
    {
        lightDetect = false;
    }

    public void EnemyDet()
    {
        if (Vector3.Distance(enemy.transform.position, player.transform.position) >= minDist && Vector3.Distance(enemy.transform.position, player.transform.position) <= maxDist && lightDetect == false)
        {
            enemyDetect = true;
        }
        if (lightDetect == true)
        {
            enemyDetect = false;
        }
    }

    public void EnemyFollow()
    {
        if (enemyDetect == true && lightDetect == false)
        {
            nav.transform.LookAt(player);
            nav.transform.position += nav.transform.forward * moveSpeed * Time.deltaTime;
        }
        else if (enemyDetect == false || lightDetect == true)
        {
            nav.transform.position = nav.transform.position;
        }
        if (lightDetect == true)
        {
            this.nav.speed = 0;
        }
    }

    public void EnemyDeath()
    {
        if (enemyTimer <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
