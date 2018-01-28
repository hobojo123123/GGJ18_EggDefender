using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Projectile : MonoBehaviour {

    public float speed;
    public float damage;
    public float size;
    public float range;
    public bool bActive;

    Rigidbody _rb;
    
	void Start () {
        _rb = GetComponent<Rigidbody>();
        _rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        transform.localScale = new Vector3(size, size, size);
        GoForward();
    }

    /*
    private void FixedUpdate() {
        if (bActive) {
            GoForward();
        } else {
            _rb.velocity = Vector3.zero;
        }
    }
    */

    void GoForward () {
        _rb.AddForce((transform.forward * speed), ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("enemy")) {
            // insert code for enemy interaction here
            if(collision.gameObject.GetComponent<EnemyStats>())
                collision.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
            if (collision.gameObject.GetComponent<PowerUpDrop>())
                collision.gameObject.GetComponent<PowerUpDrop>().TakeDamage(damage);
        }
        Destroy(gameObject);
        // destroy - call pooling script
    }
}
