using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameState : MonoBehaviour {

    private UnityAction someListener;
    public int waveNum;
    public int[] enemiesPerWave;

	void Start () {
        someListener = new UnityAction(startWave);
        EventManager.StartListening(Mail.spawn, someListener);
        EventManager.TriggerEvent(Mail.spawn);
    }
    void startWave()
    {
        EnemySpawner.instance.spawnEnemy(enemiesPerWave[waveNum]);
        //print("test");
    }
    void waveCleared()
    {
        //open shop
    }
    public void shopClosed()
    {
        EventManager.TriggerEvent(Mail.spawn);
    }
    void endGame()
    {

    }
}
