using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource bgSource;
    public AudioSource clickSource;

    public AudioClip bgClip;

    public bool isBGSource = true;

    public SoundClick soundClick;
    public SoundEff soundEff;

    private void Start()
    {
        PlayBackGround();
    }
    public void PlayBackGround()
    {
        if(isBGSource)
        {
            bgSource.clip = bgClip;
            bgSource.loop = true;
            bgSource.Play();
        }
        else
        {
            bgSource.Stop();
        }
    }
    public void PlaySound(AudioClip clip)
    {
        clickSource.PlayOneShot(clip);
    }
}
[System.Serializable]
public class SoundClick
{
    public AudioClip clickClip;
    public void Play()
    {
        SoundManager.Instance.PlaySound(clickClip);
    }
}
[System.Serializable]
public class SoundEff
{
    public AudioClip effClip;
    public void Play()
    {
        SoundManager.Instance.PlaySound(effClip);
    }
}
