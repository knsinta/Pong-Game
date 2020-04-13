using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public int speed = 20;
    public Rigidbody2D ball;
    public Animator animtr;
    public GameObject masterScript;
    // Start is called before the first frame update
    void Start()
    {
        ball.velocity = new Vector2(-1,1)*speed;
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
            StartCoroutine(jeda());   
        }
    }

    IEnumerator jeda(){
            ball.velocity = Vector2.zero;
            animtr.SetBool("IsMove", false);
            ball.GetComponent<Transform>().position = new Vector2(0,0);
            yield return new WaitForSeconds(1);
            ball.velocity = new Vector2(-1,1)*speed;
            animtr.SetBool("IsMove", true);
    }

    
}
