using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDropRNG : MonoBehaviour {

    PowerUpManager _powerUpManager;

    [Header("Power Ups")]
    public GameObject increaseSizeOfEnemiesGO;
    public GameObject decreaseSpeedOfEnemiesGO;

    // Use this for initialization
    void Start () {
        _powerUpManager = GameObject.FindObjectOfType<PowerUpManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void RNG (float percentage, GameObject go) {
        float randomNumber = Random.Range(0, 100);
        if (percentage > randomNumber) {
            SpawnPowerUp(PowerUps.IncreaseSize, go);
        }
    }

    void PickPowerUp (GameObject go) {
        float randomNumber = Random.Range(0, 100);
        if (randomNumber > 50) {
            SpawnPowerUp(PowerUps.IncreaseSize, go);
        } else {
            SpawnPowerUp(PowerUps.DecreaseSpeed, go);
        }
    }

    void SpawnPowerUp (PowerUps powerUp, GameObject go) {
        switch (powerUp) {
            case PowerUps.IncreaseSize:
                Instantiate(increaseSizeOfEnemiesGO, go.transform.position, go.transform.rotation);
                break;
            case PowerUps.DecreaseSpeed:
                Instantiate(decreaseSpeedOfEnemiesGO, go.transform.position, go.transform.rotation);
                break;
        }
    }
}
