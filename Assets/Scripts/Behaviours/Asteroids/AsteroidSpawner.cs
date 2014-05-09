using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour {

	public GameObject rockAsteroid;
	public GameObject iceAsteroid;
	public GameObject goldAsteroid;
	private Vector3 spawnLocation;
	public float spawnRate;
	public float delay;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 10; i++) {
			SpawnAsteroid();
		}
		InvokeRepeating("SpawnAsteroid", delay, spawnRate);
		//Debug.Log(spawnLocation);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay(transform.position, spawnLocation);
	}

	void SpawnAsteroid () {
		spawnLocation = Random.onUnitSphere*16;
		//Debug.Log(spawnLocation);
		int rng = Random.Range(1,4);
		if (rng == 1) {
			Object.Instantiate(iceAsteroid, spawnLocation, Quaternion.identity);
			Debug.Log("Spawned ice asteroid.");
		}
		else if (rng == 2) {
			Object.Instantiate(goldAsteroid, spawnLocation, Quaternion.identity);
			Debug.Log("Spawned gold asteroid.");
		}
		else if (rng == 3) {
			Object.Instantiate(rockAsteroid, spawnLocation, Quaternion.identity);
			Debug.Log("Spawned rock asteroid.");
		}
	}
}
