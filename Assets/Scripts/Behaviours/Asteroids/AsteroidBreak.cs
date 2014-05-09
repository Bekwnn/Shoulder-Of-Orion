using UnityEngine;
using System.Collections;

public class AsteroidBreak : MonoBehaviour {
	
	public int startingHealth;
	private int health;		//should be around 150
	private int rng;
	public string asteroidType;

	void Start () {
		health = startingHealth;
		transform.localScale = transform.localScale*(startingHealth/100f);
		Debug.Log(startingHealth/100f);
	}

	void OnTriggerEnter (Collider other){	//WARNING: RUNS ON SPAWN
		//different shot damages
		if (other.tag == "IceBreaker") {
			if (asteroidType == "Ice") {
				health -= 10;
				//Debug.Log("Right weapon!");
			}
			else {
				health -= 5;
				//Debug.Log("Wrong weapon!");
			}
			CheckAfterDamage();
		}
		else if (other.tag == "GoldMelter") {
			if (asteroidType == "Gold") {
				health -= 2;
				//Debug.Log("Right weapon!");
			}
			else {
				health -= 1;
				//Debug.Log("Wrong weapon!");
			}
			CheckAfterDamage();
		}
		else if (other.tag == "RockBreaker") {
			if (asteroidType == "Rock") {
				health -= 20;
				//Debug.Log("Right weapon!");
			}
			else {
				health -= 10;
				//Debug.Log("Wrong weapon!");
			}
			CheckAfterDamage();
		}
	}

	private void CheckAfterDamage() {
		if (health <= 1 && startingHealth < 120) { //replace startingHealth < 120 with brief delay after spawn
			ScoreTracker.IncreaseScore(startingHealth - health);
			Destroy(gameObject);
		}
		if (health <= startingHealth/2 && health > 20) {
			ScoreTracker.IncreaseScore(startingHealth - health);
			startingHealth = health;
			Instantiate(gameObject);
			transform.localScale = transform.localScale*(startingHealth/100f);
			transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
		}
	}
}
