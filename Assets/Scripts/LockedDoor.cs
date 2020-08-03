using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedDoor : MonoBehaviour
{
    public GameObject textBox;
    public Text dialogText;
    public string dialog;
    public bool dialogActive;
    public bool playerInRange;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange){
            if(textBox.activeInHierarchy){
                textBox.SetActive(false);
            } else {
                textBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        if(collider.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
