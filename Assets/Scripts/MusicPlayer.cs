using System;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip clip;

    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        audioSource.clip = clip;
        audioSource.volume = GameManager.Instance.volume;
        audioSource.Play();
    }
}
