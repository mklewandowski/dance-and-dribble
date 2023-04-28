using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSceneManager : MonoBehaviour
{
    AudioManager audioManager;

    [SerializeField]
    GameObject TitlePanel;

    [SerializeField]
    GameObject TextPanel;

    [SerializeField]
    GameObject DancePanel;
    [SerializeField]
    GameObject ChewPanel;
    [SerializeField]
    GameObject KickPanel;
    [SerializeField]
    GameObject FanPanel;
    [SerializeField]
    GameObject PunchPanel;
    [SerializeField]
    GameObject FashionPanel;

    bool lastWasDance = true;
    int lastMiniGame = -1;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = this.GetComponent<AudioManager>();
        TitlePanel.GetComponent<MoveNormal>().MoveDown();
    }

    public void StartGame()
    {
        audioManager.PlayStartSound();

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
        KickPanel.GetComponent<MoveNormal>().MoveUp();
        FanPanel.GetComponent<MoveNormal>().MoveUp();
        PunchPanel.GetComponent<MoveNormal>().MoveUp();
        FashionPanel.GetComponent<MoveNormal>().MoveUp();

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
        int randVal = 0;
        do {
            randVal = Random.Range(0, 5);
        } while (randVal == lastMiniGame);
        lastMiniGame = randVal;

        if (randVal == 0)
            ChooseChewGame();
        else if (randVal == 1)
            ChooseKickGame();
        else if (randVal == 2)
            ChooseFanGame();
        else if (randVal == 3)
            ChoosePunchGame();
        else if (randVal == 4)
            ChooseFashionGame();
    }

    void ChooseDanceGame()
    {
        TextPanel.GetComponent<TextDisplay>().SetNextPanel(DancePanel);
        TextPanel.SetActive(true);

        string[][] startStrings = {
            new string[] {"The game is about to start!", "We have just enough time...", "To Dance!"},
            new string[] {"You're almost ready.", "You need a little more practice...", "Dancing!"},
            new string[] {"This basketball game is gonna blow the roof off this place.", "Which reminds me...", "Let's Dance!"},
            new string[] {"Almost time for basketball.", "But before that...", "Let's Dance!"},
            new string[] {"We're seconds away from tip-off!", "Let's warm up.", "By Dancing!"},
            new string[] {"I can't wait for slam dunks and deep threes!", "Wait! Do you hear that music?", "Let's Dance!"}
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
            new string[] {"That was fun!", "But for some reason we better practice...", "Mouthpiece chomping."},
            new string[] {"Hot stuff!", "It's almost game time. But first...", "Let's chomp that mouthpiece."},
            new string[] {"You sure got it!", "We'll hit the court after...", "We chomp that mouthpiece!"}
        };
        int[] startSizes = {0, 0, 0};
        int arrayIndex = Random.Range(0, startStrings.Length);

        TextPanel.GetComponent<TextDisplay>().StartEffect(startStrings[arrayIndex], startSizes);
    }
    void ChooseKickGame()
    {
        TextPanel.GetComponent<TextDisplay>().SetNextPanel(KickPanel);
        TextPanel.SetActive(true);

        string[][] startStrings = {
            new string[] {"The game will start any minute now!", "Luckily, we can squeeze in one more practice!", "Every pro needs to perfect sack kicks."},
            new string[] {"Before the game...", "We need to work on an important skill.", "Kicking opponents in the balls."},
            new string[] {"Nice moves!", "But if you want to make it to the NBA you'll need to practice...", "Kicking opponents in the nuts."}
        };
        int[] startSizes = {0, 0, 0};
        int arrayIndex = Random.Range(0, startStrings.Length);

        TextPanel.GetComponent<TextDisplay>().StartEffect(startStrings[arrayIndex], startSizes);
    }
    void ChooseFanGame()
    {
        TextPanel.GetComponent<TextDisplay>().SetNextPanel(FanPanel);
        TextPanel.SetActive(true);

        string[][] startStrings = {
            new string[] {"Uh oh!", "The fans want the game to start.", "Give them a piece of your mind!"},
            new string[] {"Solid!", "The fans are getting impatient.", "Tell them what you think!"},
            new string[] {"There are some noisy fans in the audience.", "We can't have that.", "Let's set them straight."}
        };
        int[] startSizes = {0, 0, 0};
        int arrayIndex = Random.Range(0, startStrings.Length);

        TextPanel.GetComponent<TextDisplay>().StartEffect(startStrings[arrayIndex], startSizes);
    }
    void ChoosePunchGame()
    {
        TextPanel.GetComponent<TextDisplay>().SetNextPanel(PunchPanel);
        TextPanel.SetActive(true);

        string[][] startStrings = {
            new string[] {"Bad news. A young teammate is acting up.", "As a real pro, it's your job...", "To punch him in the face."},
            new string[] {"A rookie teammate is gloating about his contract.", "You're our only hope.", "Go punch him in the face."},
            new string[] {"A teammate outscored you in practice!", "There's only one thing that you can do...", "Punch him in the face."}
        };
        int[] startSizes = {0, 0, 0};
        int arrayIndex = Random.Range(0, startStrings.Length);

        TextPanel.GetComponent<TextDisplay>().StartEffect(startStrings[arrayIndex], startSizes);
    }
    void ChooseFashionGame()
    {
        TextPanel.GetComponent<TextDisplay>().SetNextPanel(FashionPanel);
        TextPanel.SetActive(true);

        string[][] startStrings = {
            new string[] {"It's important to look good on and off the court.", "We have a little time.", "Let's try some fashions!"},
            new string[] {"There's a sale at Clothes-Mart!", "I have my dad's credit card.", "Let's try on some hot fashions!"},
            new string[] {"A real pro needs real style.", "Maybe a fuchsia hat?", "It's fashion time!"}
        };
        int[] startSizes = {0, 0, 0};
        int arrayIndex = Random.Range(0, startStrings.Length);

        TextPanel.GetComponent<TextDisplay>().StartEffect(startStrings[arrayIndex], startSizes);
    }

}
