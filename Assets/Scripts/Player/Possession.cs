using UnityEngine;
using System.Collections;

public class Possession : MonoBehaviour {
	/* allows the player game object to communicate with the controller and
	 * indicates whether it's possessed or not
	 */
	public PlayerController playerController;

	public void OnPossessed(PlayerController possessedBy)
	{
		playerController = possessedBy;
	}
}
