using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	/* Spawns enemies or asteroids
	 */
	public GameObject spawnedObject;
	public int maxConcurrent;
	public int maxLifetimeSpawns;
	public float spawnCooldown;
	int currentSpawned;
	int totalSpawned;
	float timer;

	void Update()
	{
		timer -= Time.deltaTime;
		if (timer < 0f) timer = 0f;

		while ((currentSpawned < maxConcurrent || maxConcurrent == 0)
		       && (totalSpawned < maxLifetimeSpawns || maxLifetimeSpawns == 0)
		       && timer == 0f)
		{
			timer += spawnCooldown;
			GameObject gobj = (GameObject)Instantiate(spawnedObject);
			SpawnedObject spawnProperty = gobj.AddComponent<SpawnedObject>();
			spawnProperty.spawner = this;
			totalSpawned++;
			currentSpawned++;
		}
	}

	// lets astroids signal to decrease the current spawn count
	public void SignalDestroyed()
	{
		currentSpawned--;
	}
}
