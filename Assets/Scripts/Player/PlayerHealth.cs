using UnityEngine;
using System.Collections;

public class PlayerHealth : Health {
	public int maxHealth = 1;
	public bool bIsInvulnerable;
	float isInvulnerableTimer;

	void OnEnable()
	{
		currentHealth = maxHealth;
		MakeInvulnerable(2);
	}

	public override void TakeDamage(int damage, EDamageType damageType)
	{
		if (bIsInvulnerable) return;

		currentHealth -= damage; //player doesn't care about damage types

		if (currentHealth <= 0)
			OnPlayerDeath();
	}

	void OnPlayerDeath()
	{
		Debug.Log ("Player died.");
		GameInstance.instance.aGameMode.RespawnPlayer(transform.position, transform.rotation);
	}

	public void MakeInvulnerable(float duration)
	{
		isInvulnerableTimer = duration;
		bIsInvulnerable = true;
	}

	void Update()
	{
		if (bIsInvulnerable)
		{
			isInvulnerableTimer -= Time.deltaTime;
			if (isInvulnerableTimer <= 0) bIsInvulnerable = false;
		}
	}
}
