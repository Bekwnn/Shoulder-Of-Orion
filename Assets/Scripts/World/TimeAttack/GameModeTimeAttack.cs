using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GameStateTimeAttack))]

public class GameModeTimeAttack : GameMode {
	public float timeLimit = 180f; //default 3 minutes
	public int score;
	public float timeToRespawn = 2;
	float timeRemaining;
	bool waitingToRespawn;
	float respawnTimer;

	void Awake()
	{
		timeRemaining = timeLimit;
	}
	
	public override void RespawnPlayer(Vector3 location, Quaternion rotation)
	{
		GameInstance.instance.aGameMode.playerController.possessedPawn.SetActive(false);
		respawnTimer = timeToRespawn;
		waitingToRespawn = true;
	}

	public override void AddScore(int scoreIncrease)
	{
		score += scoreIncrease;
	}

	void Update()
	{
		timeRemaining -= Time.deltaTime;
		if (timeRemaining <= 0)
		{
			//change game state to game over
			Debug.Log("GAME OVER");
			GameInstance.instance.aGameMode.playerController.possessedPawn.SetActive(false);
		}

		respawnTimer -= Time.deltaTime;
		if (waitingToRespawn && respawnTimer <= 0)
		{
			GameInstance.instance.aGameMode.playerController.possessedPawn.SetActive(true);
			waitingToRespawn = false;
		}
	}
}
