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

    public float GetScore()
    {
        return this.score;
    }

    public float GetPreviousScore()
    {
        return this.previousScore;
    }

    public float UpdateScore()
    {
        previousScore = score;
        Vector3 positionDelta = transform.position - initialPosition;
        score = Mathf.Abs(positionDelta.x) + Mathf.Abs(positionDelta.y) + Mathf.Abs(positionDelta.z);
        return score;
    }

    public void ResetScore()
    {
        this.score = 0;
    }
}
