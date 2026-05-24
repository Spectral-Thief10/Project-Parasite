using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip backgroundMusic;
    public AudioClip shootSound;
    public AudioClip damageSound;
    public AudioClip teleportSound;

    void Awake()
    {
        //  so other scripts can access it
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayMusic();
    }

    public void PlayMusic()
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayShoot()
    {
        sfxSource.PlayOneShot(shootSound);
    }

    public void PlayDamage()
    {
        sfxSource.PlayOneShot(damageSound);
    }

    public void PlayTeleport()
    {
        sfxSource.PlayOneShot(teleportSound);
    }
}
