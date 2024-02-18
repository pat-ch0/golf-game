using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    private AudioSource audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject); //garde le gameobject � travers les sc�nes pour que la musique soit continue
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic() //la musique ne revient pas au d�but quand on change de sc�ne
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}