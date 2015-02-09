using UnityEngine;
using System.Collections;

public class SpawnedObject : MonoBehaviour {
	public Spawner spawner;
	public int numberOfChildInstances;	//used to keep track of things which break apart or spawn others

	//all children dead, kill manager and notify spawner
	public void DestroySpawnedObject()
	{
		spawner.SignalDestroyed ();
		Destroy(gameObject);
	}

	//child destroyed, decrement child instances count
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
