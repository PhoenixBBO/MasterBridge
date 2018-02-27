//Cale Toburen
//1/22/18
//Puzzle Switch
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSwitch : MonoBehaviour {
    public float depth = 8;
    public float depthPlus = 10;
    public float delay = 1;
    bool touched;

	// Use this for initialization
	void Start () {
        touched = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //checks if switch has been touched by player
    void OnTriggerEnter(Collider col)
    {
        if (!touched)
        {
            if (col.gameObject.tag == "Player")
            {

                StartCoroutine(StepedOn());
            }
        }
        
    }
    //moves switch up and down and stop player touching  
    IEnumerator StepedOn()
    {
        touched = true;
        transform.position = transform.position + new Vector3(0, -depth * Time.deltaTime, 0);
        yield return new WaitForSeconds(delay);
        transform.position = transform.position + new Vector3(0, depthPlus * Time.deltaTime, 0);
        touched = false;
    }

    /*IEnumerator Moving()
    {
        moving = false;
        while (moving == false)
        {
            transform.position = transform.position + new Vector3(0, speed * Time.deltaTime, 0);
            //print(Time.deltaTime);
            if (transform.position.y >= coinMax)
            {
                moving = true;
            }
            yield return null;
        }
        while (moving == true)
        {
            transform.position = transform.position + new Vector3(0, -speed * Time.deltaTime, 0);
            if (transform.position.y <= coinMin)
            {
                moving = false;
            }
            yield return null;
        }
        StartCoroutine(Moving());
        yield return null;

    }*/
}
