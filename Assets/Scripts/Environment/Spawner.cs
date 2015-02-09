using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	/* Spawns enemies or asteroids
	 */
	public GameObject spawnedObject;
	public int maxConcurrent;
	public int minConcurrent;
	public int maxLifetimeSpawns;
	public float spawnCooldown;
	int currentSpawned;
	int totalSpawned;
	float timer;

	void Update()
	{
		timer -= Time.deltaTime;
		if (timer < 0f) timer = 0f;

		/* maxLifetime: number of lifetime spawns is absolute. (0 = inf)
		 * minConcurrent: overrides maxConcurrent and the timer to make sure the minimum
		 * number of spawns are in play
		 * maxConcurrent: overrides the respawn timer to make sure no more than the max
		 * number of spawns are in play at once (0 = inf)
		 * timer: freezes at 'ready to spawn' until above conditions are met timer starts
		 * immediately after a spawn
		 */
		while ((totalSpawned < maxLifetimeSpawns || maxLifetimeSpawns == 0)
		       && (((currentSpawned < maxConcurrent || maxConcurrent == 0) && timer == 0f)
		       		|| currentSpawned < minConcurrent)
			   )
		{
			GameObject gobj = ObjectPool.instance.GetObjectForType(spawnedObject.name, true);
			if (gobj == null) return;

			timer += spawnCooldown;

			Vector3 spawnPosition = Random.onUnitSphere * 16;
			gobj.transform.position = spawnPosition;
			gobj.transform.rotation = Quaternion.Euler(spawnPosition);

			GameObject manager = new GameObject(gobj.name + "Manager");
			gobj.transform.parent = manager.transform;

			SpawnedObject spawnProperty = manager.AddComponent<SpawnedObject>();
			spawnProperty.spawner = this;
			spawnProperty.ChildCreated();

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
