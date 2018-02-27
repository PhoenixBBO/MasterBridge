using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PressurePlateDoor : MonoBehaviour
{
    public GameObject door;
	public GameObject ppDoor;
	private GameObject newDoor = null;
	public Vector3 doorPos;

	void Start()
	{
		doorPos = door.transform.position;
	}
  
    void OnTriggerStay(Collider player)
    {
		if (player.tag == "Player" || player.tag == "Boulder")
        {
			Destroy(door);
			Destroy (newDoor);
        }
    }

	void OnTriggerExit(Collider player)
	{
		if (player.tag == "Player" || player.tag == "Boulder")
		{
			newDoor = Instantiate(ppDoor, doorPos, transform.rotation) as GameObject;
		}
	}


}
