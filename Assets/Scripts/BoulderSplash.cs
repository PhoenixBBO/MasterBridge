using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class BoulderSplash : MonoBehaviour
{
  
    void OnCollisionEnter(Collision water)
    {
        if (water.gameObject.tag == "Water")
        {
	Destroy(water.gameObject);
			Destroy(gameObject);
        }
    }
}
