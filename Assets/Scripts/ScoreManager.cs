using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text hieghtScoreText;

    public float scoreCount;
    public float hieghtScoreCount;
    public float pointPreSecond;

    public bool scoreIncreasing;

    void Start()
    {
        if (PlayerPrefs.HasKey("HieghtScore"))
        {
            hieghtScoreCount = PlayerPrefs.GetFloat("HieghtScore");
        }
    }  
    void FixedUpdate()
    {
        if (scoreIncreasing)
        {
            scoreCount += pointPreSecond * Time.deltaTime;
        }
        
        if (scoreCount> hieghtScoreCount)
        {
            hieghtScoreCount = scoreCount;
        }

        scoreText.text="Score: "+ Mathf.Round( scoreCount);
        hieghtScoreText.text = "Hieght Score: " + Mathf.Round(hieghtScoreCount);
        PlayerPrefs.SetFloat("HieghtScore", hieghtScoreCount);
    }
    public void AddScore(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
    }
}
