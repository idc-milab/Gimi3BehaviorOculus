using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static OVRInput;

public class SceneChanger : MonoBehaviour
{
    public Controller controller;
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        
    }
    public void ChangeScene(string sceneName,GameObject Behavior)
    {
        SceneManager.LoadScene(sceneName);
        

    }
    // Update is called once per frame
    public void Exit()
    {
        Application.Quit(); 
    }
}
