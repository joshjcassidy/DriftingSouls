using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    
    //public GameObject ClosedDoor;

    // Start is called before the first frame update
    void Start()
    {
        //ClosedDoor.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);

            //ClosedDoor.SetActive(false);
        }

    }
}
