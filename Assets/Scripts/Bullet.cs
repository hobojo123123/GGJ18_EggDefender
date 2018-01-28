using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Update()
    {
        transform.position += Vector3.up * Time.deltaTime;
    }
    private void OnEnable()
    {
        Invoke("TurnOff", 5f);
    }

    void TurnOff()
    {
        this.gameObject.SetActive(false);
    }
}