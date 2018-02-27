using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushItem : MonoBehaviour
{
    public bool grabbed = false;
    public GameObject player;

    public Rigidbody rb;

    private void start()
    {
        grabbed = false;
        rb = this.GetComponent<Rigidbody>();
    }
	
    void Update()
    {
        if(grabbed == true)
        {
            
        }

        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
