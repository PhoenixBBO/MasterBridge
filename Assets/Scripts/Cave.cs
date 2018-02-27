using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Cave : MonoBehaviour
{
	public Transform cave;
	public Transform outside;
	public GameObject Player;
	public GameObject cam;
	private bool frozen;

	void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Player").gameObject;
	}

	void OnTriggerEnter(Collider p)
	{
		if (p.tag == "Player" && Player.GetComponent<Rigidbody>().velocity.magnitude > 13) 
		{
			Player.transform.position = cave.transform.position;
			cam.GetComponent<CameraFollowIsometric>().camHeight = -16.18005f;
			cam.GetComponent<CameraFollowIsometric>().camPosX = 0f;
			cam.GetComponent<CameraFollowIsometric>().camPosZ = 16.0795f;
		}

		if (p.tag == "Player" && Player.GetComponent<Rigidbody>().velocity.magnitude < 13) 
		{
			Player.transform.position = outside.transform.position;
			cam.GetComponent<CameraFollowIsometric>().camHeight = 0;
			cam.GetComponent<CameraFollowIsometric>().camPosX = 0;
			cam.GetComponent<CameraFollowIsometric>().camPosZ = 0;
		}

	}
}
