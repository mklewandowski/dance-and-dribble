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
        TextPanel.SetActive(true);
        TextPanel.GetComponent<TextDisplay>().StartEffect();
    }

}
