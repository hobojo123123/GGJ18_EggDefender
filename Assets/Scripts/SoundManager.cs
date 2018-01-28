using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : Singleton
{
    protected SoundManager() : base() { }

    public List<AudioClip> soundsToUse= new List<AudioClip>();
    [Range(0, 8)]
    public int NumberOfChannels = 5;

    private Dictionary<string, AudioClip> soundData = new Dictionary<string, AudioClip>();
    
    private void Start()
    {
        foreach (AudioClip sound in soundsToUse)
        {
            Debug.Log("Adding sounds to data struct\n");
            if(sound != null)
                soundData.Add(sound.name, sound);
        }
    }
    
    // TODO: Add volume and pitch
    private AudioClip FindSound(string name)
    {
        AudioClip sound = null;
        if(soundData.ContainsKey(name))
        {
            sound = soundData[name];
        }

        return sound;
    }
}
