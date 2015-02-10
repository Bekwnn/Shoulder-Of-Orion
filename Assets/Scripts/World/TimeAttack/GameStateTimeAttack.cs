using UnityEngine;
using System.Collections;

public enum EGameStateTimeAttack
{
	DEFAULT,
	PLAYING,
	GAMEOVER
};

public class GameStateTimeAttack : GameState {
	public GameObject gameOverObject;

	public override void GoToState(int newState)
	{
		base.GoToState(newState);

		EGameStateTimeAttack switchState = (EGameStateTimeAttack)newState;

		switch (switchState)
		{
			case EGameStateTimeAttack.PLAYING:
				OnPlaying();
			break;
			case EGameStateTimeAttack.GAMEOVER:
				OnGameOver();
			break;
			default:
			case EGameStateTimeAttack.DEFAULT:
			break;
		}
	}

	void OnPlaying()
	{
		//do start stuff
	}

	void OnGameOver()
	{
		gameOverObject.SetActive(true);
	}
}
