using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
	public float camHeight = 70f;
	public float camPosX = 0;
	public float camPosZ = 0;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").gameObject;
	}
    void LateUpdate()
    {
		transform.position = new Vector3(player.transform.position.x + camPosX, player.transform.position.y + camHeight, player.transform.position.z + camPosZ);
    }
}

