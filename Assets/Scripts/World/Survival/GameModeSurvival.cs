using UnityEngine;
using System.Collections;

public class GameModeSurvival : GameMode {
	public int playerLives = 3;
	public int score;
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
