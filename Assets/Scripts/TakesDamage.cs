using UnityEngine;
using System.Collections;

public class TakesDamage : MonoBehaviour {
	public bool bTempInvulnerable;
	public string[] ignoreLayers;
	public Health healthScript;

	public void OnTriggerEnter(Collider other)
	{
		DealsDamage dealer = other.GetComponent<DealsDamage>();
		if (dealer)
		{
			foreach (string aLayer in ignoreLayers)
			{
				if (other.gameObject.layer == LayerMask.NameToLayer(aLayer))
				{
					Debug.Log ("Ignored Layer!");
					return;
				}
			}
			healthScript.TakeDamage(dealer.damage, dealer.damageType);
		}
	}
}
