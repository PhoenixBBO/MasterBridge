using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour {
    
    //Battery game object
    //public GameObject battery;
    //Boolean that tells if the player is in the battery's collider
    private bool trig = false;
    //When player enters the collider, player will be able to collect the battery
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            trig = true;
        }
    }
    //When player exits the collider, player will be not able to collect the battery
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            trig = false;
        }
    }

    void Start()
    {
        trig = false;
    }

    void Update()
    {
        //When the player enters the trigger and presses the E key, they will recieve a new battery and the battery they collected will be removed from the scene
        if (trig == true)
        {
            Destroy(this.gameObject);
        }
    }
}
