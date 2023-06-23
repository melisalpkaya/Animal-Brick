using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds , sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
    private void Start(){
        PlayMusic("theme");
    }
    // Start is called before the first frame update
    public void PlayMusic(string name){
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if( s == null) {
            Debug.Log("not found");
        }
        else{
            musicSource.clip = s.clip;
            musicSource.Play();


        }
    }
    public void ToggleMusic(){
        musicSource.mute = !musicSource.mute;
    }
    public void MusicVolume(float volume){
        musicSource.volume = volume;
    }
    // public void PlaySFX(string name){
    //     Sound s = Array.Find(sfxSounds, x => x.name == name);
    //     if( s == null) {
    //         Debug.Log("not found");
    //     }
    //     else{
    //         sfxSource.PlayOneShot(s.clip);
    //     }
    // }
    
}
