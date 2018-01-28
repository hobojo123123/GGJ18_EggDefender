using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour {

	// Use this for initialization
	public void die() { 
        StartCoroutine(destroyAfterPause());
	}
    IEnumerator destroyAfterPause()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
