using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Puzzle : MonoBehaviour
{
    public GameObject door;
	public GameObject puzzlePiece;
	public Transform lockedPiece;

	void Update()
	{
		
	}

    void OnTriggerEnter(Collider pp)
    {
		if (pp.tag == "PuzzlePiece")
        {
			Destroy(door);
			Destroy (pp.gameObject);
			Instantiate(puzzlePiece, lockedPiece.position, lockedPiece.rotation);
    	}
	}
}
