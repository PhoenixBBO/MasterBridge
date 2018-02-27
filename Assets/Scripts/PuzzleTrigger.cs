using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PuzzleTrigger : MonoBehaviour
{
	public GameObject PuzzlePiece;
	public GameObject Player;
	public GameObject cam;
	private bool frozen;

	void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Player").gameObject;
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
	}

	void Update()
	{
	}

	void OnTriggerStay(Collider p)
	{
		if (p.tag == "Player" && Input.GetKeyDown (KeyCode.E)) 
		{
			frozen = !frozen;
		}

		if (p.tag == "Player" && frozen)
		{
			Player.GetComponent<PlayerControllerG>().enabled = false;
			cam.GetComponent<CameraFollowIsometric>().camHeight = -23.8495f;
			cam.GetComponent<CameraFollowIsometric>().camPosX = 0f;
			cam.GetComponent<CameraFollowIsometric>().camPosZ = 21.3088f;
			if (PuzzlePiece != null) 
			{
				PuzzlePiece.GetComponent<MouseController>().active = true;
			}
		}

		if (p.tag == "Player" && !frozen && Input.GetKeyDown(KeyCode.E)) 
		{
			Player.GetComponent<PlayerControllerG> ().enabled = true;
			cam.GetComponent<CameraFollowIsometric>().camHeight = 0;
			cam.GetComponent<CameraFollowIsometric>().camPosX = 0;
			cam.GetComponent<CameraFollowIsometric>().camPosZ = 0;

			if (PuzzlePiece != null) 
			{
				PuzzlePiece.GetComponent<MouseController> ().active = false;
			}
		}
	}
}
