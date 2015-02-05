using UnityEngine;
using System.Collections;

public class GameModeSurvival : GameMode {

	public int playerLives;

	public void Respawn(Transform locationRotation)
	{
		playerLives--;
		GameObject pawn = (GameObject)Instantiate(defaultPawn.defaultObject);
		playerController.Possess(pawn);
	}
}
