using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DanceManager : MonoBehaviour
{
    [SerializeField]
    GameObject GamePrompt;
    [SerializeField]
    RectTransform Timer;

    [SerializeField]
    ImageAnimation Steph;
    [SerializeField]
    ImageAnimation Dray;

    float gameTimer = 2f;
    float gameTimerMax = 2f;
    float timerSizeMax = 290f;

    float totalDanceTime = 0f;

    bool isPlaying = false;

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            gameTimer -= Time.deltaTime;
            if (gameTimer <= 0)
            {
                gameTimer = 0f;
                Steph.Pause();
                Dray.Pause();
            }
            GamePrompt.SetActive(gameTimer <= 0);
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        Timer.sizeDelta = new Vector2(timerSizeMax * gameTimer / gameTimerMax, Timer.sizeDelta.y);
    }

    public void StartGame()
    {
        isPlaying = true;
    }

    public void HandleTap()
    {
        gameTimer = gameTimer + 1f;
        gameTimer = Mathf.Min(gameTimer, gameTimerMax);
        Steph.Restart();
        Dray.Restart();
    }
}
