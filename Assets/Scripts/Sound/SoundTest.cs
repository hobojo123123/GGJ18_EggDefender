using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    public string BgSound = "BG Sound";
    public string Sfx = "SFX";

    // Use this for initialization
    void Start ()
    {
        // BG Sound
        SoundEvents.Instance.Play(BgSound);
        // Sfx Sound
        SoundEvents.Instance.Play(Sfx, true);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
