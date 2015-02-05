using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {
	/* Player camera manager 
	 */
	public Transform lookAtTarget;
	public Transform hoverAboveTarget;
	public float lerpSpeed;


	void LateUpdate()
	{
		transform.position = hoverAboveTarget.transform.position * 2;

		transform.rotation = Quaternion.LookRotation(
			lookAtTarget.position - transform.position,
			hoverAboveTarget.up
		);
	}

	public void SetTarget(Transform target)
	{
		lookAtTarget = target;
		hoverAboveTarget = target;
	}
}
