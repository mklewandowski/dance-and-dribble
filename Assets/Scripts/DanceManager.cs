using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DanceManager : MonoBehaviour
{
    [SerializeField]
    AudioManager audioManager;

    [SerializeField]
    GameSceneManager gameSceneManager;

    [SerializeField]
    GameObject GamePrompt;
    [SerializeField]
    RectTransform DanceMeter;
    [SerializeField]
    GameObject GameMeterContainer;
    [SerializeField]
    RectTransform GameMeter;

    [SerializeField]
    GameObject Steph;
    [SerializeField]
    GameObject Dray;
    ImageAnimation StephAnimation;
    ImageAnimation DrayAnimation;
    MovePattern StephMovement;
    MovePattern DrayMovement;
    MoveNormal StephMoveNormal;
    MoveNormal DrayMoveNormal;

    float danceTimer = 2f;
    float danceTimerMax = 2f;
    float danceMeterSizeMax = 290f;

    float totalDanceTime = 0f;
    float totalDanceTimeMax = 15f;
    float gameMeterSizeMax = 390f;

    float endGameTimer = 0;
    float endGameTimerMax = 1.5f;

    bool isPlaying = false;

    void Init()
    {
        StephAnimation = Steph.GetComponent<ImageAnimation>();
        DrayAnimation = Dray.GetComponent<ImageAnimation>();
        StephMovement = Steph.GetComponent<MovePattern>();
        DrayMovement = Dray.GetComponent<MovePattern>();
        StephMoveNormal = Steph.GetComponent<MoveNormal>();
        DrayMoveNormal = Dray.GetComponent<MoveNormal>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            danceTimer -= Time.deltaTime;
            if (danceTimer <= 0)
            {
                danceTimer = 0f;
                Pause();
            }
            else
            {
                totalDanceTime += Time.deltaTime;
            }
            if (totalDanceTime >= totalDanceTimeMax)
            {
                EndGame();
            }
            GamePrompt.SetActive(danceTimer <= 0);
            UpdateDanceMeterDisplay();
            UpdateGameMeterDisplay();
        }
        if (endGameTimer > 0)
        {
            endGameTimer -= Time.deltaTime;
            if (endGameTimer <= 0)
            {
                gameSceneManager.EndGame();
            }
        }
    }

    void Pause()
    {
        StephAnimation.Pause();
        DrayAnimation.Pause();
        StephMovement.Pause();
        DrayMovement.Pause();
        StephMoveNormal.Pause();
        DrayMoveNormal.Pause();
    }
    void Restart()
    {
        StephAnimation.Restart();
        DrayAnimation.Restart();
        StephMovement.Restart();
        DrayMovement.Restart();
        StephMoveNormal.Restart();
        DrayMoveNormal.Restart();
    }

    void EndGame()
    {
        audioManager.PlayWinSound();
        isPlaying = false;
        GameMeterContainer.GetComponent<GrowAndShrink>().StartEffect();
        endGameTimer = endGameTimerMax;
    }

    void UpdateDanceMeterDisplay()
    {
        DanceMeter.sizeDelta = new Vector2(danceMeterSizeMax * danceTimer / danceTimerMax, DanceMeter.sizeDelta.y);
    }
    void UpdateGameMeterDisplay()
    {
        GameMeter.sizeDelta = new Vector2(gameMeterSizeMax * totalDanceTime / totalDanceTimeMax, GameMeter.sizeDelta.y);
    }

    public void StartGame()
    {
        Init();
        danceTimer = danceTimerMax;
        totalDanceTime = 0f;
        Restart();
        isPlaying = true;
    }

    public void HandleTap()
    {
        if (!isPlaying)
            return;

        audioManager.PlayDanceSound();
        danceTimer = danceTimer + 1f;
        danceTimer = Mathf.Min(danceTimer, danceTimerMax);
        Restart();
    }
}
