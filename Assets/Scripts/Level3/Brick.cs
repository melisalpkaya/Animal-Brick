using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Brick : MonoBehaviour
{
    public int hitCount = 0;
     public UiManager ui;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioSource breakSound;

    void Start()
    {
         ui = GameObject.FindWithTag("ui").GetComponent<UiManager> ();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            hitCount++;

            if (hitCount == 1)
            {
                // Opaklığı yarı yarıya azalt
                Color color = spriteRenderer.color;
                color.a = 0.5f;
                spriteRenderer.color = color;
            }
            else if (hitCount >= 2)
            {
                // Kutuyu yok et
                Destroy(gameObject);
                 
            ui.IncrementScore();
            breakSound.Play();
            
           

        
            }
        }
    }
}
