using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    public AudioClip[] sounds;
    public Dictionary<string, AudioClip> soundByName = new Dictionary<string, AudioClip>();

    [Range(1, 5)]
    public int numChannels = 1;
    private GameObject[] soundEmitters;
    List<GameObject> unusedSoundEmitters = new List<GameObject>();
    List<GameObject> usedSoundEmitters = new List<GameObject>();
    public enum soundChannels {BACKGROUND, SoundChannelCount}

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        //Index Sounds
        foreach (AudioClip clip in sounds)
            soundByName[clip.name] = clip;

        GameObject soundManager = GameObject.Find("SoundManager");
        
        soundEmitters = new GameObject[(int)soundChannels.SoundChannelCount];
        GameObject e = soundEmitters[(int)soundChannels.BACKGROUND];
        e = (GameObject)Instantiate(Resources.Load("SoundEmitter"));
        e.name = "SoundEmitter Background";
        e.transform.parent = soundManager.transform;
        soundEmitters[(int)soundChannels.BACKGROUND] = e;

        //Generating sound Emitters
        for (int i = 0; i < numChannels; i++)
        {
            GameObject emitter = (GameObject)Instantiate(Resources.Load("SoundEmitter"));
            emitter.name += " "+i.ToString();
            emitter.transform.parent = soundManager.transform;
            unusedSoundEmitters.Add(emitter);
        }
             
    }

    public void Play(string name, bool loop = false)
    {
        if (soundByName.ContainsKey(name))
        {
            GameObject emitter = GetSoundEmitter();
            AudioSource source = emitter.GetComponent<AudioSource>();
            source.Stop();
            source.loop = loop;
            source.clip = soundByName[name];
            source.Play();
        }
        else
        {
            print("Sound Is Not Found");
        }
    }

    public void Stop(string name)
    {
        if (soundByName.ContainsKey(name))
        {
            GameObject emitter = GetSoundEmitter();
            AudioSource source = emitter.GetComponent<AudioSource>();
            source.Stop();

        }
    }

   

    public void StopAll()
    {
        foreach(GameObject emitter in usedSoundEmitters)
        {
            emitter.SetActive(false);
            AudioSource source = emitter.GetComponent<AudioSource>();
            source.Stop();
            
        }
    }


    GameObject GetSoundEmitter()
    {
        RecycleEmitters();

        GameObject emitters;
        if (unusedSoundEmitters.Count > 0)
        {
            emitters = unusedSoundEmitters[0];
            unusedSoundEmitters.RemoveAt(0);
            usedSoundEmitters.Add(emitters);
        }
        else
        {
            emitters = usedSoundEmitters[0];
            usedSoundEmitters.RemoveAt(0);
            usedSoundEmitters.Add(emitters);
        }
        return emitters;
    }

    //Overloaded Functions for Channels.

    // Background channels will always be set to loop
    public void Play(string name, int channel)
    {
        if (soundByName.ContainsKey(name))
        {
            GameObject emitter = GetSoundEmitter(channel);
            AudioSource source = emitter.GetComponent<AudioSource>();
            source.Stop();
            source.loop = true;
            source.clip = soundByName[name];
            source.Play();
        }
        else
        {
            print("Sound Is Not Found");
        }
    }
    public void Stop(string name, int channel)
    {
        if (soundByName.ContainsKey(name))
        {
            GameObject emitter = GetSoundEmitter();
            AudioSource source = emitter.GetComponent<AudioSource>();
            source.Stop();

        }
    }

    public void StopAll(int channel)
    {
        foreach (GameObject emitter in usedSoundEmitters)
        {
            emitter.SetActive(false);
            AudioSource source = emitter.GetComponent<AudioSource>();
            source.Stop();

        }
    }

    GameObject GetSoundEmitter(int channel)
    {
        GameObject emitters = soundEmitters[channel];
        return emitters;
    }

    void RecycleEmitters()
    {
        for (int i = usedSoundEmitters.Count - 1; i >= 0; --i)
        {
            GameObject emitters = usedSoundEmitters[i];
            AudioSource source = emitters.GetComponent<AudioSource>();
            if (source.isPlaying == false)
            {
                usedSoundEmitters.RemoveAt(i);
                unusedSoundEmitters.Add(emitters);
            }
        }
    }
}
