using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreTextSurvival : MonoBehaviour {
	public Text text;

	void Awake()
	{
		if (text == null) text = GetComponent<Text>();
	}

	void OnEnable()
	{
		text.text = "High Score: " + GameInstance.instance.survivalHighScore;
	}
}
