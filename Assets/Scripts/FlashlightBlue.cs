using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightBlue : MonoBehaviour {

    //Flashlight Object
    public Light flashlight;
	public GameObject newLense;

    // Sound Effects
    public AudioClip flashlightSound;
    private AudioSource source;

    //Flashlight slider
    //public Slider flashlightPower;

	//handle transform for switching lenses
	public Transform handle;
    public Transform battery;
    public Transform player;
    public float batDist = 1f;
    
    //Flashlight power variables
    public float power = 100.0f;
    private float maxPower = 100.0f;
    private float minPower = 0.0f;

    //Battery charge variable
    private float batteryCharge = 100.0f;

    //Number of batteries currently possesed by the player
    public int batteryCount;

    //Power Drain controls how fast the battery life decreases
    public float powerDrain;

    //Boolean that tells whether or not the flashlight is able to be used based off of current power
    private bool usable = true;

    Collider flashCollider;

    void Start()
    {
        flashCollider = GetComponent<CapsuleCollider>();
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Battery" && Vector3.Distance(battery.transform.position, player.transform.position) <= batDist && Input.GetKeyDown(KeyCode.E))
        {
            batteryCount += 1;
            Destroy(battery.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Battery" && Vector3.Distance(battery.transform.position, player.transform.position) <= batDist && Input.GetKeyDown(KeyCode.E))
        {
            batteryCount += 1;
            Destroy(battery.gameObject);
        }
    }

    void Update()
    {
        //If the F key is pressed and the power is greater than zero, then the flashlight will toggle between on and off
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(usable)
            {
                flashlight.enabled = !flashlight.enabled;
                flashCollider.enabled = !flashCollider.enabled;
            }
            
            source.PlayOneShot(flashlightSound);
        }
        //While the flashlight is on, the power will drain
        if (flashlight.enabled)
        {
            power -= Time.deltaTime * powerDrain;
            //flashlightPower.value = power;
        }

        //This is to ensure that the power will never go over 100
        if (power > maxPower)
        {
            power = maxPower;
        }

        //This is to disable the flashlight and make sure it can't be used until the player uses a battery to recharge the flashlight
        if (power < minPower)
        {
            power = minPower;
            flashlight.enabled = false;
            usable = false;
            //flashlightPower.value = power;
        }

        //After you replace the batteries, it allows you to use the flashlight again
        if (power > minPower)
        {
            usable = true;
        }

        //This says that if the player has at least one battery, and if they press R, then the flashlight will be fully charged
        if (Input.GetKeyDown(KeyCode.R) && batteryCount > 0)
        {
            power += batteryCharge;
            //flashlightPower.value = power;
            batteryCount -= 1;
        }

		if (Input.GetKeyDown(KeyCode.G))
		{
			GameObject yellowLense = Instantiate(newLense, handle.position, handle.rotation) as GameObject;
			yellowLense.transform.SetParent ( GameObject.FindGameObjectWithTag("Player").gameObject.transform, true);
			Destroy(gameObject);
		}
    }
}
