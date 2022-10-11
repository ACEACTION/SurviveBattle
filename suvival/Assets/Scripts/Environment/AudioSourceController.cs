using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController : MonoBehaviour
{
    // sfx
    [SerializeField] AudioClip[] enemyBloodsSfx;
    [SerializeField] AudioClip meteorSfx;
    [SerializeField] AudioClip loseSfx;
    [SerializeField] AudioClip deathPulsSfx;
    [SerializeField] AudioClip lightningSfx;

    // audio source
    [SerializeField] AudioSource audioScr;

    // singleton
    public static AudioSourceController Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void PlayEnemyBloodsSfx()
    {
        audioScr.PlayOneShot(enemyBloodsSfx[Random.Range(0, enemyBloodsSfx.Length)]);
    }

    public void PlayMeteorSfx()
    {
        audioScr.PlayOneShot(meteorSfx);
    }

    public void PlayLoseSfx()
    {
        audioScr.PlayOneShot(loseSfx);
    }

    public void PlayDeathPulseSfx()
    {
        audioScr.PlayOneShot(deathPulsSfx);
    }

    public void PlayLightningSfx()
    {
        audioScr.PlayOneShot(lightningSfx);
    }


}
