using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float ballForce;
    bool gameStarted= false;
    [SerializeField] private AudioSource jumpSound;
     public UiManager ui;
     private Vector3 startingPosition;

 
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        rb.AddForce(new Vector2(ballForce, ballForce));
         ui = GameObject.FindWithTag("ui").GetComponent<UiManager> ();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space) && gameStarted == false){

           transform.SetParent (null);
           rb.isKinematic = false;
        

            rb.AddForce(new Vector2(ballForce, ballForce));
 jumpSound.Play();
            gameStarted = true;
          

        }
    }

    void OnCollisionEnter2D(Collision2D col){
        
        if(col.gameObject.tag == "bottom"){
            ui.DecreaseHealth();
        // Topu başlangıç pozisyonuna geri döndür
        transform.position = startingPosition;
          Start(); 
            rb.AddForce(new Vector2(ballForce-200, ballForce-200));


          
    }
    else if(col.gameObject.tag == "side"){
         Vector2 wallNormal = col.contacts[0].normal;

    // Topun hareket yönü vektörünü hesapla
    Vector2 ballVelocity = GetComponent<Rigidbody2D>().velocity.normalized;

    // Topun hareket yönü vektörü ile duvarın normal vektörü arasındaki açıyı hesapla
    float angle = Vector2.Angle(ballVelocity, wallNormal);

    // Açıyı istediğiniz miktarda artır veya azalt
    angle += 50; 

    // Yeni hareket yönü vektörünü hesapla
    Vector2 newVelocity = Quaternion.AngleAxis(angle, Vector3.forward) * ballVelocity;
  rb.AddForce(new Vector2(500, 500));
    // Topun hareketini güncelle
    GetComponent<Rigidbody2D>().velocity = newVelocity;



    }
  


}
}
