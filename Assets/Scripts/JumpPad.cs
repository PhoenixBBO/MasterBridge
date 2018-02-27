using UnityEngine;
using System.Collections;

public class JumpPad : MonoBehaviour
{
	public float jumpForceX = 0f;
	public float jumpForceY = 0f;
	public float jumpForceZ = 0f;
    
	void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Player")
		{
			other.GetComponent<Rigidbody>().AddForce(new Vector3 (jumpForceX, jumpForceY, jumpForceZ));
			//other.GetComponent<Rigidbody>().AddForce(new Vector3 (jumpForceX, jumpForceY, jumpForceZ));
		}
	}
}