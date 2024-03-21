using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public PointGivingObject[] pointGivingObjects;
    public float totalScore;
    private float time = 0f;
    public float scoreUpdateInterval = 2f;


    void Start()
    {
        pointGivingObjects = FindObjectsOfType(typeof(PointGivingObject)) as PointGivingObject[];
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > scoreUpdateInterval)
        {
            UpdateTotalScore();
            PrintScore();
            time = 0f;
        }
    }

    void UpdateTotalScore()
    {
        foreach (PointGivingObject obj in pointGivingObjects)
        {
            obj.UpdateScore();
            float objPreviousScore = obj.GetPreviousScore();
            float objScore = obj.GetScore();

            // Only add to total score is there was an update in an object's score.
            if (!Mathf.Approximately(objScore, objPreviousScore))
            {
                totalScore += objScore - objPreviousScore;
            }
        }
    }

    void PrintScore()
    {
        Debug.Log("The current score is: " + totalScore);
    }
}
