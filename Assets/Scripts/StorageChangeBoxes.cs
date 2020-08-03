using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageChangeBoxes : MonoBehaviour
{
    
    public BooleanValue changed;
    public GameObject boxes1;
    public GameObject boxes2;
    
    // Start is called before the first frame update
    void Start()
    {
        if(changed.RuntimeValue == false){
            boxes1.SetActive(true);
            boxes2.SetActive(false);
        }
        else{
            boxes1.SetActive(false);
            boxes2.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(changed.RuntimeValue == false){
            boxes1.SetActive(true);
            boxes2.SetActive(false);
        }
        else{
            boxes1.SetActive(false);
            boxes2.SetActive(true);
        }
    }
}
