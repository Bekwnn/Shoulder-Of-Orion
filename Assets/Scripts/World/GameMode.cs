using UnityEngine;
using System.Collections;

[RequireComponent(typeof(DefaultGameObject))]
[RequireComponent(typeof(PlayerHUD))]
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GameState))]

abstract public class GameMode : MonoBehaviour {
	/* Dictates the rules of a game
	 */

	public DefaultGameObject defaultPawn;
	public PlayerHUD playerHUD;
	public PlayerController playerController;
	public GameState gameState;

	void Awake()
	{
		if (defaultPawn == null) 		defaultPawn = GetComponent<DefaultGameObject>();
		if (playerHUD == null) 			playerHUD = GetComponent<PlayerHUD>();
		if (playerController == null) 	playerController = GetComponent<PlayerController>();
		if (gameState == null) 			gameState = GetComponent<GameState>();
	}

	void Start()
	{
		SpawnPlayer();
	}

	public void SpawnPlayer(Vector3 location, Quaternion rotation)
	{

		GameObject pawn = (defaultPawn.defaultObject)?
			(GameObject)Instantiate(defaultPawn.defaultObject) : new GameObject("Empty Pawn");
		pawn.transform.position = location;
		pawn.transform.rotation = rotation;
		playerController.Possess(pawn);
	}

	public void SpawnPlayer()
	{
		GameObject pawn = (defaultPawn.defaultObject)?
			(GameObject)Instantiate(defaultPawn.defaultObject) : new GameObject("Empty Pawn");
		playerController.Possess(pawn);
	}

	abstract public void RespawnPlayer(Vector3 location, Quaternion rotation);
	abstract public void AddScore(int scoreIncrease);
}
