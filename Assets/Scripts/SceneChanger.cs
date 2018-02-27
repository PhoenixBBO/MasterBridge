using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Object nextScene;

	public void OnTriggerEnter(Collider collision)
	{
		if (collision.tag.Equals("Player"))
		{
			LoadNextScene();
		}
	}

	public void LoadNextScene()
	{
		SceneManager.LoadScene(nextScene.name);
	}
}
