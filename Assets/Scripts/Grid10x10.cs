using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Grid10x10 : MonoBehaviour
{
	public Transform[] tiles;
	public GameObject tilesPrefab;

	void Start()
	{
		tiles =  gameObject.GetComponentsInChildren<Transform>();
		for (int i = 0; i < tiles.Length; i++) 
		{
			Debug.Log("Tile Number "+i+" is named "+tiles[i].name);

			Instantiate (tilesPrefab, tiles[i].position, tiles[i].rotation);
		}
	}
}
