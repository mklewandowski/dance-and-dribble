using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChewManager : MonoBehaviour
{
    [SerializeField]
    GameSceneManager gameSceneManager;

    [SerializeField]
    Image Steph;
    [SerializeField]
    Sprite CloseSprite;
    [SerializeField]
    Sprite OpenSprite;

    [SerializeField]
    RectTransform GameMeter;
    float gameMeterSizeMax = 390f;

    int chews = 0;
    int maxChews = 15;
    bool close = true;

    bool isPlaying = false;

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
        isPlaying = false;
        gameSceneManager.EndGame();
    }

    public void HandleTap()
    {
        if (!isPlaying)
            return;

        close = !close;
        if (close)
        {
            chews++;
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
