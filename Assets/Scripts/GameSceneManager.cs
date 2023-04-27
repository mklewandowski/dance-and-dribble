using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField]
    GameObject TitlePanel;

    [SerializeField]
    GameObject TextPanel;

    [SerializeField]
    GameObject DancePanel;
    [SerializeField]
    GameObject ChewPanel;

    bool lastWasDance = true;

    // Start is called before the first frame update
    void Start()
    {
        TitlePanel.GetComponent<MoveNormal>().MoveDown();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        TitlePanel.GetComponent<MoveNormal>().MoveUp();
        TextPanel.GetComponent<TextDisplay>().SetNextPanel(DancePanel);
        lastWasDance = true;
        TextPanel.SetActive(true);

        string[] startStrings = {"Are you ready for an EXCITING game of basketball?","ME TOO!", "But before we start...", "Let's Dance!"};
        int[] startSizes = {0, 0, 0, 1};

        TextPanel.GetComponent<TextDisplay>().StartEffect(startStrings, startSizes);
    }

    public void EndGame()
    {
        // hide all game panels
        DancePanel.GetComponent<MoveNormal>().MoveUp();
        ChewPanel.GetComponent<MoveNormal>().MoveUp();

        if (lastWasDance)
        {
            ChooseNextGame();
            lastWasDance = false;
        }
        else
        {
            ChooseDanceGame();
            lastWasDance = true;
        }
    }

    void ChooseNextGame()
    {
        ChooseChewGame();
    }

    void ChooseDanceGame()
    {
        TextPanel.GetComponent<TextDisplay>().SetNextPanel(DancePanel);
        TextPanel.SetActive(true);

        string[][] startStrings = {
            new string[] {"The game is about to start!", "We have just enough time...", "To Dance!"},
            new string[] {"You're almost ready.", "You need a little more practice...", "Dancing!"},
            new string[] {"This basketball game is gonna blow the roof off this place.", "Which reminds me...", "Let's Dance!"},
            new string[] {"Almost time for basketball.", "But before that...", "Let's Dance!"}
        };
        int[] startSizes = {0, 0, 1};
        int arrayIndex = Random.Range(0, startStrings.Length);

        TextPanel.GetComponent<TextDisplay>().StartEffect(startStrings[arrayIndex], startSizes);
    }
    void ChooseChewGame()
    {
        TextPanel.GetComponent<TextDisplay>().SetNextPanel(ChewPanel);
        TextPanel.SetActive(true);

        string[][] startStrings = {
            new string[] {"That was fun!", "Better practice...", "Mouthpiece Chewing!"},
            new string[] {"Hot stuff!", "It's almost game time. But first...", "Mouthpiece Chewing!"},
            new string[] {"You sure got it!", "We'll hit the court after...", "Mouthpiece Chewing!"}
        };
        int[] startSizes = {0, 0, 1};
        int arrayIndex = Random.Range(0, startStrings.Length);

        TextPanel.GetComponent<TextDisplay>().StartEffect(startStrings[arrayIndex], startSizes);
    }

}
