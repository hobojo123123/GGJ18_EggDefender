using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public float width, height;
    
    public ObjectPooler ObjectPooler;
    public void spawnEnemy(int howMany)
    {
        for (int a = 0; a < howMany; a++)
        {
            float w = Random.Range(-(width / 2), width / 2);
            float h = Random.Range(-(height / 2), height / 2);

            Vector2 pos = new Vector2(w, h);

            ObjectPooler.CallPool(pos);

            int sex = Random.Range(0, 1);
        }
    }
}
