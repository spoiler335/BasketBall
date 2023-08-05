using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DI
{
    public static DI di { get; } = new DI();

    public GameManager gameManager { get; private set; }


    public void SetGameManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

}