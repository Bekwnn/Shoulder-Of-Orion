using UnityEngine;
using System.Collections;

public class GameModeTimeAttack : GameMode {
	public float timeRemaining;
	public float timeLimit = 180f; //default 3 minutes
	public int score;
	public float timeToRespawn = 2;
	bool waitingToRespawn;
	float respawnTimer;
	
	public override void RespawnPlayer(Vector3 location, Quaternion rotation)
	{
		GameInstance.instance.aGameMode.playerController.possessedPawn.SetActive(false);
		respawnTimer = timeToRespawn;
		waitingToRespawn = true;
	}

	void Update()
	{
		timeRemaining -= Time.deltaTime;
		if (timeRemaining <= 0)
		{
			//change game state to game over
		}

		respawnTimer -= Time.deltaTime;
		if (waitingToRespawn && respawnTimer <= 0)
		{
			GameInstance.instance.aGameMode.playerController.possessedPawn.SetActive(true);
			waitingToRespawn = false;
		}
	}
}
