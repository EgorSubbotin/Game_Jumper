using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PouseMenu : MonoBehaviour
{
    public GameObject pouseMenu;
    public void Resume()
    {
        Time.timeScale = 1f;
        pouseMenu.SetActive(false);
    }
    public void Pouse()
    {
        pouseMenu.SetActive(true);
        Time.timeScale =0f;
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        pouseMenu.SetActive(false);
        FindObjectOfType<GameManager>().RestartButton();
    }
    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    } 
}
