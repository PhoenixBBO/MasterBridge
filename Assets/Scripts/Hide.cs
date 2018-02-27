using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Hide : MonoBehaviour
{
	public Transform hidden;
	public Transform revealed;
	public bool hide;

	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.E) && hide) 
		{
			GameObject.FindGameObjectWithTag("Player").gameObject.transform.position = revealed.transform.position;
			GameObject.FindGameObjectWithTag("Player").gameObject.transform.GetComponent<PlayerControllerG>().enabled = true;
			hide = false;
		}
	}
		
	void OnTriggerStay(Collider player)
	{
		if (player.gameObject.tag == "Player") 
		{
			if (Input.GetKey (KeyCode.E)) 
			{
				hide = true;
				player.transform.position = hidden.transform.position;
				player.transform.GetComponent<PlayerControllerG>().enabled = false;
			}
			//player.gameObject.GetComponent<Renderer>().enabled = false;
		}
	}
}
