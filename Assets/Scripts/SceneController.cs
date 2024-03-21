using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class SceneController : MonoBehaviour
{
    public PointGivingObject[] pointGivingObjects;
    public float totalScore;
    private float time = 0f;
    public float scoreUpdateInterval = 2f;

    [SerializeField] private TMP_Text scoreText;


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
            scoreText.text = $"Score: {(int)totalScore}";

        }
    }

    void PrintScore()
    {
        Debug.Log("The current score is: " + totalScore);
    }
}
