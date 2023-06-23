using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StarScript : MonoBehaviour
{
    public UiManager ui;
    [SerializeField] private AudioSource breakSound;
    public GameObject heartPrefab;
    
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
            
            // Kalp objesini oluştur ve aşağıya doğru hareket ettir
           Instantiate(heartPrefab, transform.position, Quaternion.identity);
           // Yıldızı yok et
           Destroy(gameObject);

           

        }
    }
}
