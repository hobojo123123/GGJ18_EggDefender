using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public float width, height;
    
    public ObjectPooler ObjectPooler;

    public static EnemySpawner instance;
    private void Start()
    {
        if (instance == null || instance != this)
            instance = this;
    }
    public void spawnEnemy(int howMany)
    {
        for (int a = 0; a < howMany; a++)
        {
            float w = Random.Range(-(width / 2), width / 2);
            float h = Random.Range(-(height / 2), height / 2);

            Vector3 pos = new Vector3(transform.position.x + w, transform.position.y + h, 350);

            ObjectPooler.CallPool(pos);
        }
    }
}
