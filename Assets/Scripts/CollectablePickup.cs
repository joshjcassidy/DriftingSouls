using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePickup : MonoBehaviour
{
    public BooleanValue itemTaken;
    public FloatValue score;
    public FloatValue food;
    public FloatValue healthPacks;

    void Start()
    {
        if(itemTaken.RuntimeValue == false){
            this.gameObject.SetActive(true);
        }
        else{
            this.gameObject.SetActive(false);
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
            
            if(this.gameObject.tag == "Money" && itemTaken.RuntimeValue == false){
                score.RuntimeValue += 500;
                itemTaken.RuntimeValue = true;
            }
            else if(this.gameObject.tag == "Food" && itemTaken.RuntimeValue == false){
                food.RuntimeValue += 1;
                itemTaken.RuntimeValue = true;
            }
            else if(this.gameObject.tag == "HealthPack" && itemTaken.RuntimeValue == false){
                healthPacks.RuntimeValue += 1;
                itemTaken.RuntimeValue = true;
            }
        }
    }
}
