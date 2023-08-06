using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
    [SerializeField] private Slider progressSlider;

    void Start()
    {
        progressSlider.value = 0;
        progressSlider.maxValue = 1;
        StartCoroutine(StartLevel());
    }

    private IEnumerator StartLevel()
    {
        while (progressSlider.value < 1)
        {
            progressSlider.value += 0.001f;
            yield return null;
        }
        SceneManager.UnloadSceneAsync("Init");
        SceneManager.LoadScene("GamePlay");
    }

}
