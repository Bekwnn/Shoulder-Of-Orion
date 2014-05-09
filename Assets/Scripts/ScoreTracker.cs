using UnityEngine;
using System.Collections;

public class ScoreTracker : MonoBehaviour {

	private static int score;
	private static int multiplier;
	private static float multiplierThreshold;
	private static float multiplierRamp;
	private static float decay; // higher = slower

	// Use this for initialization
	void Start () {
		score = 0;
		multiplier = 1;
		multiplierThreshold = 0f;
		multiplierRamp = 10f;
		decay = 5f;
	}

	void OnGUI () {
		GUI.Label(new Rect(10, 0, 100, 20), "Score: " + score.ToString());
		GUI.Label(new Rect(10, 20, 100, 20), "Multiplier: " + multiplier.ToString());
		float thresholdPercent = (multiplierThreshold/multiplier)*10;
		GUI.Label(new Rect(10, 40, 100, 20), thresholdPercent.ToString() + "%");
	}

	void Update () {
		if (multiplierThreshold > 0) {
			multiplierThreshold -= Time.deltaTime*multiplierRamp*multiplier/decay;
		}

		if (multiplierThreshold <= 0 && multiplier > 1) {
			multiplier = multiplier/2;
			multiplierThreshold = multiplier*multiplierRamp;
		}
	}
	
	public static void IncreaseScore(int amount) {
		score += amount*multiplier;
		multiplierThreshold += amount;
		if (multiplierThreshold > multiplierRamp*multiplier) {
			multiplierThreshold %= multiplierRamp*multiplier;
			multiplier = multiplier*2;
		}
		//Debug.Log(score);
	}
}
