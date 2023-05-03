using System.Collections;                                         
using System.Collections.Generic;         
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;                                                                       

public class sceneSelection : MonoBehaviour
{
     
    private void Start()
    {
      
    }
    /*simple version
    public void goTo(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        levelBox.text = levelName;
        sceneMessage.text = levelMessage;               
        
    }
    */


    public void goToStart()
    {
        SceneManager.LoadScene("start");
        
       
    }

    public void goToMiddle()
    {
        SceneManager.LoadScene("gameplay");
     
    }

    public void goToEnd()
    {

    SceneManager.LoadScene("gameover");

    }

}
