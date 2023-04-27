using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAnimation : MonoBehaviour
{
    [SerializeField]
    Sprite[] AnimationFrames;

    [SerializeField]
    float frameRate = .067f;

    int currFrame = 0;
    float currTime = 0f;

    Image image;

    bool isPaused = false;

    void Start()
    {
        image = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
            return;

        if (AnimationFrames.Length > 0)
        {
            currTime += Time.deltaTime;
            currFrame = (int)Mathf.Floor(currTime / frameRate) % AnimationFrames.Length;
            image.sprite = AnimationFrames[currFrame];
        }
    }

    public void Pause()
    {
        isPaused = true;
    }
    public void Restart()
    {
        isPaused = false;
    }
}
