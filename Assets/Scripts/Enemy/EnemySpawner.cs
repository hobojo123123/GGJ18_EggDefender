using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public float width, height;
    
    public ObjectPooler ObjectPooler;
    public GameObject[] specialEnemy;

    public static EnemySpawner instance;
    private void Start()
    {
        if (instance == null || instance != this)
            instance = this;
    }
    public void spawnEnemy(int howMany)
    {
        StartCoroutine(addVariation(howMany));
    }
    IEnumerator addVariation(int howMany)
    {
        for (int a = 0; a < howMany; a++)
        {
            float w = Random.Range(-(width / 2), width / 2);
            float h = Random.Range(-(height / 2), height / 2);

            Vector3 pos = new Vector3(transform.position.x + w, transform.position.y + h, 350);

            int diceRoll = Random.Range(0, 5);
            if(diceRoll == 0)
            {
                diceRoll = Random.Range(0, 3);
                Instantiate(specialEnemy[diceRoll], pos, Quaternion.identity, transform);
            }
            else
            {
                ObjectPooler.CallPool(pos);
            }

            yield return new WaitForSeconds(Random.Range(0.5f, 1));
            if (a % 5 == 0)
                yield return new WaitForSeconds(Random.Range(1, 2));
            
        }
    }
}
