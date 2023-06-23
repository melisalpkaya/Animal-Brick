using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;


public class Timer : MonoBehaviour
{
    public float timeLeft = 10f; 
    public TextMeshProUGUI countdownText;
     public TextMeshProUGUI resultText;
     public UiManager uiManager; 

    void Start()
    {
        uiManager = FindObjectOfType<UiManager>();
        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {
        while (timeLeft > 0)
        {
           
            timeLeft -= Time.deltaTime;
            countdownText.text = "Time: " + Mathf.RoundToInt(timeLeft).ToString();

            yield return null;
        }

       
        Time.timeScale = 0;
        AudioManager.Instance.musicSource.Stop();
         int tempScore = UiManager.score;
        
        PlayerPrefs.SetInt("Score", tempScore);
        if(tempScore > 20){
             SceneManager.LoadScene("YouWon");
             Sound s = Array.Find(AudioManager.Instance.musicSounds, x => x.name == "won");
        if (s != null) {
            AudioManager.Instance.musicSource.clip = s.clip;
            AudioManager.Instance.musicSource.Play();
        }
        }
        else{
SceneManager.LoadScene("Result");
Sound s = Array.Find(AudioManager.Instance.musicSounds, x => x.name == "gameOver");
        if (s != null) {
            AudioManager.Instance.musicSource.clip = s.clip;
            AudioManager.Instance.musicSource.Play();
        }
        }
        
        
       
    

        
        
    }
}
