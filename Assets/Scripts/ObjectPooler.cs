using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPooler : MonoBehaviour
{
    public string PooledObjectName;
    public int Count;
    public GameObject PooledObject, PooledObject2;
    List<GameObject> Pool;
    ObjectPooler pooler;
    private void Start()
    {
        CreatePool(this.gameObject);
    }
    void CreatePool(GameObject pooler)
    {
        Pool = new List<GameObject>();
        for(int i = 0; i < Count; i++)
        {
            int rnd = 0;
            if (pooler.layer == LayerMask.NameToLayer("enemy"))
            {
                rnd = Random.Range(0, 1);
            }
            GameObject clone;
            if (rnd == 1)
            {
                clone = (GameObject)Instantiate(PooledObject2);
            }
            else
            {
                clone = (GameObject)Instantiate(PooledObject);
            }
            clone.name = PooledObjectName + i;
            Pool.Add(clone);
            Pool[i].transform.parent = pooler.transform;
            Pool[i].SetActive(false);
        }
    }

    public void CallPool(Vector3 position)
    {
        if (Pool.Count == 0)
            return;
        
        for(int i = 0; i < Pool.Count; i++)
        {
            if (!Pool[i].activeInHierarchy)
            {
                Pool[i].transform.position = position;  
                Pool[i].SetActive(true);
                return;
            }
        }
    }
    public void disableObject(GameObject obj)
    {
        int num = Pool.IndexOf(obj);
        Pool[num].transform.position = new Vector3(0, 0, 0);
        if (obj.GetComponent<EnemyStats>())
        {
            Pool[num].GetComponent<EnemyStats>().speed = Pool[num].GetComponent<EnemyStats>().originalSpeed;
            Pool[num].GetComponent<EnemyStats>().health = Pool[num].GetComponent<EnemyStats>().maxHealth;
            transform.localScale = Pool[num].GetComponent<EnemyStats>().originalSize;
        }
        Pool[num].SetActive(false);
    }
}
