using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public Text finalScore;
    float highScore;

    //This should take you back tot he home screen, and reset the highScore.
    private void OnMouseDown()
    {
        PlayerPrefs.SetFloat("highScore", 0);
        SceneManager.LoadScene(0);
    }

    void Start()
    {
        finalScore = GameObject.Find("FinalScore").GetComponent<Text>();
        highScore = PlayerPrefs.GetFloat("highScore");
        finalScore.text = ((int)highScore).ToString();
    }
}
