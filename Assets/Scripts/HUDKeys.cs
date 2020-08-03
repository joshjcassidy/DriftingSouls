using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDKeys : MonoBehaviour
{
    public Image blueKey;
    public Image purpleKey;
    public Image redKey;
    public BooleanValue blueKeyTaken;
    public BooleanValue purpleKeyTaken;
    public BooleanValue redKeyTaken;
    public BooleanValue blueLockOpen;
    public BooleanValue purpleLockOpen;
    public BooleanValue redLockOpen;
    
    // Start is called before the first frame update
    void Start()
    {
        blueKey.enabled = false;
        purpleKey.enabled = false;
        redKey.enabled = false;

        if(blueKeyTaken.RuntimeValue == true && blueLockOpen.RuntimeValue == false){
            blueKey.enabled = true;
        }
        else if(purpleKeyTaken.RuntimeValue == true && purpleLockOpen.RuntimeValue == false){
            purpleKey.enabled = true;
        }
        else if(redKeyTaken.RuntimeValue == true && redLockOpen.RuntimeValue == false){
            redKey.enabled = true;
        }
        else{
            blueKey.enabled = false;
            purpleKey.enabled = false;
            redKey.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(blueKeyTaken.RuntimeValue == true && blueLockOpen.RuntimeValue == false){
            blueKey.enabled = true;
        }
        else if(purpleKeyTaken.RuntimeValue == true && purpleLockOpen.RuntimeValue == false){
            purpleKey.enabled = true;
        }
        else if(redKeyTaken.RuntimeValue == true && redLockOpen.RuntimeValue == false){
            redKey.enabled = true;
        }
        else{
            blueKey.enabled = false;
            purpleKey.enabled = false;
            redKey.enabled = false;
        }
    }
}
