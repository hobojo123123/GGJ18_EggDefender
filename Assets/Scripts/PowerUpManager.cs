using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {


    List<GameObject> _enemies = new List<GameObject>();
    

    private void Start() {
    }

    // Increase the size of all enemies in a layer add lerp
    public void IncreaseSizeOfEnemies (int scaleMultiplier, float powerUpTime) {
        foreach (GameObject go in _enemies) {
            // increase size
            go.GetComponent<IncreaseSize>().StartIncreaseLerp(scaleMultiplier);
            StartCoroutine(PowerUpTimer(powerUpTime, PowerUps.IncreaseSize));
        }
    }

    // Revert enemies back to original size
    void RevertIncreaseSizeOfEnemies () {
        foreach (GameObject go in _enemies) {
            if (go.GetComponent<EnemyStats>() != null) {
                go.GetComponent<IncreaseSize>().StartDecreaseLerp();
            }
        }
    }

    // Decrease the speed of all enemies in a layer lerp speed
    public void DecreaseSpeedOfEnemies (int speedDivider, float powerUpTime) {
        foreach (GameObject go in _enemies) {
            if (go.GetComponent<EnemyStats>() != null) {
                // decrease speed
                go.GetComponent<EnemyStats>().speed /= speedDivider;
            }
            StartCoroutine(PowerUpTimer(powerUpTime, PowerUps.DecreaseSpeed));
        }
    }

    // Revert enemies speed back to original
    void RevertDecreaseSpeedOfEnemies () {
        foreach (GameObject go in _enemies) {
            // Revert back to original speed
            if (go.GetComponent<EnemyStats>() != null) {
                go.GetComponent<EnemyStats>().speed = go.GetComponent<EnemyStats>().originalSpeed;
            }
        }
    }

    public void AddToList (GameObject go) {
        _enemies.Add(go);
    }

    public void RemoveFromList (GameObject go) {
        _enemies.Remove(go);
    }

    IEnumerator PowerUpTimer (float timer, PowerUps powerUpType) {
        yield return new WaitForSeconds(timer);
        switch (powerUpType) {
            case PowerUps.IncreaseSize:
                RevertIncreaseSizeOfEnemies();
                break;
            case PowerUps.DecreaseSpeed:
                RevertDecreaseSpeedOfEnemies();
                break;
        }
    }
}
public enum PowerUps { IncreaseSize, DecreaseSpeed };