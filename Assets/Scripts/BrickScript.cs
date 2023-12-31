using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public UiManager ui;
    [SerializeField] private AudioSource breakSound;
    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.FindWithTag("ui").GetComponent<UiManager> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){
        
        if(col.gameObject.tag == "Ball"){
            ui.IncrementScore();
            breakSound.Play();
            Destroy(gameObject);
           col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2f, 2f), ForceMode2D.Impulse);

        }
    }
}
