using UnityEngine;
using System.Collections;

public enum EGameState
{
	DEFAULT,
	MENU,
	PLAYING
};

public class GameState : MonoBehaviour {
	/* manages the state of the game
	 */
	EGameState currentState;

	public void GoToState(EGameState newState)
	{
		currentState = newState;
	}
}
