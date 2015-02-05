using UnityEngine;
using System.Collections;

public enum EWeapon {
	NONE,
	ROCKBLASTER,
	GOLDMELTER,
	ICECRUSHER
};

[RequireComponent(typeof(RockBlaster))]
[RequireComponent(typeof(GoldMelter))]
[RequireComponent(typeof(IceCrusher))]

public class Equipment : MonoBehaviour {

	public EWeapon eCurrentWeapon { get; private set; }
	Weapon currentWeapon;
	private float cooldownTimer;

	// Use this for initialization
	void Start () {
		EquipWeapon(EWeapon.ROCKBLASTER);
	}

	void Update()
	{
		if (cooldownTimer > 0.0)
			cooldownTimer -= Time.deltaTime;

		if (Input.GetButton("Fire1") && cooldownTimer <= 0.0)
		{
			currentWeapon.Fire();
			cooldownTimer = currentWeapon.cooldown;
		}

		if (Input.GetKeyDown("1")) { EquipWeapon(EWeapon.ROCKBLASTER); }
		if (Input.GetKeyDown("2")) { EquipWeapon(EWeapon.GOLDMELTER); }
		if (Input.GetKeyDown("3")) { EquipWeapon(EWeapon.ICECRUSHER); }
	}
	
	// Update is called once per frame
	void EquipWeapon(EWeapon eWeapon)
	{
		eCurrentWeapon = eWeapon;
		switch (eWeapon)
		{
		case EWeapon.ROCKBLASTER:
			currentWeapon = GetComponent<RockBlaster>();
			break;
		case EWeapon.GOLDMELTER:
			currentWeapon = GetComponent<GoldMelter>();
			break;
		case EWeapon.ICECRUSHER:
			currentWeapon = GetComponent<IceCrusher>();
			break;
		case EWeapon.NONE:
		default:
			break;

		}
	}
}
