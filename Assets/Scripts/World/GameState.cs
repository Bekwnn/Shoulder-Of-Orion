using UnityEngine;
using System.Collections;

abstract public class GameState : MonoBehaviour {
	/* manages the state of the game
	 */
	public int currentState;

	virtual public void GoToState(int newState)
	{
		currentState = newState;
	}
}