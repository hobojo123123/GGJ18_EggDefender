﻿using UnityEngine;

public class SoundEvents 
{
    private static SoundEvents instance = null;
    public static SoundEvents Instance
    {
        get // This gets the private var instance and gives it to the public Instance.
        {
            // instance is being born in the code and is saying if we don't have anything in the instance create an instance.
            if (instance == null)
            { 
                instance = new SoundEvents();
            }
            return instance;
        }
        private set
        {
            //Don't want anything to set a value that's not part of the instance.
        }
    }

    //Play one Sound 
    public void Play(string soundName, bool loop)
    {
        // Getting the Namespace SoundManger(Which is a class). Then Making an instance of it and calling the unity Play function.
        SoundManager.instance.Play(soundName, loop);
    }

    public void Stop(string soundName)
    {
        SoundManager.instance.Stop(soundName);
    }
    //Play random sound
    public void PlayRand(string[] soundNames, bool loop)
    {
        int result = 0;
        if (soundNames != null)
        {
            Debug.Log("soundNames Length : " + soundNames.Length);
            result = Random.Range(10, 1000) % soundNames.Length;
            string soundName = soundNames[result];

            SoundManager.instance.Play(soundName, loop);
        }

    }

    //Overloads at the bottom that include Channels
    
    // Play one Sound and uses Channel
    public void Play(string soundName, int channel)
    {
        // Getting the Namespace SoundManger(Which is a class). Then Making an instance of it and calling the unity Play function.
        SoundManager.instance.Play(soundName, channel);
    }

    public void Stop(string soundName, int channel)
    {
        SoundManager.instance.Stop(soundName, channel);
    }

    // Play random sound from a list and Channel
    public void PlayRand(string[] soundNames, int channel)
    {
        int result = 0;
        if (soundNames != null)
        {
            Debug.Log("soundNames Length : " + soundNames.Length);
            result = Random.Range(10, 1000) % soundNames.Length;
            string soundName = soundNames[result];

            SoundManager.instance.Play(soundName, channel);
        }
        
    }

}
