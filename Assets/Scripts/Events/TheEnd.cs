using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{

    //the variable with the name of the last scene
    public string SceneToLoad;

    //timer to control when the end scene will must be load
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /// <summary>
    /// This Update will have a timer to stop the scene and go to the last one
    /// </summary>
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        


        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}
