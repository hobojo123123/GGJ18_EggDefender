using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    float currentHealth = 100;

    public float maxHealth = 100;
    public float testDamage = 10;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}

    public void Damage (float _damage) {
        currentHealth -= _damage;
        if (currentHealth <= 0) {
            // Game Over

        }
    }

    public void AddHealth (float _addHealth) {
        // Check if the computed health is over maxHealth
        if ((currentHealth += _addHealth) > maxHealth) {
            currentHealth = maxHealth;
        } else {
            currentHealth += _addHealth;
        }
    }

    public float getCurrentHealth () {
        return currentHealth;
    }

    public void setCurrentHealth (float _newHealth) {
        currentHealth = _newHealth;
    }
}
