using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Projectile : MonoBehaviour {

    public float speed;
    public bool bActive;

    Rigidbody _rb;

	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody>();
        _rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
	}
	
	// Update is called once per frame
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
        // needs to be changed to the enemy layer
        if (collision.gameObject.layer == 6) {
            // insert code for enemy interaction here

        }
        // destroy - call pooling script
    }
}
