using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDestroy : MonoBehaviour
{

    private Animator animator;
    //public Rigidbody2D rb;
    public GameObject Obstacle;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Obstacle.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "blockPushable" )
        {
            Obstacle.SetActive(false);
         
            animator.SetBool("buttonPressed", true);

            //animator.SetBool("conditionFulfilled", true);

        }

    }

    void OnTriggerExit2D(Collider2D collision) {
       // animator.SetBool("buttonPressed", false);

       if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "blockPushable" )
        {
            Obstacle.SetActive(true);
         
            animator.SetBool("buttonPressed", false);



        }
    }
}
