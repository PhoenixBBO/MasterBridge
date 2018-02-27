using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class MouseController : MonoBehaviour
{
	private Vector3 screenPoint;
	private Vector3 offset;
	public Transform startPos;
	private Rigidbody rb;	
	public bool active = false;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
	}


	void Update()
	{
		if (transform.position.y < 223) 
		{
			transform.position = startPos.position;
			rb.Sleep();
		}
	}

		void OnMouseDown()
		{
			if (active) 
			{
				screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);

				offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
			}
		}

		void OnMouseDrag()
		{
			if (active)
			{
				Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

				Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
				transform.position = curPosition;
			}
		}
}
