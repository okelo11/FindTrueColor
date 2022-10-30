using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
   public GameObject restartPanel;


    public void StartGameButton()
    {
        SceneManager.LoadScene(1);
    }
    public void RestartGameButton()
    {
       
        SceneManager.LoadScene(1);
        
    }
}
