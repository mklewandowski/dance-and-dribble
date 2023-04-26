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
        TextPanel.SetActive(true);
        TextPanel.GetComponent<TextDisplay>().StartEffect();
    }

}
