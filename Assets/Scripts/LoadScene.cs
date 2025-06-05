using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class LoadScene : MonoBehaviour
{

    public void ChangeScene(string name)
    {
       SceneManager.LoadScene(name);    
    }

    public void paused()
    {
        Time.timeScale = 0;
    }

    public void resume()
    {
        Time.timeScale = 1;
    }

    void Start(){

    }
    void Update(){
        
    }
}
