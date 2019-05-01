using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public int progress;
    public Text currentScore;
    public TextSpawn textSpawn;
    public Text currentProgress;
    public Text finalScore;
    
    
    void scoreUpdate()
    {
        if(addScore > 0)
        {
            score += addScore;
            currentScore.text = ((int)score).ToString();
            addScore = 0;
            textSpawn.spawn = true;
        }
        else if(addScore < 0)
        {
            score += addScore;
            currentScore.text = ((int)score).ToString();
            addScore = 0;
        }
    }

    void progressUpdate()
    {
        currentProgress.text = progress.ToString() + "/20";
    }

    void endRound()
    {
        if(progress == 20)
        {
            finalScore.text = score.ToString();
            SceneManager.LoadScene(2);
        }
    }
    
    void Start()
    {
        firstPosition = 10;
        score = 0;
        currentScore = GameObject.Find("CurrentScore").GetComponent<Text>();
        currentProgress = GameObject.Find("CurrentProgress").GetComponent<Text>();
        textSpawn = GameObject.Find("TextSpawnPoints").GetComponent<TextSpawn>();
        finalScore = GameObject.Find("FinalScore").GetComponent<Text>();
        correct = false;
        launch = false;
        progress = 0;
    }

    void Update()
    {
        targetKey = targetNote;
        scoreUpdate();
        progressUpdate();
        endRound();
    }
}
