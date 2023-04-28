using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefManager : MonoBehaviour
{
    [SerializeField]
    AudioManager audioManager;

    [SerializeField]
    GameSceneManager gameSceneManager;

    [SerializeField]
    GameObject Scream;
    [SerializeField]
    GameObject Ref;
    [SerializeField]
    GameObject Tech;

    [SerializeField]
    GameObject GameMeterContainer;
    [SerializeField]
    RectTransform GameMeter;
    float gameMeterSizeMax = 390f;

    int screams = 0;
    int screamsMax = 6;

    float screamTimer = 0f;
    float screamTimerMax = .5f;
    bool scoreThisKick = false;

    float refTimer = 1f;
    float refTimerMax = 2f;
    bool notLooking = true;

    float endGameTimer = 0;
    float endGameTimerMax = 1.5f;

    bool isPlaying = false;

    // Update is called once per frame
    void Update()
    {
        if (screamTimer > 0)
        {
            screamTimer -= Time.deltaTime;
            if (screamTimer <= 0)
            {
                Scream.SetActive(false);
            }
        }
        if (refTimer > 0)
        {
            refTimer -= Time.deltaTime;
            if (refTimer <= 0)
            {
                refTimer = refTimerMax;
                notLooking = !notLooking;
                if (notLooking)
                    Ref.transform.localScale = new Vector3(-10f, 10f, 1f);
                else
                    Ref.transform.localScale = new Vector3(10f, 10f, 1f);
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
    }

    void UpdateGameMeterDisplay()
    {
        GameMeter.sizeDelta = new Vector2(gameMeterSizeMax * (float)screams / (float)screamsMax, GameMeter.sizeDelta.y);
    }

    public void StartGame()
    {
        screams = 0;
        Tech.SetActive(false);
        Scream.SetActive(false);
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
        if (!isPlaying || screamTimer > 0)
            return;

        audioManager.PlayScreamSound();
        if (notLooking)
        {
            screams++;
        }
        else
        {
            refTimer = refTimer + 1f;
            screams--;
            if (screams < 0)
                screams = 0;

            Tech.transform.localScale = new Vector3(.1f, .1f, .1f);
            Tech.SetActive(true);
            Tech.GetComponent<GrowAndShrink>().StartEffect();
            Tech.GetComponent<TimedHide>().StartEffect();
            audioManager.PlayTechSound();
        }

        UpdateGameMeterDisplay();
        if (screams >= screamsMax)
        {
            EndGame();
        }
        Scream.SetActive(true);
        screamTimer = screamTimerMax;

    }
}
