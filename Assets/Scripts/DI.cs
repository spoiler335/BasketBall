using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DI
{
    public static DI di { get; } = new DI();

    public void Sample()
    {
        Debug.Log("DI is working");
    }

}