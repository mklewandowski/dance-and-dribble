using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FashionManager : MonoBehaviour
{
    [SerializeField]
    AudioManager audioManager;

    [SerializeField]
    GameSceneManager gameSceneManager;

    [SerializeField]
    Image Head;
    [SerializeField]
    Image Eyes;
    [SerializeField]
    Image Shirt;
    [SerializeField]
    Sprite[] Hats;
    [SerializeField]
    Sprite[] Glasses;
    [SerializeField]
    Sprite[] Shirts;
    [SerializeField]
    Sprite EmptySprite;

    [SerializeField]
    GameObject GameMeterContainer;
    [SerializeField]
    RectTransform GameMeter;
    float gameMeterSizeMax = 390f;

    int fashions = 0;
    int maxFashions = 10;

    float endGameTimer = 0;
    float endGameTimerMax = 2f;

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
        if (Input.GetKeyDown("space"))
        {
            HandleTap();
        }
    }

    void UpdateGameMeterDisplay()
    {
        GameMeter.sizeDelta = new Vector2(gameMeterSizeMax * (float)fashions / (float)maxFashions, GameMeter.sizeDelta.y);
    }

    public void StartGame()
    {
        fashions = 0;
        Head.sprite = EmptySprite;
        Eyes.sprite = EmptySprite;
        Shirt.sprite = EmptySprite;
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

        fashions++;
        audioManager.PlayDanceSound();
        UpdateGameMeterDisplay();
        ShowFashion();
        if (fashions >= maxFashions)
        {
            EndGame();
        }
    }

    void ShowFashion()
    {
        Head.sprite = Hats[Random.Range(0, Hats.Length - 1)];
        Eyes.sprite = Glasses[Random.Range(0, Glasses.Length - 1)];
        Shirt.sprite = Shirts[Random.Range(0, Shirts.Length - 1)];
    }
}
