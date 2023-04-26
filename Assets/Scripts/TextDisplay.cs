using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDisplay : MonoBehaviour
{
    [SerializeField]
    GameObject[] TextObjects;

    [SerializeField]
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
                foreach(GameObject go in TextObjects)
                {
                    go.SetActive(false);
                }
                if (textNum < TextObjects.Length)
                {
                    // show a text item
                    TextObjects[textNum].transform.localScale = new Vector3(.1f, .1f, .1f);
                    TextObjects[textNum].SetActive(true);
                    TextObjects[textNum].GetComponent<GrowAndShrink>().StartEffect();

                    textNum++;
                    delayTimer = delayTimerMax;
                }
                else
                {
                    NextPanel.SetActive(true);
                    this.gameObject.SetActive(true);
                }
            }
        }
    }

    public void StartEffect()
    {
        delayTimer = 1f;
        textNum = 0;
    }
}
