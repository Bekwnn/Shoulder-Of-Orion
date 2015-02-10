using UnityEngine;
using System.Collections;

public class ExitGame : MonoBehaviour {

	public void QuitCompletely()
	{
		Application.Quit();
	}

	public void ReturnToMenu()
	{
		Application.LoadLevel("Main Menu");
	}
}
