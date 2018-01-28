using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {
    //Enemy type, health, and speed in that order.
    public EnemyType type;
    public int health;
    public float originalSpeed;
    public float speed;
    public Vector3 originalSize;
    
}
public enum EnemyType
{
    basic, instaKill, zigZag, tank, length
}
