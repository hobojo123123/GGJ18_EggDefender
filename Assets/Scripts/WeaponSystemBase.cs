using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystemBase : MonoBehaviour {

    [Header("Stats")]
    [Tooltip("How fast the gun spits out bullets")]
    // How fast the gun spits out bullets
    public float fireRate;
    [Tooltip("How accurate the bullets will go to where the player is pointing")]
    // How accurate the bullets will go to where the player is pointing
    public float accuracy;
    [Tooltip("How much damage does each bullet do.")]
    // How much damage does each bullet do.
    public float damage;
    [Tooltip("How far the bullets go.")]
    // How far the bullets go.
    public float range;
    [Tooltip("If the gun shoots projectiles; if not, it shoots raycasts")]
    // If the gun shoots projectiles; if not, it shoots raycasts
    public bool bProjectile;
    [Tooltip("If the gun shoots more than 1 bullet")]
    // If the gun shoots more than 1 bullet
    public bool bShotGunEffect;

    [Header("Projectile")]
    [Tooltip("How fast the bullets move, only applies to projectiles.")]
    // How fast the bullets move, only applies to projectiles.
    public float bulletSpeed;
    [Tooltip("How big the bullets are, only applies to projectiles.")]
    // How big the bullets are, only applies to projectiles.
    public float bulletSize;
    [Tooltip("What firemode the gun has.")]
    // What firemode the gun has.
    public FireMode fireModeType;
    [Header("Reload")]
    [Tooltip("Does the gun need to reload.")]
    // Does the gun need to reload.
    public bool bNeedsToReload;
    [Tooltip("If the gun does need to reload, how long does it take?")]
    // If the gun does need to reload, how long does it take?
    public float reloadTime;


    protected bool bWantsToShoot;
    protected bool bWantsToReload;
    protected bool bCanShoot = true;

	// Use this for initialization
	void Start () {
        Initialization();
	}
	
	// Update is called once per frame
	void Update () {
        EveryFrame();
	}

    protected virtual void Initialization () {

    }

    protected virtual void EveryFrame () {
        InputManager();
    }

    protected virtual void InputManager () {

        // Shoot
        if (Input.GetKey(KeyCode.Mouse0)) {
            bWantsToShoot = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0)) {
            bWantsToShoot = false;
        }

        // Reload
        if (Input.GetKey(KeyCode.R)) {
            bWantsToReload = true;
        }
        if (Input.GetKeyUp(KeyCode.R)) {
            bWantsToReload = false;
        }
    }
}

public enum FireMode { Semi, Burst, FullAuto }
