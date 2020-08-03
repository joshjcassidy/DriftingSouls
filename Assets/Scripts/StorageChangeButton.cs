using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageChangeButton : MonoBehaviour
{
    private Animator animator;
    public bool playerInRange;
    public BooleanValue changed;

    public Signal contextPushOn;
    public Signal contextPushOff;

    public Signal contextOKOn;
    public Signal contextOKOff;

    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        if(changed.RuntimeValue == true){
            animator.SetBool("Pushed", true);
        }
        else{
            animator.SetBool("Pushed", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(changed.RuntimeValue == false && playerInRange){
                changed.RuntimeValue = true;
                animator.SetBool("Pushed", true);
                contextPushOff.Raise();

                if(this.gameObject.CompareTag("Push")){
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    contextOKOn.Raise();
                }
            }
            else{
                if(dialogBox.activeInHierarchy){
                    dialogBox.SetActive(false);
                    contextOKOff.Raise();
                    contextOKOff.Raise();
                }
            }

        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Player"))
        {
            playerInRange = true;
            if(changed.RuntimeValue == false){
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
}
