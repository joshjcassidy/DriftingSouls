using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudTextDisplay : MonoBehaviour
{
    public FloatValue score;
    public FloatValue food;
    public FloatValue healthPacks;

    public Text scoreText;
    public Text foodText;
    public Text healthPackText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.RuntimeValue;
        foodText.text = "Food: " + food.RuntimeValue;
        healthPackText.text = "First Aids: " + healthPacks.RuntimeValue;
    }
}
