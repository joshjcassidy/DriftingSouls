using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public string sceneToLoad;
    public Vector2 playerPosition;
    public OnLoadPosition playerStorage;

    //public Vector2 initialPos = new Vector2(-32.68f, 52.26f);

    // Start is called before the first frame update
    void Start()
    {
        //playerStorage.initialValue = initialPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player") && !collision.isTrigger){
            playerStorage.initialValue = playerPosition;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
