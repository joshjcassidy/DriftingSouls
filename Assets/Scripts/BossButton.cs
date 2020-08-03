using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossButton : MonoBehaviour
{
    private Animator animator;
    public bool playerInRange;
    //public BooleanValue changed;
    public bool pushed;
    public GameObject spikesOn;

    public Signal contextPushOn;
    public Signal contextPushOff;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        animator.SetBool("Pushed", false);

        pushed = false;

        spikesOn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange){
            if(!pushed){
                pushed = true;
                animator.SetBool("Pushed", true);
                spikesOn.SetActive(true);
                contextPushOff.Raise();
                StartCoroutine(ButtonCo());
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Player"))
        {
            playerInRange = true;
            if(!pushed){
                contextPushOn.Raise();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        if(collider.CompareTag("Player"))
        {
            playerInRange = false;
            contextPushOff.Raise();
        }
    }

    private IEnumerator ButtonCo(){
        yield return new WaitForSeconds(1);
        pushed = false;
        animator.SetBool("Pushed", false);
        spikesOn.SetActive(false);
        if(playerInRange){
            contextPushOn.Raise();
        }
    }
}
