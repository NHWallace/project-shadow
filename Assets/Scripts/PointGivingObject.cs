using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointGivingObject : MonoBehaviour
{
    private Vector3 initialPosition;
    private float score = 0;
    private float previousScore = 0;


    void Start()
    {
        initialPosition = transform.position;
    }

    public float getScore()
    {
        return this.score;
    }

    public float getPreviousScore()
    {
        return this.previousScore;
    }

    public float updateScore()
    {
        previousScore = score;
        Vector3 positionDelta = transform.position - initialPosition;
        score = Mathf.Abs(positionDelta.x) + Mathf.Abs(positionDelta.y) + Mathf.Abs(positionDelta.z);
        return score;
    }

    public void resetScore()
    {
        this.score = 0;
    }
}
