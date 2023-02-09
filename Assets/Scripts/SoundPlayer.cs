using System;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip onWallSound;
    [SerializeField] private AudioClip onGroundSound;

    [SerializeField] private AudioSource audioSource;

    public static SoundPlayer Instance;

    private void Start()
    {
        Instance = this;
    }

    public void PlayJump()
    {
        audioSource.clip = jumpSound;
        audioSource.Play();
    }
    
    public void PlayShot()
    {
        audioSource.clip = shootSound;
        audioSource.Play();
    }
    
    public void PlayWall()
    {
        audioSource.clip = onWallSound;
        audioSource.Play();
    }
    
    public void PlayFall()
    {
        audioSource.clip = onGroundSound;
        audioSource.Play();
    }
}