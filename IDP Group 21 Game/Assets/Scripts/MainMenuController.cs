using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LivingRoom()
    {
        SceneManager.LoadScene("LivingRoom");
    }
    
    public void Hallway()
    {
        SceneManager.LoadScene("Hallway");
    }
}
