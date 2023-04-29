using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KickManager : MonoBehaviour
{
    [SerializeField]
    AudioManager audioManager;

    [SerializeField]
    GameSceneManager gameSceneManager;

    [SerializeField]
    Image Dray;
    [SerializeField]
    Sprite KickSprite;
    [SerializeField]
    Sprite RegularSprite;
    [SerializeField]
    GameObject OtherPlayer;

    [SerializeField]
    GameObject GameMeterContainer;
    [SerializeField]
    RectTransform GameMeter;
    float gameMeterSizeMax = 390f;

    int kicks = 0;
    int maxKicks = 10;

    float kickTimer = 0f;
    float kickTimerMax = .2f;
    bool scoreThisKick = false;

    float playerTimer = .5f;
    float playerTimerMax = 2f;
    bool movingLeft = true;

    float endGameTimer = 0;
    float endGameTimerMax = 1.5f;

    bool isPlaying = false;

    // Update is called once per frame
    void Update()
    {
        if (kickTimer > 0)
        {
            if (OtherPlayer.transform.localPosition.x < -105f && !scoreThisKick)
            {
                // kick!
                scoreThisKick = true;
                audioManager.PlayHitSound();
                kicks++;
                UpdateGameMeterDisplay();
                if (kicks >= maxKicks)
                {
                    EndGame();
                }
            }
            kickTimer -= Time.deltaTime;
            if (kickTimer <= 0)
            {
                Dray.sprite = RegularSprite;
            }
        }
        if (playerTimer > 0)
        {
            playerTimer -= Time.deltaTime;
            if (playerTimer <= 0)
            {
                playerTimer = playerTimerMax;
                movingLeft = !movingLeft;
                if (movingLeft)
                    OtherPlayer.GetComponent<MoveNormal>().MoveLeft();
                else
                    OtherPlayer.GetComponent<MoveNormal>().MoveRight();
            }
        }
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
        GameMeter.sizeDelta = new Vector2(gameMeterSizeMax * (float)kicks / (float)maxKicks, GameMeter.sizeDelta.y);
    }

    public void StartGame()
    {
        kicks = 0;
        Dray.sprite = RegularSprite;
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
        if (!isPlaying || kickTimer > 0)
            return;

        audioManager.PlayKickSound();
        Dray.sprite = KickSprite;
        kickTimer = kickTimerMax;
        scoreThisKick = false;
    }
}
