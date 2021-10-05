using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioManager instance;
    Audio[] audios;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audios = Resources.LoadAll<Audio>("Audios");
        Debug.Log(audios.Length);
        foreach(Audio a in audios)
        {
            a.source = gameObject.AddComponent<AudioSource>();
            a.source.clip = a.clip;
            a.source.volume = a.volume;
            a.source.loop = a.loop;
        }
    }

    public static void Play(string _name)
    {
        foreach (Audio a in instance.audios)
        {
            if(_name == a.clipName)
            {
                a.source.Play();
                return;
            }
        }
    }
}
