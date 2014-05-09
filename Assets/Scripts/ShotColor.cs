using UnityEngine;
using System.Collections;

public class ShotColor : MonoBehaviour {

	public string spawnColor;

	// Use this for initialization
	void Start () {
		if (spawnColor == "blue") {
			renderer.material.color = Color.blue;
		}
		else if (spawnColor == "red") {
			renderer.material.color = Color.red;
		}
		else if (spawnColor == "green") {
			renderer.material.color = Color.green;
		}
	}
}
