using UnityEngine;
using System.Collections;

public abstract class Health : MonoBehaviour, IHealth {
	public int currentHealth;

	abstract public void TakeDamage(int damage, EDamageType damageType);
}
