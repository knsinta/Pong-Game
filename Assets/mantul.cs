using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mantul : MonoBehaviour
{
    public int speed=20;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
        GetComponent<Rigidbody2D>().velocity =  new Vector2(1,-1)*speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.name=="WallKanan" || other.collider.name=="WallKiri"){
            GetComponent<Transform>().position = new Vector2(0,0);
        }
    }
}
