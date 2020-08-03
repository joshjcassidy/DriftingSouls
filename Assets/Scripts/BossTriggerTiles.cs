using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggerTiles : MonoBehaviour
{
    public GameObject gates;
    public GameObject boss;
    public bool bossTriggered;
    public BooleanValue bossDefeated;

    
    // Start is called before the first frame update
    void Start()
    {
        bossTriggered = false;
        
        if(bossDefeated.RuntimeValue == false){
            this.gameObject.SetActive(true);
            boss.SetActive(true);
        }
        else{
            this.gameObject.SetActive(false);
            boss.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !bossTriggered)
        {
            gates.SetActive(true);
            bossTriggered = true;
        }

    }
}
