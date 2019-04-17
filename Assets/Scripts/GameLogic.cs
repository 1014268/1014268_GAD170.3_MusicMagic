using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public float firstPosition;
    public int spawnName;
    public string targetNote;
    public string targetKey;
    public bool correct;
    public bool launch;
    public float addScore;
    public float score;
    public UI;

    void scoreUpdate()
    {
        if(addScore>0)
        {
            score = +addScore;
            currentScore.text = score.ToString();
        }
        else
        {

        }
    }
    void Start()
    {
        firstPosition = 10;
        score = 0;
        currentScore = GameObject.Find("CurrentScore").GetComponent<Text>();
        correct = false;
        launch = false;
    }

    void Update()
    {
        targetKey = targetNote;
        scoreUpdate();
    }
}
