using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelfieManager : MonoBehaviour
{
    [SerializeField]
    AudioManager audioManager;

    [SerializeField]
    GameSceneManager gameSceneManager;

    [SerializeField]
    GameObject Photo;
    [SerializeField]
    Image Mouth;
    [SerializeField]
    Image Eyes;
    [SerializeField]
    Sprite[] EyeSprites;
    [SerializeField]
    Sprite[] MouthSprites;
    [SerializeField]
    GameObject Flash;

    [SerializeField]
    GameObject GameMeterContainer;
    [SerializeField]
    RectTransform GameMeter;
    float gameMeterSizeMax = 390f;

    int selfies = 0;
    int maxSelfies = 6;

    float endGameTimer = 0;
    float endGameTimerMax = 2f;
    float flashTimer = 0;
    float flashTimerMax = .1f;

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
        if (flashTimer > 0)
        {
            flashTimer -= Time.deltaTime;
            if (flashTimer <= 0)
            {
                Flash.SetActive(false);
            }
        }
    }

    void UpdateGameMeterDisplay()
    {
        GameMeter.sizeDelta = new Vector2(gameMeterSizeMax * (float)selfies / (float)maxSelfies, GameMeter.sizeDelta.y);
    }

    public void StartGame()
    {
        selfies = 0;
        Flash.SetActive(false);
        Photo.SetActive(false);
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

        selfies++;
        audioManager.PlayDanceSound();
        UpdateGameMeterDisplay();
        ShowPhoto();
        if (selfies >= maxSelfies)
        {
            EndGame();
        }
    }

    void ShowPhoto()
    {
        Photo.transform.localScale = new Vector3(.1f, .1f, .1f);
        Photo.SetActive(true);
        Mouth.sprite = MouthSprites[Random.Range(0, MouthSprites.Length - 1)];
        Eyes.sprite = EyeSprites[Random.Range(0, EyeSprites.Length - 1)];
        Photo.GetComponent<GrowAndShrink>().StartEffect();
        Flash.SetActive(true);
        flashTimer = flashTimerMax;
    }
}
