using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossletsTriggerTiles : MonoBehaviour
{
    //public GameObject gates;
    public GameObject bosslet1;
    public GameObject bosslet2;
    public GameObject bosslet3;
    public GameObject bosslet4;
    public bool bossletsTriggered;
    public BooleanValue bossDefeated;

    
    // Start is called before the first frame update
    void Start()
    {
        bossletsTriggered = false;
        
        bosslet1.SetActive(false);
        bosslet2.SetActive(false);
        bosslet3.SetActive(false);
        bosslet4.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !bossletsTriggered)
        {
            bosslet1.SetActive(true);
            bosslet2.SetActive(true);
            bosslet3.SetActive(true);
            bosslet4.SetActive(true);
            bossletsTriggered = true;
        }

    }
}
