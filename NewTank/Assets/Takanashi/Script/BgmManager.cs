using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour {
    public static BgmManager instance = null;

    public AudioSource bgmAudio;

    void Awake()
    {
        if (BgmManager.instance == null)
        {
            BgmManager.instance = this;
        }
        if (BgmManager.instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBGM(AudioClip audioClip)
    {
        bgmAudio.clip = audioClip;
        bgmAudio.Play();
    }

    public bool IsPlayingBGM()
    {
        return bgmAudio.isPlaying;
    }
}
