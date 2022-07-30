using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayAudio : MonoBehaviour
{
    [SerializeField] private AudioClip[] clip;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void AudioPlayer()
    {
        audioSource.clip = clip[Random.Range(0, clip.Length - 1)];
        audioSource.Play();
    }
}
