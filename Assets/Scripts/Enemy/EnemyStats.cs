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
    PowerUpDropRNG powerUpDropRNG;

    private void Start() {
        powerUpManager = GameObject.FindObjectOfType<PowerUpManager>();
        powerUpDropRNG = GameObject.FindObjectOfType<PowerUpDropRNG>();
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
            if (GetComponentInChildren<ParticleSystem>())
            {
                ParticleSystem particle = GetComponentInChildren<ParticleSystem>();
                particle.Play();
                particle.transform.parent = null;
                particle.transform.localScale = new Vector3(1, 1, 1);
                particle.GetComponent<DestroyParticle>().die();
            }
            GetComponent<EnemyMovement>().die();
            
            print("test");
        }
    }
}
public enum EnemyType
{
    basic, instaKill, zigZag, tank, length
}
