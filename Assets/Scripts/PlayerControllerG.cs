using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerG : MonoBehaviour {

    public Transform player;
    public float speed;
    public Camera mainCamera;
    public GameObject[] keys;
    public Vector3 respawnPoint;
	private Rigidbody rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Start ()
	{
		respawnPoint = transform.position; 
	}

    // Update is called once per frame
   void Update() {
		Movement(); 
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Input.GetKey(KeyCode.Space))
        {
            GrabObject();
        }

        if (Physics.Raycast(ray, out hit, 100))
        {
            player.LookAt(new Vector3(hit.point.x, player.position.y, hit.point.z));
        }
    }

    public void GrabObject()
    {
        foreach (GameObject go in keys)
        {
            if(Vector3.Distance(player.transform.position, go.transform.position) <= 10f)
            {
                go.GetComponent<PushItem>().grabbed = true;
            }
            else
                go.GetComponent<PushItem>().grabbed = false;
        }
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
			rb.velocity = new Vector3 (0, rb.velocity.y, 1 * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
			rb.velocity = new Vector3 (0, rb.velocity.y, -1 * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
			rb.velocity = new Vector3 (1 * speed, rb.velocity.y, 0);
        }
		if (Input.GetKey (KeyCode.A)) {
			rb.velocity = new Vector3 (-1 * speed, rb.velocity.y, 0);
		} 

		if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
		{
			rb.velocity = new Vector3 (0, rb.velocity.y, 0);
		}

		if (rb.velocity.y < 0)
		{
			rb.velocity += Vector3.up * Physics.gravity.y * Time.deltaTime;
		}
}

	private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DeathBarrier")
        {
            transform.position = respawnPoint;
        }
        
        if (other.tag == "Checkpoint")
        {
            respawnPoint = other.transform.position;
        }
	}
}