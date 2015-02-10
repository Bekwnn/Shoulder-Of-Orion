using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	/* Player controller handles player input and allows the player to
	 * possess 'pawns' or do things when not possessing a pawn
	 */
	bool bBlockInput;
	public GameObject possessedPawn { get; private set; }
	public GameObject playerCamera;
	public GameObject pauseObject;

	public void Possess(GameObject pawn)
	{
		//destroy old possession
		if (possessedPawn)
			Object.Destroy(possessedPawn.GetComponent<Possession>());

		//create new possession
		possessedPawn = pawn;
		(pawn.AddComponent<Possession>()).OnPossessed(this);

		//update camera target
		PlayerCamera cam = playerCamera.GetComponent<PlayerCamera>();
		if (cam) cam.SetTarget(pawn.transform);
	}

	public void DestroyPossessed()
	{
		Destroy(possessedPawn);
		possessedPawn = null;
	}

	public void Update()
	{
		//toggle pause
		if (Input.GetButtonDown("Pause") && pauseObject)
		{
			if (pauseObject.activeInHierarchy) pauseObject.SetActive(false);
			else pauseObject.SetActive(true);
		}
	}
}
