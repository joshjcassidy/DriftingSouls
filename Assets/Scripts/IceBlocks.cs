using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlocks : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag != "Player"){
                this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                this.GetComponent<Rigidbody2D>().angularVelocity = 0f;

                this.GetComponent<Rigidbody2D>().Sleep();
                
                //this.GetComponent<Rigidbody2D>().velocity = 0;
                //this.GetComponent<Rigidbody2D>().angularVelocity = 0;
        }
    }
}
