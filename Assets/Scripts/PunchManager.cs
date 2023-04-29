using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PunchManager : MonoBehaviour
{
    [SerializeField]
    AudioManager audioManager;

    [SerializeField]
    GameSceneManager gameSceneManager;

    [SerializeField]
    Image Dray;
    [SerializeField]
    Sprite PunchSprite;
    [SerializeField]
    Sprite RegularSprite;
    [SerializeField]
    GameObject OtherPlayer;

    [SerializeField]
    GameObject GameMeterContainer;
    [SerializeField]
    RectTransform GameMeter;
    float gameMeterSizeMax = 390f;

    int punches = 0;
    int maxPunches = 10;

    float punchTimer = 0f;
    float punchTimerMax = .2f;
    bool scoreThisPunch = false;

    float playerTimer = .5f;
    float playerTimerMax = 2f;
    bool movinDown = true;

    float endGameTimer = 0;
    float endGameTimerMax = 1.5f;

    bool isPlaying = false;

    // Update is called once per frame
    void Update()
    {
        if (punchTimer > 0)
        {
            if (OtherPlayer.transform.localPosition.y < -180f && !scoreThisPunch)
            {
                // punch!
                scoreThisPunch = true;
                audioManager.PlayHitSound();
                punches++;
                UpdateGameMeterDisplay();
                if (punches >= maxPunches)
                {
                    EndGame();
                }
            }
            punchTimer -= Time.deltaTime;
            if (punchTimer <= 0)
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
                movinDown = !movinDown;
                if (movinDown)
                    OtherPlayer.GetComponent<MoveNormal>().MoveDown();
                else
                    OtherPlayer.GetComponent<MoveNormal>().MoveUp();
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
        GameMeter.sizeDelta = new Vector2(gameMeterSizeMax * (float)punches / (float)maxPunches, GameMeter.sizeDelta.y);
    }

    public void StartGame()
    {
        punches = 0;
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
        if (!isPlaying || punchTimer > 0)
            return;

        audioManager.PlayKickSound();
        Dray.sprite = PunchSprite;
        punchTimer = punchTimerMax;
        scoreThisPunch = false;
    }
}
