using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePattern : MonoBehaviour
{
    [SerializeField]
    float[] movementPositions = {-150f, 0, 150f, 0};
    private float movementTimer = 2f;
    private float movementTimerMax = 2f;
    private int posNum = 0;
    private float currPos;

    bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        currPos = movementPositions[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
            return;

        movementTimer -= Time.deltaTime;
        if (movementTimer < 0)
        {
            currPos = movementPositions[posNum];
            posNum++;
            if (posNum >= movementPositions.Length)
                posNum = 0;
            float movementPos = movementPositions[posNum];

            if (currPos < movementPos)
            {
                this.GetComponent<MoveNormal>().SetMovingRightEndPos(new Vector2(movementPos, 0));
                this.GetComponent<MoveNormal>().MoveRight();
            }
            else
            {
                this.GetComponent<MoveNormal>().SetMovingLeftEndPos(new Vector2(movementPos, 0));
                this.GetComponent<MoveNormal>().MoveLeft();
            }
            movementTimer = movementTimerMax;
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
