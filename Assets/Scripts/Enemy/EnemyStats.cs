using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IncreaseSize))]
public class EnemyStats : MonoBehaviour {
    //Enemy type, health, and speed in that order.
    public EnemyType type;
    public int health;
    public int maxHealth;
    public float originalSpeed;
    public float speed;
    public Vector3 originalSize;
    PowerUpManager powerupMan;
    private void Start()
    {
        powerupMan = GameObject.FindObjectOfType<PowerUpManager>();
        originalSize = transform.localScale;
        originalSpeed = speed;
        if(powerupMan != null)
        {
            powerupMan.AddToList(gameObject);
        }
    }

}
public enum EnemyType
{
    basic, instaKill, zigZag, tank, length
}
