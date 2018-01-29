using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystemBase : MonoBehaviour {

    [Header("Stats")]
    [Tooltip("How fast the gun spits out bullets")]
    // How fast the gun spits out bullets. The lower, the faster
    public float fireRate;
    [Tooltip("How accurate the bullets will go to where the player is pointing")]
    // How accurate the bullets will go to where the player is pointing
    public float accuracy;
    [Tooltip("How much damage does each bullet do.")]
    // How much damage does each bullet do.
    public float bulletDamage;
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

    [Header("Sound")]
    public AudioClip gunShot;

    [Header("Misc")]
    public Transform firePoint;
    public GameObject projectile;


    protected bool bWantsToShoot;
    protected bool bWantsToReload;
    protected bool bCanShoot = true;
    protected float shotTimer;

    private int leftOrRightShootNext;

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
        ClickToShoot();
        ShotTimer();
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

    protected virtual void ClickToShoot () {

        if (bWantsToShoot && bCanShoot) {
            switch (fireModeType) {

                case FireMode.Semi:
                    Shoot();
                    break;

                case FireMode.Burst:

                    break;

                case FireMode.FullAuto:
                    Shoot();
                    break;
            }
        }
    }

    protected virtual void ShotTimer () {
        if (shotTimer < fireRate) {
            shotTimer += Time.deltaTime;
        }
        else {
            switch (fireModeType) {

                case FireMode.Semi:
                    if (!bWantsToShoot) {
                        bCanShoot = true;
                    }
                    break;
                case FireMode.Burst:

                    break;
                case FireMode.FullAuto:
                    bCanShoot = true;
                    break;
            }
        }
    }

    protected virtual void Shoot () {
        shotTimer = 0;
        bCanShoot = false;
        if (bProjectile) {
            GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation) as GameObject;
            SetBulletParams(bullet);
        } else {
            // Raycast
        }
        //Animation Logic
        Animator[] anims = transform.GetComponentsInChildren<Animator>();
        anims[leftOrRightShootNext].SetTrigger("Fire");

        //Particle Logic
        anims[leftOrRightShootNext].transform.GetComponentInChildren<ParticleSystem>().Emit(Random.Range(15,20));

        //Light Logic
        anims[leftOrRightShootNext].GetComponentInChildren<Light>().intensity = 7;
        StartCoroutine(turnDownFlashThenOff(anims[leftOrRightShootNext].GetComponentInChildren<Light>()));

        if (leftOrRightShootNext == 1) leftOrRightShootNext = 0;
        else leftOrRightShootNext = 1;

        SoundEvents.Instance.Play("PLAYER_FIRE_SINGLE_v1_test", false);
    }

    IEnumerator turnDownFlashThenOff(Light light)
    {
        while (light.intensity > 0.01f)
        {
            yield return new WaitForEndOfFrame();
            light.intensity = Mathf.Lerp(light.intensity, 0, .1f);
        }
    }

    protected virtual void SetBulletParams (GameObject _bullet) {
        Projectile _projectile = _bullet.GetComponent<Projectile>();
        _projectile.damage = bulletDamage;
        _projectile.speed = bulletSpeed;
        _projectile.size = bulletSize;
        _projectile.range = range;
    }
}

public enum FireMode { Semi, Burst, FullAuto }
