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
        TextPanel.GetComponent<TextDisplay>().SetNextPanel(ChewPanel);
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

        TextPanel.GetComponent<TextDisplay>().SetNextPanel(DancePanel);
        TextPanel.SetActive(true);

        string[] startStrings = {"Almost time for basketball", "But before that...", "Let's Dance!"};
        int[] startSizes = {0, 0, 1};

        TextPanel.GetComponent<TextDisplay>().StartEffect(startStrings, startSizes);


    }

}
