using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private const string PPF_HIGHEST_SOCRE = "highest_score";

    private int highestScore;

    private void Start()
    {
        DI.di.SetGameManager(this);
        
        highestScore = PlayerPrefs.GetInt(PPF_HIGHEST_SOCRE, 0);
    }

    public int GetHighestScore()
    {
        return highestScore;
    }

    public void SetHigestScore(int score)
    {
        highestScore = score;
        PlayerPrefs.SetInt(PPF_HIGHEST_SOCRE, highestScore);
    }

}
