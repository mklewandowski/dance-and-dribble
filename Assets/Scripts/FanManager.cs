using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FanManager : MonoBehaviour
{
    [SerializeField]
    AudioManager audioManager;

    [SerializeField]
    GameSceneManager gameSceneManager;

    [SerializeField]
    Image Dray;
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
    GameObject[] CurseContainers;
    [SerializeField]
    TextMeshProUGUI[] CurseTexts;
    int curseIndex = 0;

    int curses = 0;
    int maxCurses = 9;
    bool close = true;

    float endGameTimer = 0;
    float endGameTimerMax = 1f;

    bool isPlaying = false;

    string[] curseCharacters = {"q", "w", "r", "t", "y", "p", "s", "d", "f", "g", "h", "j", "k", "l", "z", "x", "c", "v", "b", "n", "m",
        "r", "s", "t", "l", "n", "r", "s", "t", "l", "n", "r", "s", "t", "l", "n", "r", "s", "t", "l", "n"};
    string[] cursePeople = {" YOU", " HER", " HIM", " Y'ALL"};

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
        GameMeter.sizeDelta = new Vector2(gameMeterSizeMax * (float)curses / (float)maxCurses, GameMeter.sizeDelta.y);
    }

    public void StartGame()
    {
        curses = 0;
        curseIndex = 0;
        Dray.sprite = CloseSprite;
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
            Dray.sprite = CloseSprite;
        }
        else
        {
            Dray.sprite = OpenSprite;
            curses++;
            audioManager.PlayCurseSound();
            UpdateGameMeterDisplay();
            ShowCurse();
            curseIndex++;
            if (curseIndex >= CurseContainers.Length)
                curseIndex = 0;
            if (curses >= maxCurses)
            {
                EndGame();
            }
        }
    }

    void ShowCurse()
    {
        string curseString = "";
        int charIndex = Random.Range(0, curseCharacters.Length);
        curseString = curseString + curseCharacters[charIndex];
        curseString = curseString + "**";
        charIndex = Random.Range(0, curseCharacters.Length);
        curseString = curseString + curseCharacters[charIndex];
        charIndex = Random.Range(0, cursePeople.Length);
        curseString = curseString + cursePeople[charIndex];
        curseString = curseString + "!!!";
        CurseTexts[curseIndex].text = curseString;
        CurseContainers[curseIndex].transform.localScale = new Vector3(.1f, .1f, .1f);
        CurseContainers[curseIndex].SetActive(true);
        CurseContainers[curseIndex].GetComponent<GrowAndShrink>().StartEffect();
        CurseContainers[curseIndex].GetComponent<TimedHide>().StartEffect();
    }
}
