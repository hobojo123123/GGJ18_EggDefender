using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    float currentHealth = 100;
    UpdateHealthUI updateHealthUI;

    public float maxHealth = 100;
    public float testDamage = 10;

    public Color flashColor;
    private float flashSpeed = 5f;

    bool isDamaged;
    public Image damageImage;

    public GameObject gameOverScript;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        updateHealthUI = GameObject.FindObjectOfType<UpdateHealthUI>();
        isDamaged = false;

    }

    private void Update() {
        if (isDamaged) {
            damageImage.color = flashColor;
        }
        else {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        isDamaged = false;
    }

    public void Damage (float _damage) {
        isDamaged = true;
        currentHealth -= _damage;
        updateHealthUI.UpdateHealth(currentHealth);
        SoundEvents.Instance.Play("PLAYER_PAIN_v1_test", false);
        CameraShake.Shake(0.2f, 1f);

        if (currentHealth <= 0) {
            // Game Over
            Debug.Log("You r dead.");
            gameOverScript.SetActive(true);
            Time.timeScale = 0;
            SoundEvents.Instance.Play("LEVEL_FAILED_v1_test", false);
        }

    }

    IEnumerator waitToDestroy() {
        yield return new WaitForSeconds(5);
        Application.Quit();
    }

    public void AddHealth (float _addHealth) {
        // Check if the computed health is over maxHealth
        if ((currentHealth += _addHealth) > maxHealth) {
            currentHealth = maxHealth;
        } else {
            currentHealth += _addHealth;
        }
        updateHealthUI.UpdateHealth(currentHealth);
    }

    public float getCurrentHealth () {
        return currentHealth;
    }

    public void setCurrentHealth (float _newHealth) {
        currentHealth = _newHealth;
    }
}
