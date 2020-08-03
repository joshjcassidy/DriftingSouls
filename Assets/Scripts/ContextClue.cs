using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContextClue : MonoBehaviour
{
    // Start is called before the first frame update
    public Image ok;
    public Image check;
    public Image push;
    public Image switchLever;
    
    void Start()
    {
        ok.enabled = false;
        check.enabled = false;
        push.enabled = false;
        switchLever.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void okEnable(){
        ok.enabled = true;
    }

    public void okDisable(){
        ok.enabled = false;
    }

    public void checkEnable(){
        check.enabled = true;
    }

    public void checkDisable(){
        check.enabled = false;
    }

    public void pushEnable(){
        push.enabled = true;
    }

    public void pushDisable(){
        push.enabled = false;
    }

    public void switchEnable(){
        switchLever.enabled = true;
    }

    public void switchDisable(){
        switchLever.enabled = false;
    }
}
