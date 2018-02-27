//Cale Toburen
//1/22/18
//Puzzle Switch
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSwitch : MonoBehaviour
{
    public float depth = 1;
    public float depthPlus = 1;
    public float delay = 1;
    bool touched;

    // Use this for initialization
    void Start()
    {
        touched = false;
    }

    // Update is called once per frame
    void Update()
    {

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
        transform.position = transform.position + new Vector3(depth * Time.deltaTime, 0, 0);
        yield return new WaitForSeconds(delay);
        
    }
}
