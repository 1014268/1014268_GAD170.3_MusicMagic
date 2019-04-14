using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLogic : MonoBehaviour
{
    GameLogic gameLogic;
    public GameObject[] textPrefab;
    public GameObject[] textClone;
    public Transform[] spawnPoints;

    public bool textSpawn;
    public int whichText;
    public int spawnWhere;

    void spawnText()
    {
        spawnWhere = Random.Range(0, 10);
        textClone[whichText] = Instantiate(textPrefab[0], spawnPoints[spawnWhere].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        textClone[0].GetComponent<NoteLogic>().setSpawnWhere(spawnWhere);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameLogic = GameObject.Find("DoubleStaff").GetComponent<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
