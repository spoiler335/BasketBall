using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using System;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private Transform refPoint;

    private int score;

    private void OnEnable()
    {
        EventsModel.BALL_LAUNCHED -= GenerateBall;
        EventsModel.BALL_LAUNCHED += GenerateBall;

        EventsModel.ADD_SCORE -= AddScore;
        EventsModel.ADD_SCORE += AddScore;

    }

    private void Start()
    {
        GenerateBall();
        score = 0;
    }

    private void AddScore()
    {
        ++score;
        EventsModel.UPDATE_SCORE?.Invoke(score);
    }

    private void GenerateBall()
    {
        GameObject ball = DI.di.ballPool.GetBall();
        if (ball != null)
        {
            ball.transform.position = refPoint.position;
            ball.SetActive(true);
        }
    }

    private void OnDisable()
    {
        EventsModel.BALL_LAUNCHED -= GenerateBall;
        EventsModel.ADD_SCORE -= AddScore;
    }
}
