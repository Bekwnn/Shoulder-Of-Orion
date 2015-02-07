using UnityEngine;
using System.Collections;

public interface IHealth {
	void TakeDamage(int damage, EDamageType damageType);
}
