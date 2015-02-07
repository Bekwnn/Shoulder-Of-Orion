using UnityEngine;
using System.Collections;

public class PlayerHealth : Health {
	public int maxHealth = 1;

	void Awake()
	{
		currentHealth = maxHealth;
	}

	public override void TakeDamage(int damage, EDamageType damageType)
	{
		currentHealth -= damage;
		if (currentHealth <= 0)
			OnPlayerDeath();
	}

	void OnPlayerDeath()
	{
		Debug.Log ("Player died.");
		//do dying stuff
	}
}
