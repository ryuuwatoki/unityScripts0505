using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource startBgmAudio;
    public AudioSource startBtnAudio;
    public AudioSource gameBgmAudio;
    public AudioSource getAudio;
    public AudioSource boomAudio;

    public void PlayStartBgm(){
        startBgmAudio.Play();
    }

    public void StopStartBgm(){
        startBgmAudio.Stop();
    }

    public void PlayStartBtnAndSwitchBgm()
    {
        StartCoroutine(PlayStartBtnThenGameBgm());
    }

    private System.Collections.IEnumerator PlayStartBtnThenGameBgm()
    {
        startBtnAudio.Play();
        yield return new WaitForSeconds(3f);
        gameBgmAudio.Play();
    }

    public void StopGameBgm()
    {
        gameBgmAudio.Stop();
    }

    public void PlayGameBgm()
    {
        if (!gameBgmAudio.isPlaying)
            gameBgmAudio.Play();
    }

    public void PlayGet()
    {
        getAudio.Play();
    }

    public void PlayBoom()
    {
        boomAudio.Play();
    }








    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

