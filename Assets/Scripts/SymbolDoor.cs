using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class SymbolDoor : MonoBehaviour
{
    public GameObject door;
	public GameObject symbol;
	public Transform symbolRevealed;
    public float lightTimer;
    public float lightMaxTime;
    public bool lightDetect;

    public void Start()
    {
        lightDetect = false;
        lightTimer = lightMaxTime;
    }

	void Update()
	{
		
		DoorOpen();
	}

    void OnTriggerEnter(Collider light)
    {
        if (light.tag == "Flashlight")
        {
            lightDetect = true;
            lightTimer = lightMaxTime;
        }
    }

    void OnTriggerStay(Collider light)
    {
        if (light.tag == "Flashlight")
        {
            lightDetect = true;
            lightTimer = (lightTimer - 1 * Time.deltaTime);
        }
    }

    void OnTriggerExit(Collider light)
    {
        lightDetect = false;
    }

   
    public void DoorOpen()
    {
        if (lightTimer <= 0f)
        {
            Destroy(door);
			Destroy (gameObject);
			Instantiate (symbol, symbolRevealed.position, symbolRevealed.rotation);
        }
    }
}
