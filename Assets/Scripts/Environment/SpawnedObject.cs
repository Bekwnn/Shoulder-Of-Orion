using UnityEngine;
using System.Collections;

public class SpawnedObject : MonoBehaviour {
	public Spawner spawner;
	int numberOfChildInstances;	//used to keep track of things which break apart or spawn others

	public void DestroySpawnedObject()
	{
		spawner.SignalDestroyed ();
		Destroy(gameObject);
	}

	public void ChildDestroyed()
	{
		numberOfChildInstances--;
		if (numberOfChildInstances <= 0)
			DestroySpawnedObject();
	}

	public void ChildCreated()
	{
		numberOfChildInstances++;
	}


}
