using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon : MonoBehaviour
{

    private static Dictionary<string, GameObject> items = new Dictionary<string, GameObject>();

    [SerializeField] private string singletonId = "";

    private void Awake()
    {
        if (string.IsNullOrEmpty(singletonId)) throw new System.Exception("SingletonGameObject :: singletonId is empty");

        if (items.ContainsKey(singletonId))
        {
            Destroy(gameObject);
            return;
        }

        items.Add(singletonId, gameObject);
        DontDestroyOnLoad(gameObject);
    }

}
