using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    public string name = "asone";

	// Use this for initialization
	void Start ()
    {
        SoundEvents.Instance.Play(name, false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
