using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedHide : MonoBehaviour
{
    [SerializeField]
    float displayTimerMax = 2f;
    float displayTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (displayTimer > 0)
        {
            displayTimer -= Time.deltaTime;
            if (displayTimer <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    public void StartEffect()
    {
        displayTimer = displayTimerMax;
    }
}
