using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] notePrefab;
    public GameObject[] noteClone;
    public int spawnWhere = 0;
    public float spawnTime = 2;
    GameLogic gameLogic;

    //This should spawn notes
    void spawnNote()
    {
        spawnWhere = Random.Range(0, 22);
        noteClone[0] = Instantiate(notePrefab[0], spawnPoints[spawnWhere].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
        noteClone[0].GetComponent<NoteLogic>().setSpawnWhere(spawnWhere);
        gameLogic.spawnName = spawnWhere;
    }

    //This should control the spawn rate
    IEnumerator spawnRate()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            spawnNote();
        }
        
    }

    void Start()
    {
        gameLogic = GameObject.Find("DoubleStaff").GetComponent<GameLogic>();
        StartCoroutine(spawnRate());
    }
}
