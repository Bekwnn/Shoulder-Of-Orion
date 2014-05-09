using UnityEngine;
using System.Collections;

public class FiringScript : MonoBehaviour {

	public GameObject goldMelter;
	public GameObject iceCracker;
	public GameObject rockBreaker;
	private float fireRate;
	private float nextFire;
	public float delay;
	private string wepActive;

	void Start () {
		EquipRockBreaker();
	}
	
	// Update is called once per frame
	void Update () {
		//weapons:
		if (Input.GetButton("Fire1") && Time.time > nextFire && wepActive == "IceCracker")
		{
			nextFire = Time.time + fireRate;
			Instantiate(iceCracker, transform.position, transform.rotation);
		}
		else if (Input.GetButton("Fire1") && Time.time > nextFire && wepActive == "GoldMelter")
		{
			nextFire = Time.time + fireRate;
			Instantiate(goldMelter, transform.position, transform.rotation);
		}
		else if (Input.GetButton("Fire1") && Time.time > nextFire && wepActive == "RockBreaker")
		{
			nextFire = Time.time + fireRate;
			Instantiate(rockBreaker, transform.position, transform.rotation);
		}

		//switching weapons:
		if (Input.GetKeyDown("1")) {
			EquipIceCracker();
		}
		else if (Input.GetKeyDown("2")) {
			EquipGoldMelter();
		}
		else if (Input.GetKeyDown("3")) {
			EquipRockBreaker();
		}
	}

	//equip different weapons:
	void EquipIceCracker() {
		wepActive = "IceCracker";
		fireRate = 0.1f;
		Debug.Log(wepActive);
	}
	void EquipGoldMelter() {
		wepActive = "GoldMelter";
		fireRate = 0.02f;
		Debug.Log(wepActive);
	}
	void EquipRockBreaker() {
		wepActive = "RockBreaker";
		fireRate = 0.2f;
		Debug.Log(wepActive);
	}
}
