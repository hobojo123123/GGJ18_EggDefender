using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IncreaseSize))]
public class EnemyStats : MonoBehaviour {
    //Enemy type, health, and speed in that order.
    public EnemyType type;
    public float health;
    public float maxHealth;
    public int speed;
    public Vector3 originalSize;
    public int originalSpeed;

    PowerUpManager powerUpManager;

    private void Start() {
        powerUpManager = GameObject.FindObjectOfType<PowerUpManager>();
        originalSize = transform.localScale;
        originalSpeed = speed;
        if (powerUpManager != null) {
            powerUpManager.AddToList(gameObject);
        }
    }

    public void TakeDamage (float damage) {
        health -= damage;
        if (health <= 0) {
            // Die
            GetComponent<EnemyMovement>().die();
        }
    }
}
public enum EnemyType
{
    basic, instaKill, zigZag, tank, length
}
