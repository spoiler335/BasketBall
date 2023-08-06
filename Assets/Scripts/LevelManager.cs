using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using System;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private Transform refPoint;

    private void OnEnable()
    {
        EventsModel.BALL_LAUNCHED -= GenerateBall;
        EventsModel.BALL_LAUNCHED += GenerateBall;
    }


    private void Start()
    {

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
    }
}
