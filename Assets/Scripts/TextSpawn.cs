using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpawn : MonoBehaviour
{
    GameLogic gameLogic;
    NoteLogic noteLogic;
    public GameObject[] textPrefab;
    public GameObject[] textClone;
    public Transform[] spawnPoints;

    public bool spawn;
    public float whichText;
    public int spawnWhere;
    int addTextValue;

    //This determines which text to spawn, based on a notes distance from the action bar
    void spawnText()
    {
        if (spawn == true)
        {
            spawnWhere = Random.Range(0, 10);
            if (whichText>0)
            {
                textClone[0] = Instantiate(textPrefab[0], spawnPoints[spawnWhere].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                spawn = false;
            }
            else if (whichText>-3 && whichText<=0)
            {
                textClone[0] = Instantiate(textPrefab[1], spawnPoints[spawnWhere].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                spawn = false;
            }
            else if (whichText >= -4.5 && whichText <= -3)
            {
                textClone[0] = Instantiate(textPrefab[2], spawnPoints[spawnWhere].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                spawn = false;
            }
            else if (whichText >= -5.5 && whichText <= -4.5)
            {
                textClone[0] = Instantiate(textPrefab[3], spawnPoints[spawnWhere].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                spawn = false;
            }
            else if (whichText <= -5.5)
            {
                textClone[0] = Instantiate(textPrefab[2], spawnPoints[spawnWhere].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                spawn = false;
            }
        }
    }


    void Start()
    {
        gameLogic = GameObject.Find("DoubleStaff").GetComponent<GameLogic>();
        spawn = false;
        whichText = 0;
    }

    void Update()
    {
        spawnText();
    }
}
