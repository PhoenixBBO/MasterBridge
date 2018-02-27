using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class SwitchDoor : MonoBehaviour
{
    public GameObject door;
  
    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
			Destroy(door);
        }
    }
}
