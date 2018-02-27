using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class SwitchTrickDoor : MonoBehaviour
{
    public GameObject door;
	public GameObject door2;
	public GameObject ppDoor;
	private Transform doorUp;
	private Transform doorDown;
	public Vector3 doorPos;

	void Start()
	{
		doorPos = door.transform.position;
	}
  
    void OnTriggerEnter(Collider player)
    {
		if (player.tag == "Player" || player.tag == "Boulder")
        {
			door.transform.position = doorPos;
			door2.transform.position = new Vector3(door.transform.position.x, door.transform.position.y - 10, door.transform.position.z);
        }
    }
}
