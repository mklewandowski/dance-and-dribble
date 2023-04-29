using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MediaManager : MonoBehaviour
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

    [SerializeField]
    TextMeshProUGUI[] SmartTexts;

    int phrases = 0;
    int maxPhrases = 3;
    bool close = true;
    int phraseIndex = 0;

    float phraseTimer = .1f;
    float phaseTimerMax = .1f;

    float talkTimer = 0f;
    float talkTimerMax = .25f;

    float endGameTimer = 0;
    float endGameTimerMax = 2f;

    bool isPlaying = false;

    string[][] phraseStrings = {
        new string[] {"AT THE END OF THE DAY", "TO BE HONEST", "ALL I KNOW IS", "FOR WHAT IT'S WORTH", "IN THE END", "FOR NOW", "WHEN YOU ADD IT UP", "BOTTOMLINE"},
        new string[] {"MY TEAM", "MY FAMILY", "THE TITLE", "THIS FRANCHISE", "THE CHAMPIONSHIP", "THIS CITY", "THIS TEAM", "HOT N SPICY BBQ CHIPS", "THAT KID", "THAT ORPHAN", "THAT SICK FAN", "THE COMMUNITY", "THIS STATE", "THIS COUNTRY"},
        new string[] {"IS EVERYTHING", "IS ALL THAT MATTERS", "IS THE ONLY THING", "IS WHAT IT'S ABOUT", "IS WHERE MY HEART IS"}
    };

    void Update()
    {
        if (phraseTimer > 0 && phrases < maxPhrases)
        {
            phraseTimer -= Time.deltaTime;
            if (phraseTimer <= 0)
            {
                phraseTimer = phaseTimerMax;
                phraseIndex++;
                if (phraseIndex >= phraseStrings[phrases].Length)
                    phraseIndex = 0;

                SmartTexts[phrases].text = phraseStrings[phrases][phraseIndex];
            }
        }
        if (talkTimer > 0)
        {
            talkTimer -= Time.deltaTime;
            if (talkTimer <= 0)
            {
                Steph.sprite = CloseSprite;
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
        GameMeter.sizeDelta = new Vector2(gameMeterSizeMax * (float)phrases / (float)maxPhrases, GameMeter.sizeDelta.y);
    }

    public void StartGame()
    {
        foreach(TextMeshProUGUI st in SmartTexts)
        {
            st.text = "";
        }
        phrases = 0;
        phraseIndex = 0;
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

        Steph.sprite = OpenSprite;
        talkTimer = talkTimerMax;
        phrases++;
        audioManager.PlayDanceSound();
        UpdateGameMeterDisplay();

        phraseIndex = 0;
        if (phrases >= maxPhrases)
        {
            EndGame();
        }

    }
}
