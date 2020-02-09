using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    Vector3 platformStartPoint;

    public PlayerCntroller thePlayer;
    Vector3 playerStartPoint;

    PlatformDestroy[] platformList;
    
    ScoreManager theScoreManager;

    public DeathMenu theDeathMenu;
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        theScoreManager = FindObjectOfType<ScoreManager>();        
    }    
    public void RestartGame()
    {
        thePlayer.gameObject.SetActive(false);
        theScoreManager.scoreIncreasing = false;
        theDeathMenu.gameObject.SetActive(true);
        // StartCoroutine(RestartGameCo());
    }
    public void RestartButton()
    {
        theDeathMenu.gameObject.SetActive(false);
        platformList = FindObjectsOfType<PlatformDestroy>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0f;
        theScoreManager.scoreIncreasing = true;
    }
     /*public IEnumerator RestartGameCo()
     {
        thePlayer.gameObject.SetActive(false);
        theScoreManager.scoreIncreasing = false;
        yield return new WaitForSeconds(.5f);
        platformList = FindObjectsOfType<PlatformDestroy>();
        for (int i=0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }        
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0f;
        theScoreManager.scoreIncreasing = true;

     }*/
    
}
