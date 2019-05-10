using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource efxSource;
    public AudioSource musicSource;
    public static SoundManager instance = null;
    public float lowPitchRange = 0.95f;
    public float highPitchRange = 1.05f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlaySingle(AudioClip clip)
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();

        audio.clip = clip;

        audio.Play();
    }

    public void RandomizeSfx(params AudioClip[] clips)
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        int randomNum = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        audio.pitch = randomPitch;
        audio.clip = clips[randomNum];
        audio.Play();
    }
}
