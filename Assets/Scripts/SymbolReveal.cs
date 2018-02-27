using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class SymbolReveal : MonoBehaviour
{
    public GameObject symbol;
    public float lightTimer;
    public float lightMaxTime;
    public bool lightDetect;
	public Transform symbolRevealed;

    public void Start()
    {
        lightDetect = false;
        lightTimer = lightMaxTime;
    }

	void Update()
	{
		ShowSymbol();
	}

    void OnTriggerEnter(Collider light)
    {
        if (light.tag == "FlashlightBlue")
        {
            lightDetect = true;
            lightTimer = lightMaxTime;
        }
    }

    void OnTriggerStay(Collider light)
    {
        if (light.tag == "FlashlightBlue")
        {
            lightDetect = true;
            lightTimer = (lightTimer - 1 * Time.deltaTime);
        }
    }

    void OnTriggerExit(Collider light)
    {
        lightDetect = false;
    }

   
    public void ShowSymbol()
    {
        if (lightTimer <= 0f)
        {
            Destroy(gameObject);
			Instantiate(symbol, symbolRevealed.position, symbolRevealed.rotation);
        }
    }
}
