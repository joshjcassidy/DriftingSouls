using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public Vector2 playerPosition;
    public OnLoadPosition playerStorage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            playerStorage.initialValue = playerPosition;
            SceneManager.LoadScene("1-1Storage");
        }
    }
}
