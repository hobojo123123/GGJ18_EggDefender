using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_FullAutoNoReloadBasic : WeaponSystemBase {

    float shotTimer;

    public GameObject projectile;
    public Transform firePoint;

	// Use this for initialization
	void Start () {
        //fireRate = 1;
        shotTimer = fireRate;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        ClickToShoot();
        InputManager();
        print(firePoint);
	}

    void ClickToShoot () {

        if (shotTimer < fireRate) {
            shotTimer += Time.deltaTime;
        } else {
            bCanShoot = true;
        }
        if (bWantsToShoot && bCanShoot) {
            shotTimer = 0;
            Shoot();
        }
    }

    void Shoot () {
        bCanShoot = false;
        if (firePoint != null) {
            Instantiate(projectile, firePoint.position, firePoint.rotation);
        } else {
            Instantiate(projectile, transform.position, transform.rotation);
        }
    }

    
}
