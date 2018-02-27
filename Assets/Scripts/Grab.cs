using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Grab : MonoBehaviour
{
	private Rigidbody rb;
	private bool grabbing = false;

	void Start()
	{        
		rb = GetComponent<Rigidbody>();
	}

	void Update ()
	{
		if (!grabbing) 
		{
			transform.parent = null;
			rb.constraints = RigidbodyConstraints.None;
		}

		if (Input.GetKeyDown (KeyCode.E)) 
		{
			grabbing = !grabbing;
		}
	}
		
	void OnCollisionStay(Collision player)
	{
		if (player.gameObject.tag == "Player" && grabbing) 
		{
				transform.parent = player.gameObject.transform;
				rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
		}
	}
}
