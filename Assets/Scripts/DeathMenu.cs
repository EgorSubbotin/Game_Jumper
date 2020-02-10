using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject puoseButton;
    public void Restart()
    {
        puoseButton.SetActive(true);
        FindObjectOfType<GameManager>().RestartButton();
    }
    public void GoToMenu()
    {        
        SceneManager.LoadScene("MainMenu");
    }
}
