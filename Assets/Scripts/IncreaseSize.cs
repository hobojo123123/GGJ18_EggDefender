using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSize : MonoBehaviour {

    [HideInInspector]
    public bool bIsLerpingSize;

    public float lerpSpeedMultiplier = 1;

    Vector3 destinationScale;
    float scaleMultiplier;
    Vector3 originalSize;

    float lerpTimer = 0;

	// Use this for initialization
	void Start () {
        originalSize = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        LerpSize();
	}

    void LerpSize () {

        if (bIsLerpingSize) {
            lerpTimer += Time.deltaTime;
            // Check if scale is close enough; if so, keep lerping, if not, stop lerping.
            if ((Mathf.Abs(transform.localScale.x - destinationScale.x)) >= 0) {
                transform.localScale = Vector3.Lerp(transform.localScale, destinationScale, lerpTimer * lerpSpeedMultiplier);
            }
            // if the scale has reaced destinationScale, turn of bIsLerpingSize.
            else {
                bIsLerpingSize = false;
                lerpTimer = 0;
            }
        }
    }

    public void StartIncreaseLerp (float _scaleMultiplier) {
        lerpTimer = 0;
        scaleMultiplier = _scaleMultiplier;
        destinationScale = new Vector3 (originalSize.x * scaleMultiplier, originalSize.y* scaleMultiplier, originalSize.z* scaleMultiplier);
        bIsLerpingSize = true;
    }

    public void StartDecreaseLerp () {
        lerpTimer = 0;
        destinationScale = originalSize;
        bIsLerpingSize = true;
    }
}
