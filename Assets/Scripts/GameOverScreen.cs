using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
     public Text dialogText;

     public FloatValue score;
    
    // Start is called before the first frame update
    void Start()
    {   
        dialogText.text = "Your Score: " + score.RuntimeValue;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Application.Quit();
        }
    }
}
