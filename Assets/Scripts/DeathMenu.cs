using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public void Restart()
    {
        FindObjectOfType<GameManager>().RestartButton();
    }
    public void GoToMenu()
    {        
        SceneManager.LoadScene("MainMenu");
    }
}
