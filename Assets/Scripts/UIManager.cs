using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Events;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highestScoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI timeOverText;

    [SerializeField] private Button retryButton;
    [SerializeField] private Button quitButton;


    private void OnEnable()
    {
        retryButton.onClick.RemoveAllListeners();
        retryButton.onClick.AddListener(RetryLevel);

        quitButton.onClick.RemoveAllListeners();
        quitButton.onClick.AddListener(() => { Application.Quit(); });

        EventsModel.UPDATE_SCORE -= UpdateScore;
        EventsModel.UPDATE_SCORE += UpdateScore;

    }


    private void Start()
    {
        retryButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        timeOverText.gameObject.SetActive(false);
        highestScoreText.text = $"HighestScore : {DI.di.gameManager.GetHighestScore()}";
        scoreText.text = $"Score : {0}";
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        int time = 30;
        while (time >= 0)
        {
            timerText.text = $"Timer Remaning : {time}";
            --time;
            yield return new WaitForSeconds(1);
        }
        EndLevel();
    }

    private void UpdateScore(int score)
    {
        scoreText.text = $"Score : {score}";
        if (score > DI.di.gameManager.GetHighestScore())
        {
            DI.di.gameManager.SetHigestScore(score);
            highestScoreText.text = $"HighestScore : {DI.di.gameManager.GetHighestScore()}";
        }
    }

    private void EndLevel()
    {
        EventsModel.TIMER_ENDED?.Invoke();
        timeOverText.gameObject.SetActive(true);
        Time.timeScale = 0;
        retryButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    private void RetryLevel()
    {
        SceneManager.UnloadSceneAsync("GamePlay");
        Time.timeScale = 1;
        SceneManager.LoadScene("GamePlay");
    }

    private void OnDisable()
    {
        retryButton.onClick.RemoveAllListeners();
        quitButton.onClick.RemoveAllListeners();
    }
}
