using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;



public class UiManager : MonoBehaviour
{
    public static int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public int health = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Sprite soundOn;
    public Sprite soundOff;
    public Sprite play;
    public Sprite pause;
    public Button soundButton;
     public Button playButton;
    private bool isOn = true;
    public bool gameStatus = false;
    

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for(int i = 0;i<health;i++){
            hearts[i].sprite = fullHeart;
        }
    }
    public void IncrementScore(){
       

        score++;
    scoreText.text = score.ToString();

    }
     public void IncrementHealth(){
        if(health < 3 ){
          health++;
          
        }
        

       
    }
    public void DecreaseHealth()
    {
        health--;
       

        if (health <= 0)
        {AudioManager.Instance.musicSource.Stop();
        SceneManager.LoadScene("GameOver");

        Sound s = Array.Find(AudioManager.Instance.musicSounds, x => x.name == "gameOver");
        if (s != null) {
            AudioManager.Instance.musicSource.clip = s.clip;
            AudioManager.Instance.musicSource.Play();
        }
         
        }
    }


   public  void stopGame(){
        if(gameStatus == false){
            Time.timeScale = 0f;
            playButton.image.sprite = play;
            gameStatus = true;
        }
        else{
             Time.timeScale = 1f;
            
             playButton.image.sprite = pause;
             gameStatus = false;

        }

    }
     public void Quit()
    {
        SceneManager.LoadScene("PlayModes");
    }
    
     public void ToggleMusic(){
    AudioManager.Instance.ToggleMusic();
    if(isOn){
        soundButton.image.sprite = soundOff;
        isOn=false;
    }
    else{
        soundButton.image.sprite = soundOn;
        isOn=true;
    }
  }
}
