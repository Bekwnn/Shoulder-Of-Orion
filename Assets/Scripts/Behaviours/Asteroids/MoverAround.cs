using UnityEngine;
using System.Collections;

public class MoverAround : MonoBehaviour {

	private Transform orbitTarget;
	public float minSpeed;
	public float maxSpeed;
	private float speed;

	// Use this for initialization
	void Start () {
		//animation.Play("clip");
		//yield WaitForSeconds(animation["clip"].length);
		transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
		orbitTarget = GameObject.Find("Planet").transform; //add check and error message if planet not found
		speed = Random.Range(minSpeed, maxSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(orbitTarget.position, transform.up, speed*Time.deltaTime);
	}
}
