using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChewManager : MonoBehaviour
{
    [SerializeField]
    AudioManager audioManager;

    [SerializeField]
    GameSceneManager gameSceneManager;

    [SerializeField]
    Image Steph;
    [SerializeField]
    Sprite CloseSprite;
    [SerializeField]
    Sprite OpenSprite;

    [SerializeField]
    GameObject GameMeterContainer;
    [SerializeField]
    RectTransform GameMeter;
    float gameMeterSizeMax = 390f;

    int chews = 0;
    int maxChews = 15;
    bool close = true;

    float endGameTimer = 0;
    float endGameTimerMax = 1f;

    bool isPlaying = false;

    void Update()
    {
        if (endGameTimer > 0)
        {
            endGameTimer -= Time.deltaTime;
            if (endGameTimer <= 0)
            {
                gameSceneManager.EndGame();
            }
        }
    }

    void UpdateGameMeterDisplay()
    {
        GameMeter.sizeDelta = new Vector2(gameMeterSizeMax * (float)chews / (float)maxChews, GameMeter.sizeDelta.y);
    }

    public void StartGame()
    {
        chews = 0;
        Steph.sprite = CloseSprite;
        UpdateGameMeterDisplay();
        isPlaying = true;
    }

    void EndGame()
    {
        audioManager.PlayWinSound();
        isPlaying = false;
        GameMeterContainer.GetComponent<GrowAndShrink>().StartEffect();
        endGameTimer = endGameTimerMax;
    }

    public void HandleTap()
    {
        if (!isPlaying)
            return;

        close = !close;
        if (close)
        {
            chews++;
            audioManager.PlayChewSound();
            UpdateGameMeterDisplay();
            Steph.sprite = CloseSprite;
            if (chews >= maxChews)
            {
                EndGame();
            }
        }
        else
        {
            Steph.sprite = OpenSprite;
        }
    }
}
