using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

	// Update is called once per frame
	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy" || other.tag == "Enemy Shot") {
			Debug.Log("You have died.");
			Destroy(transform.parent.gameObject); //move to parent later
			/*lives--;
			if (lives > 0) {
				wait 3 seconds
				Respawn();
			}
			else {
				GameOver();
			}*/
		}
	}
}
