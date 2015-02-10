using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GameStateSurvival))]

public class GameModeSurvival : GameMode {
	public int playerLives = 3;
	public float timeToRespawn = 1;
	bool waitingToRespawn;
	float respawnTimer;

	public override void RespawnPlayer(Vector3 location, Quaternion rotation)
	{
		playerLives--;
		GameInstance.instance.aGameMode.playerController.possessedPawn.SetActive(false);
		if (playerLives <= 0)
		{
			//go to gameover game state
			Debug.Log("GAME OVER");

			if (score > GameInstance.instance.survivalHighScore)
				GameInstance.instance.survivalHighScore = score;

			GameInstance.instance.aGameMode.gameState.GoToState((int)EGameStateSurvival.GAMEOVER);
		}
		else
		{
			respawnTimer = timeToRespawn;
			waitingToRespawn = true;
		}
	}

	void Update()
	{
		respawnTimer -= Time.deltaTime;
		if (waitingToRespawn && respawnTimer <= 0)
		{
			GameInstance.instance.aGameMode.playerController.possessedPawn.SetActive(true);
			waitingToRespawn = false;
		}
	}
}
