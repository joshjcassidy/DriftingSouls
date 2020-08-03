using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollect : MonoBehaviour
{
    //public GameObject key;
    public BooleanValue blueKeyTaken;
    public BooleanValue purpleKeyTaken;
    public BooleanValue redKeyTaken;

    
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        if(this.gameObject.tag == "key_blue" && blueKeyTaken.RuntimeValue == false){
            this.gameObject.SetActive(true);
        }
        else if(this.gameObject.tag == "key_purple" && purpleKeyTaken.RuntimeValue == false){
            this.gameObject.SetActive(true);
        }
        else if(this.gameObject.tag == "key_red" && redKeyTaken.RuntimeValue == false){
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
            this.gameObject.SetActive(false);

            if(this.gameObject.tag == "key_blue"){
                blueKeyTaken.RuntimeValue = true;
            }
            else if(this.gameObject.tag == "key_purple"){
                purpleKeyTaken.RuntimeValue = true;
            }
            else if(this.gameObject.tag == "key_red"){
                redKeyTaken.RuntimeValue = true;
            }
        }
    }
}
