using UnityEngine;
using System.Collections;

public class AsteroidHealth : MonoBehaviour {
	public GameObject managerObj;
	SpawnedObject manager;

	public int maxHealthAverage;
	public int maxHealthVariance;
	public EDamageType weakAgainst;
	int startingHealth;
	int currentHealth;

	void Start()
	{
		if (managerObj)
			manager = managerObj.GetComponent<SpawnedObject>();

		startingHealth = (int)Random.Range(
			maxHealthAverage-maxHealthVariance, maxHealthAverage+maxHealthVariance);
		currentHealth = startingHealth;

		transform.localScale = transform.localScale*(currentHealth/100f);
	}

	void OnCollisionEnter(Collision other)
	{
		DealsDamage otherHarm = other.gameObject.GetComponent<DealsDamage>();
		if (otherHarm)
		{
			int damageTaken = (int)((weakAgainst == otherHarm.damageType)?
				otherHarm.damage * 1.5f : otherHarm.damage);
			currentHealth -= damageTaken;
			OnHealthChange();
		}
	}

	void OnDestroy()
	{
		if (manager) manager.ChildDestroyed();
		else Destroy(gameObject);
	}

	void OnHealthChange()
	{
		if (currentHealth <= 1 && startingHealth < 120)
		{
			OnDestroy();
		}
		if (currentHealth <= startingHealth/2 && currentHealth > 20)
		{
			startingHealth = currentHealth;

			GameObject gObj = (GameObject)Instantiate(gameObject);
			if (manager)
			{
				manager.ChildCreated();	//signal to parent there's another asteroid
				gObj.transform.parent = transform.parent;
			}

			transform.localScale = transform.localScale*(startingHealth/100f);
			transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
		}
	}
}
