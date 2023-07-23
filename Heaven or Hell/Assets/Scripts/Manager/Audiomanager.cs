using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioHolder))]
public class Audiomanager : MonoBehaviour
{
    public static Audiomanager instance;

    AudioHolder holder;

    private void Awake()
    {
        // Singleton
        if (instance == null && instance != this)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        holder = GetComponent<AudioHolder>();
    }

    /// <summary>
    /// gets a sound from the audio holder
    /// </summary>
    /// <returns></returns>
    public AudioSource GetSound(int arrayIndex, int soundIndex)
    {
        switch (arrayIndex) 
        {
            case 0:
                return holder.GetButtonSounds()[soundIndex];

            case 1:
                return holder.GetGameplaySounds()[soundIndex];

            default:
                return null;
        }
    }

    public void PlaySound(AudioSource audio)
    {
        audio.Play();
    }
}
