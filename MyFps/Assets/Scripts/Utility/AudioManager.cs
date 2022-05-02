using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    public Sound[] sounds;

    // 플레이 배경음 이름
    private string bgmName = "";

    private void Awake()
    {
        if (instance != null)
        {
            Destroy (gameObject);
            return;
        }
        instance = this;
        // DontDestroyOnLoad(gameObject);

        foreach (var s in sounds)
        {
            s.source = this.gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound sound = null;
        Debug.Log("Sound Play");
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                sound = s;
                break;
            }
        }

        if (sound == null)
        {
            Debug.Log("Play Sound : " + name + "File not found!!!");
            return;
        }

        sound.source.Play();
    }

    public void StopBgm()
    {
        Sound sound = null;

        foreach (Sound s in sounds)
        {
            if (s.name == bgmName)
            {
                sound = s;
                break;
            }
        }

        if (sound == null)
        {
            Debug.Log("Stop Sound : " + name + "File not found!!!");
            return;
        }

        bgmName = "";
        sound.source.Stop();
    }

    public void PlayBgm(string name)
    {
        if (bgmName == name)
        {
            return;
        }
        // 기존 배경음 정지
        StopBgm();

        Sound sound = null;

        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                sound = s;
                break;
            }
        }
        
        if (sound == null)
        {
            Debug.Log("Play Sound : " + name + "File not found!!!");
        }

        bgmName = sound.name;

        sound.source.Play();
    }
}
