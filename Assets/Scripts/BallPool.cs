using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using System;

public class BallPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> balls;


    private void OnEnable()
    {
        EventsModel.BALL_TOUCHED_GROUND -= DisableBall;
        EventsModel.BALL_TOUCHED_GROUND += DisableBall;
    }

    private void Start()
    {
        DI.di.SetBallPooler(this);
        for (int i = 0; i < balls.Count; ++i)
        {
            balls[i].SetActive(false);
        }
    }

    public GameObject GetBall()
    {
        for (int i = 0; i < balls.Count; ++i)
        {
            if (!balls[i].activeInHierarchy)
            {
                return balls[i];
            }
        }
        return null;
    }

    private void DisableBall(GameObject ball)
    {
        if (ball != null) ball.SetActive(false);
    }


    private void OnDisable()
    {
        EventsModel.BALL_TOUCHED_GROUND -= DisableBall;
    }

}
