using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;
    public Signal contextOKOn;
    public Signal contextOKOff;
    public Signal contextCheckOn;
    public Signal contextCheckOff;

    public FloatValue food;
    public FloatValue healthPacks;
    public FloatValue money;
    /*public Signal contextPushOn;
    public Signal contextPushOff;
    public Signal contextSwitchOn;
    public Signal contextSwitchOff;*/

    void Start(){

    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            if(dialogBox.activeInHierarchy && playerInRange){
                dialogBox.SetActive(false);
                contextOKOff.Raise();
                contextCheckOn.Raise();
            }
            else if(dialogBox.activeInHierarchy){
                dialogBox.SetActive(false);
                contextOKOff.Raise();
            }
            else if (playerInRange){
                textDisplay();
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                contextOKOn.Raise();
                contextCheckOff.Raise();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            playerInRange = true;
            contextCheckOn.Raise();
            
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            playerInRange = false;
            contextCheckOff.Raise();
        }
    }

    void textDisplay(){
        if(this.gameObject.CompareTag("Fridge")){
            dialog = "You need food to survive the night. If a day ends and you have no food, you'll die. You currently have " + food.RuntimeValue + " food items.";
        }
        else if(this.gameObject.CompareTag("FirstAidTut")){
            dialog = "First Aid Kits restore your health at the end of the day. You currently have " + healthPacks.RuntimeValue + " First Aid Kits.";
        }
        else if(this.gameObject.CompareTag("MoneyTut")){
            dialog = "Collect as much money as you can for a higher score! You've collected $" + money.RuntimeValue + "!";
        }
    }
}
