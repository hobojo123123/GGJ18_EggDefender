using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDrop : MonoBehaviour {

    float currentHealth;
    public float maxHealth = 100;
    public PowerUps powerUp;
    public float rotationSpeed = 10;
    PowerUpManager _powerUpManager;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        _powerUpManager = GameObject.FindObjectOfType<PowerUpManager>();
	}
	
	// Update is called once per frame
	void Update () {
        Rotate();
	}

    void Rotate () {
        transform.Rotate(new Vector3(transform.rotation.x, (transform.rotation.y + rotationSpeed) * Time.deltaTime, transform.rotation.z));
    }

    public void TakeDamage (float damage) {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            // Activate Power Up
            switch (powerUp) {
                case PowerUps.IncreaseSize:
                    _powerUpManager.IncreaseSizeOfEnemies(3, 10);
                    break;
                case PowerUps.DecreaseSpeed:
                    _powerUpManager.DecreaseSpeedOfEnemies(2, 10);
                    break;
            }

            // Die
            Destroy(gameObject);
        }
    }
}
