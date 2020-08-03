using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public Text textMoneyTail;
    public Text textFoodHead; 
    public Text textFoodTail; 
    public Text textHealthPacksHead;
    public Text textHealthPacksTail;
    public Text textDaysHead;
    public Text textDaysTail;
    public Text textFinalScoreTail;

    public FloatValue score;
    public FloatValue food;
    public FloatValue healthPacks;
    public FloatValue daysTaken;

    float moneyScore;
    float foodScore;
    float healthPackScore;
    int daysTakenIndex;
    float daysTakenMultiplier;
    float[] possibleMultipliers = {10, 9, 8, 7, 6, 5, 4, 3, 2, 1.5F, 1};
    public float finalScore;
    
    // Start is called before the first frame update
    void Start()
    {
        moneyScore = score.RuntimeValue;
        foodScore = food.RuntimeValue * 1000;
        healthPackScore = healthPacks.RuntimeValue * 2000;
        daysTakenIndex = (int) daysTaken.RuntimeValue - 1;
        daysTakenMultiplier = possibleMultipliers[daysTakenIndex];
        
        
        
        textMoneyTail.text = moneyScore.ToString();

        textFoodHead.text = "Food Remaining: 1000 x " + food.RuntimeValue;
        textFoodTail.text = foodScore.ToString();

        textHealthPacksHead.text = "First Aid Kits Remaining: 2000 x " + healthPacks.RuntimeValue;
        textHealthPacksTail.text = healthPackScore.ToString();

        textDaysHead.text = "Days Taken: " + daysTaken.RuntimeValue;
        textDaysTail.text = "x" + daysTakenMultiplier;
        
        finalScore = FinalScoreCalc(moneyScore, foodScore, healthPackScore, daysTakenMultiplier);

        textFinalScoreTail.text = finalScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Application.Quit();
        }
    }

    public float FinalScoreCalc(float moneyScore, float foodScore, float healthpackScore, float daysTakenMultiplier){
        float dayScore;
        
        dayScore = (moneyScore + foodScore + healthpackScore) * daysTakenMultiplier;

        return dayScore;
    }
}
