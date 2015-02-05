using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int maxHealth = 1;
	public int health = 1;

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy" || other.tag == "Enemy Shot") {
			health--;
			if (health <= 0)
			{
				Debug.Log("Player died.");
				Possession pos = transform.root.gameObject.GetComponent<Possession>();
				if (pos) pos.playerController.DestroyPossessed();
				else Destroy(transform.root.gameObject);
			}
		}
	}
}
