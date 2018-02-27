// Chris Blanchard
// Tuesday 2/13/2018
// Motion Sensor Enemy Script with Nav Mesh

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor.AI;

public class MotionSensor : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
	
    }

    void Update()
    {
        Rigidbody targetRb = target.GetComponent<Rigidbody>();

        // If the player is within range and moving fast enough chase
        if (Vector3.Distance(target.position, transform.position) < 10f &&
                ((targetRb.velocity.x > 3f || targetRb.velocity.x < -3f) || (targetRb.velocity.z > 3f || targetRb.velocity.z < -3f)))
        {
            agent.destination = target.position;
        }
    }

    //Damages player on touch
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            Attack();
        }
    }

    // Controls Attack functions of Motion Sensor Enemy
    private void Attack()
    {
        CharacterHealth targetHealth = target.GetComponent<CharacterHealth>();
        targetHealth.healthSlider.value--;
		print ("GOT YA BITCH");
    }
}
