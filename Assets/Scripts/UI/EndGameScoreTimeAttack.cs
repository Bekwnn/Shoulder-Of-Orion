using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGameScoreTimeAttack : MonoBehaviour {
	public Text text;
	public GameObject newHighScoreEffect;
	
	void OnEnable()
	{
		text.text = "Score: " + GameInstance.instance.aGameMode.score;
		if (GameInstance.instance.aGameMode.score != GameInstance.instance.timeAttackHighScore)
			newHighScoreEffect.SetActive(false);
	}
}
