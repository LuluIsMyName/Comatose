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
    
    public void Bathroom()
    {
        SceneManager.LoadScene("Bathroom");
    }

    public void CorbinsRoom()
    {
        SceneManager.LoadScene("CorbinsRoom");
    }

    public void Kitchen()
    {
        SceneManager.LoadScene("Kitchen");
    }

    public void Dining()
    {
        SceneManager.LoadScene("Dining");
    }

    public void HectorAndMcBedroom()
    {
        SceneManager.LoadScene("HectorAndMcBedroom");
    }
    public void Office()
    {
        SceneManager.LoadScene("Office");
    }
    
    public void ParentsRoom()
    {
        SceneManager.LoadScene("ParentsRoom");
    }
}
