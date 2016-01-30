using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
	void Awake ()
	{
		DontDestroyOnLoad(this); // makes sure this gameobject moves between the scenes
	}



	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			LoadMenu();
		}

		if (Input.GetKeyDown(KeyCode.Z))
		{
			LoadHome();
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			LoadArena();
		}
	}



	// Functions used to change scenes
	public void LoadMenu()
	{
		SceneManager.LoadScene("MainMenu"); // Go to Menu
	}

	public void LoadHome()
	{
		SceneManager.LoadScene("House"); // Go to Home
	}

	public void LoadArena()
	{
		SceneManager.LoadScene("Game"); // Go to Arena
	}
}