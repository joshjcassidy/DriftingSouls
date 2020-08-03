using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishButton : MonoBehaviour
{
    public bool playerInRange;

    public Signal contextPushOn;
    public Signal contextPushOff;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange){
            SceneManager.LoadScene("Win");
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Player"))
        {
            playerInRange = true;
            contextPushOn.Raise();
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
