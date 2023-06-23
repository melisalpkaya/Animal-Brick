using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PaddleScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public float Speed;
    public float maxX, minX;
     public UiManager ui;
    
   

    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.FindWithTag("ui").GetComponent<UiManager> ();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        if (x < 0)
        {
            MoveLeft();
        }
        else if (x > 0)
        {
            MoveRight();
        }
        else{
            Stop();
        }

        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;
    }
    
    void MoveLeft(){
      rb.velocity = new Vector2(-Speed,0);
    }

    void MoveRight(){
     rb.velocity = new Vector2(Speed,0);

    }

    void Stop(){
       rb.velocity = Vector2.zero;
    }
     void OnCollisionEnter2D(Collision2D col){
        
        if(col.gameObject.tag == "heart"){
            ui.IncrementHealth();
            
            Destroy(col.gameObject);
           

        }
        if(col.gameObject.tag == "bomb"){
           // ui.IncrementHealth();
            
            Destroy(col.gameObject);
           ui.DecreaseHealth();
            Sound s = Array.Find(AudioManager.Instance.musicSounds, x => x.name == "bomb");
        if (s != null) {
            
            AudioManager.Instance.musicSource.PlayOneShot(s.clip);
        }
         
      

        }
        
    }
}
