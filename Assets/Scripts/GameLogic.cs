using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public float firstPosition;
    public int spawnName;
    public string targetNote;
    public string targetKey;
    public bool correct;

    void Start()
    {
        firstPosition = 10;
        correct = false;
    }

    void Update()
    {
        targetKey = targetNote;
    }
}
