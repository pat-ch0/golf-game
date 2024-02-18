using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    private AudioSource audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject); //garde le gameobject à travers les scènes pour que la musique soit continue
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic() //la musique ne revient pas au début quand on change de scène
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}