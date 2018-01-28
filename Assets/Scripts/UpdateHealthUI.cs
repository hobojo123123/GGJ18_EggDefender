using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHealthUI : MonoBehaviour {

    Health health;
    Image hpImage;

   	// Use this for initialization
	void Start () {
        health = GameObject.FindObjectOfType<Health>();
        hpImage = GetComponent<Image>();
	}

    public void UpdateHealth (float currentPlayerHealth) {
        hpImage.fillAmount = currentPlayerHealth / health.maxHealth;
    }
}
