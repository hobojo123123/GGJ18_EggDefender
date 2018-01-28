using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

    private UnityAction someListener;
    public int waveNum;
    public int[] enemiesPerWave;
    int time = 45;

    public static GameState instance;

	void Start () {
        if (instance == null)
            instance = this;
        DontDestroyOnLoad(this);
        someListener = new UnityAction(startWave);
        EventManager.StartListening(Mail.spawn, someListener);
        EventManager.TriggerEvent(Mail.spawn);
    }
    IEnumerator timer()
    {
        yield return new WaitForSeconds(time);
        time *= 2;
        waveCleared();
    }
    void startWave()
    {
        EnemySpawner.instance.spawnEnemy(enemiesPerWave[waveNum++]);
        //print("test");
        StartCoroutine(timer());
    }
    void waveCleared()
    {
        if (waveNum == 5)
            Application.Quit();
        else
            SceneManager.LoadScene(2);
        //open shop
    }
    public void shopClosed()
    {
        startWave();
    }
    void endGame()
    {

    }
}
