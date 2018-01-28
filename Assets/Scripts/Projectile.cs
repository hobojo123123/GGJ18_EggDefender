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
	}
	
	void Update () {
		if (bActive) {
            GoForward();
        }
	}

    private void FixedUpdate() {
        if (bActive) {
            GoForward();
        } else {
            _rb.velocity = Vector3.zero;
        }
    }

    void GoForward () {
        _rb.AddForce((transform.forward * speed), ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("enemy")) {
            // insert code for enemy interaction here
            collision.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
        }
        Destroy(gameObject);
        // destroy - call pooling script
    }
}
