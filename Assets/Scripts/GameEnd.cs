using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public Text finalScore;
    

    void Start()
    {
        finalScore = GameObject.Find("FinalScore").GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
