using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Animator animator;
    //public Rigidbody2D rb;
    public GameObject LockedDoor;
    public GameObject OpenDoor;
    


    void Start()
    {
        animator = GetComponent<Animator>();
        OpenDoor.SetActive(false);
    }

    

    //public bool buttonPressed = false;

    

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        /*if(other.gameObject.tag == "Player")
        {
            //LockedDoor.SetActive(false);
         
            animator.SetBool("buttonPressed", true);



        }*/

        //animator.SetBool("buttonPressed", true);

        if(/*other.gameObject.tag == "Player" ||*/ other.gameObject.tag == "blockPushable" )
        {
            LockedDoor.SetActive(false);
            OpenDoor.SetActive(true);
         
            animator.SetBool("buttonPressed", true);

            //animator.SetBool("conditionFulfilled", true);

        }

    }

    void OnTriggerExit2D(Collider2D other) {
       // animator.SetBool("buttonPressed", false);

       if(other.gameObject.tag == "Player" || other.gameObject.tag == "blockPushable" )
        {
            LockedDoor.SetActive(true);
         
            animator.SetBool("buttonPressed", false);



        }
    }
}
