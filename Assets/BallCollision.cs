using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    // public int speed = 20;
    public Rigidbody2D ball;
    public Animator animtr;
    public GameObject masterScript;
    public AudioSource HitEffect;
    // Start is called before the first frame update
    void Start()
    {
        int x = Random.Range(0, 2) * 2 - 1; //nilai x bisa bernilai 1 atau -1
        int y = Random.Range(0, 2) * 2 - 1; //nilai y bisa bernilai 1 atau -1
        int speed = Random.Range(20, 26); //nilai speed bisa bernilai 20 sampai 25
        ball.velocity = new Vector2(x,y)*speed;
        animtr.SetBool("IsMove", true);
    }
    // Update is called once per frame
    void FixedUpdate()//fixed untu benda yg bergerak
    {
        if(ball.velocity.x > 0){//bola ke kanan
            ball.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        }else{
            ball.GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.name == "WallKanan" || other.collider.name == "WallKiri") {
            masterScript.GetComponent<ScoringScript>().UpdateScore(other.collider.name);//ScoringScript :nama file
            StartCoroutine(jeda()); //untuk pindah ke tengah  
        }
        if(other.collider.tag=="Player") {
            HitEffect.Play();
        }
    }

    IEnumerator jeda(){
            ball.velocity = Vector2.zero; //menghentikan bola
            animtr.SetBool("IsMove", false); //mengubah animasi ke api berhenti
            ball.GetComponent<Transform>().position = new Vector2(0,0); //mengubah posisi bola

            yield return new WaitForSeconds(1);

            int x = Random.Range(0, 2) * 2 - 1; //nilai x bisa bernilai 1 atau -1
            int y = Random.Range(0, 2) * 2 - 1; //nilai y bisa bernilai 1 atau -1
            int speed = Random.Range(20, 26); //nilai speed bisa bernilai 20 sampai 25
            ball.velocity = new Vector2(x,y)*speed; //mengatur kecepatan
            animtr.SetBool("IsMove", true); //mengubah animasi ke api bergerak
    }

    
}
