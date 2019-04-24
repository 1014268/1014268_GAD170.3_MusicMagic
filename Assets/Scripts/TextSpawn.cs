using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpawn : MonoBehaviour
{
    GameLogic gameLogic;
    public GameObject[] textPrefab;
    public GameObject[] textClone;
    public Transform[] spawnPoints;

    public bool spawn;
    public int whichText;
    public int spawnWhere;
    int addTextValue;

    void spawnText()
    {
        if (spawn == true)
        {
            //TextChoice();
            spawnWhere = Random.Range(0, 10);
            textClone[0] = Instantiate(textPrefab[1], spawnPoints[spawnWhere].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            //textClone[0].GetComponent<NoteLogic>().setSpawnWhere(spawnWhere);
            spawn = false;
        }
        else
        {

        }
    }

    /*
    void TextChoice()
    {
        addTextValue = (int)gameLogic.addScore;
        if(addTextValue > 2 && addTextValue < 6)
        {
            whichText = 0;
        }
        else if(addTextValue > 5 && addTextValue < 8)
        {
            whichText = 1;
        }
        else if(addTextValue > 7 && addTextValue < 12)
        {
            whichText = 2;
        }
        else if(addTextValue == 12)
        {
            whichText = 3;
        }
    }
    */

    // Start is called before the first frame update
    void Start()
    {
        gameLogic = GameObject.Find("DoubleStaff").GetComponent<GameLogic>();
        spawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        spawnText();
    }
}
