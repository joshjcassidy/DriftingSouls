using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DayTimer : MonoBehaviour
{
    public FloatValue timeLeft;
    public FloatValue daysCount;
    public FloatValue foodLeft;
    public FloatValue healsLeft;
    public FloatValue currentHealth;
    Image timerBar;
    public float maxTime;

    public Vector2 playerPosition;
    public OnLoadPosition playerStorage;
    
    // Start is called before the first frame update
    void Start()
    {
        timerBar = GetComponent<Image>();
    }

    /*public void InitTime(){
        for (int i = 0; i < heartNumber.initialValue; i ++){
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = heart;
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        if(timeLeft.RuntimeValue > 0){
            timeLeft.RuntimeValue -= Time.deltaTime;
            timerBar.fillAmount = timeLeft.RuntimeValue / maxTime;
        }
        else{
            EndOfDay();
        }
    }

    public void EndOfDay(){
        if(foodLeft.RuntimeValue > 0){
            foodLeft.RuntimeValue -= 1;
        }
        else{
            SceneManager.LoadScene("GameOver");
            return;
        }

        if(healsLeft.RuntimeValue > 0 && currentHealth.RuntimeValue < 4){
            currentHealth.RuntimeValue = 4;
            healsLeft.RuntimeValue -= 1;
        }
        else{

        }

        
        daysCount.RuntimeValue += 1;
        playerStorage.initialValue = playerPosition;
        timeLeft.RuntimeValue = 600;
        SceneManager.LoadScene("0HubRoom");
        
    }
}
