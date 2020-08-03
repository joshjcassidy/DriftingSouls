using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite heart;
    public FloatValue heartNumber;
    public FloatValue currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }

    public void InitHearts(){
        for (int i = 0; i < heartNumber.RuntimeValue; i ++){
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = heart;
        }
    }

    public void UpdateHearts()
    {
        //keeping the number of hearts and the actual health separate in order to reduce workload on checking this every frame
        if(currentHealth.RuntimeValue != heartNumber.RuntimeValue){
            
            float tempDiff = heartNumber.RuntimeValue - currentHealth.RuntimeValue;
            int removedHeart = (int)heartNumber.RuntimeValue - 1;

            for(int i = 0; i < tempDiff; i++){
                hearts[removedHeart].gameObject.SetActive(false);
            }
            
            heartNumber.RuntimeValue = currentHealth.RuntimeValue;

        }


    }

    // Update is called once per frame
    void Update()
    {
        UpdateHearts();
        if(currentHealth.RuntimeValue < 1){
            SceneManager.LoadScene("GameOver");
        }
    }
}
