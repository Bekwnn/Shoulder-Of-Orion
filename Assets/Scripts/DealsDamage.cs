using UnityEngine;
using System.Collections;

public enum EDamageType
{
	NONE,
	ROCK,
	GOLD,
	ICE
};

public class DealsDamage : MonoBehaviour {
	public int damage;
	public EDamageType damageType;
}
