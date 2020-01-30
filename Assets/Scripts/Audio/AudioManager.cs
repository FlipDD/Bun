using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the audio to play and its volume
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public List<Sound> soundList;

    private Dictionary<string, Sound> sounds;

    public float sfxMultiplier = 1;
    public float musicMultiplier = 1;

    private Sound musicPlaying;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        foreach (var s in soundList)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
        }
    }

    private void Start()
    {
        sounds = new Dictionary<string, Sound>();
        foreach (var sound in soundList)
        {
            sounds.Add(sound.name, sound);
        }

        Play("Background", musicMultiplier, true);
    }

    public void Play(string name, float multiplier, bool looping = false)
    {
        if (sounds.TryGetValue(name, out Sound s))
        {
            s.source.volume = multiplier;
            s.source.loop = looping;
            s.source.Play();
        }
    }

    public void Stop(string name)
    {
        if (sounds.TryGetValue(name, out Sound s))
            s.source.Stop();
    }

    public void SetMusic(float value)
    {
        musicMultiplier = value;
        if (musicPlaying != null)
        {
            musicPlaying.source.volume = musicMultiplier;
        }
    }

    public void SetSfx(float value)
    {
        sfxMultiplier = value;
    }
}
