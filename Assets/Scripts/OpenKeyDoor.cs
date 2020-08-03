using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKeyDoor : MonoBehaviour
{
    public BooleanValue blueKeyTaken;
    public BooleanValue purpleKeyTaken;
    public BooleanValue redKeyTaken;

    public BooleanValue blueLockOpen;
    public BooleanValue purpleLockOpen;
    public BooleanValue redLockOpen;
    
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        if(this.gameObject.tag == "lock_blue" && blueLockOpen.RuntimeValue == false){
            this.gameObject.SetActive(true);
        }
        else if(this.gameObject.tag == "lock_purple" && purpleLockOpen.RuntimeValue == false){
            this.gameObject.SetActive(true);
        }
        else if(this.gameObject.tag == "lock_red" && redLockOpen.RuntimeValue == false){
            this.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Player"))
        {
            if(this.gameObject.tag == "lock_blue" && blueKeyTaken.RuntimeValue == true){
                blueLockOpen.RuntimeValue = true;
                this.gameObject.SetActive(false);
            }
            else if(this.gameObject.tag == "lock_purple" && purpleKeyTaken.RuntimeValue == true){
                purpleLockOpen.RuntimeValue = true;
                this.gameObject.SetActive(false);
            }
            else if(this.gameObject.tag == "lock_red" && redKeyTaken.RuntimeValue == true){
                redLockOpen.RuntimeValue = true;
                this.gameObject.SetActive(false);
            }
        }
    }


}
