using UnityEngine;
using System.Collections;

public class MouseLookat : MonoBehaviour {
	private Vector3 mousePos;
	
	// Update is called once per frame
	void Update () {
		UpdateAiming();
	}

	public void UpdateAiming()
	{
		mousePos =
			transform.parent.up*(Input.mousePosition.y - Screen.height/2) +
				transform.parent.right*(Input.mousePosition.x - Screen.width/2);
		//up is always away from the origin: keep planet centered at 0,0,0 always
		transform.rotation = Quaternion.LookRotation(mousePos, gameObject.transform.position);
	}
}
