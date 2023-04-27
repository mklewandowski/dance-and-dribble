using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDisplay : MonoBehaviour
{
    [SerializeField]
    GameObject LargeText;
    [SerializeField]
    GameObject SmallText;

    List<string> TextStrings = new List<string>();
    // 0 small, 1 big
    List<int> TextSizes = new List<int>();

    GameObject NextPanel;

    int textNum = 0;

    float delayTimer = 0f;
    float delayTimerMax = 2.5f;

    // Update is called once per frame
    void Update()
    {
        if (delayTimer > 0)
        {
            delayTimer -= Time.deltaTime;
            if (delayTimer <= 0)
            {
                SmallText.SetActive(false);
                LargeText.SetActive(false);
                if (textNum < TextStrings.Count)
                {
                    // show a text item
                    if (TextSizes[textNum] == 0)
                    {
                        SmallText.GetComponent<TextMeshProUGUI>().text = TextStrings[textNum];
                        SmallText.transform.localScale = new Vector3(.1f, .1f, .1f);
                        SmallText.SetActive(true);
                        SmallText.GetComponent<GrowAndShrink>().StartEffect();
                    }
                    else
                    {
                        LargeText.GetComponent<TextMeshProUGUI>().text = TextStrings[textNum];
                        LargeText.transform.localScale = new Vector3(.1f, .1f, .1f);
                        LargeText.SetActive(true);
                        LargeText.GetComponent<GrowAndShrink>().StartEffect();
                    }

                    textNum++;
                    delayTimer = delayTimerMax;
                }
                else
                {
                    NextPanel.SetActive(true);
                    NextPanel.GetComponent<MoveNormal>().MoveDown();
                    DanceManager dm = NextPanel.GetComponent<DanceManager>();
                    if (dm != null)
                        dm.StartGame();
                    this.gameObject.SetActive(false);
                    ChewManager cm = NextPanel.GetComponent<ChewManager>();
                    if (cm != null)
                        cm.StartGame();
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    public void SetNextPanel(GameObject nextPanel)
    {
        NextPanel = nextPanel;
    }

    public void StartEffect(string[] textStrings, int[] textSizes)
    {
        SmallText.SetActive(false);
        LargeText.SetActive(false);

        TextStrings.Clear();
        TextSizes.Clear();

        foreach(string ts in textStrings)
        {
            TextStrings.Add(ts);
        }
        foreach(int ts in textSizes)
        {
            TextSizes.Add(ts);
        }
        delayTimer = 1f;
        textNum = 0;
    }
}
