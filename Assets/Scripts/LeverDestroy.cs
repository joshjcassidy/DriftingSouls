using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDestroy : MonoBehaviour
{
    
    private Animator animator;
    public GameObject Obstacle;
    public bool leverRightOn;
    public bool playerInRange;

    public Signal contextSwitchOn;
    public Signal contextSwitchOff;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //Obstacle.SetActive(false);
        leverRightOn = false;
        
        if(Obstacle.activeInHierarchy){
                leverRightOn = false;
                animator.SetBool("LeverRightOn", true);
        }
        else{
            leverRightOn = true;
            animator.SetBool("LeverRightOn", false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        /*if(Input.GetKeyDown(KeyCode.Space) && playerInRange){
            if(leverRightOn == false){
                Obstacle.SetActive(false);
                leverRightOn = true;
                animator.SetBool("LeverRightOn", false);
            }
            else{
                Obstacle.SetActive(true);
                leverRightOn = false;
                animator.SetBool("LeverRightOn", true);
            }
        }*/

        if(Input.GetKeyDown(KeyCode.Space) && playerInRange){
            if(Obstacle.activeInHierarchy){
                Obstacle.SetActive(false);
                leverRightOn = true;
                animator.SetBool("LeverRightOn", false);
            }
            else{
                Obstacle.SetActive(true);
                leverRightOn = false;
                animator.SetBool("LeverRightOn", true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Player"))
        {
            playerInRange = true;
            contextSwitchOn.Raise();
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        if(collider.CompareTag("Player"))
        {
            playerInRange = false;
            contextSwitchOff.Raise();
        }
    }


}
