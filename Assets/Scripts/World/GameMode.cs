using UnityEngine;
using System.Collections;

[RequireComponent(typeof(DefaultGameObject))]
[RequireComponent(typeof(PlayerHUD))]
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GameState))]

public class GameMode : MonoBehaviour {
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
		//spawn default pawn, location/rotation can be set in the prefab in assets
		GameObject pawn = (GameObject)Instantiate(defaultPawn.defaultObject);
		playerController.Possess(pawn);
	}
}
