using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] notePrefab;
    public GameObject[] noteClone;
    public int spawnWhere = 0;
    public float spawnTime = 1.0f;

    void spawnNote()
    {
        spawnWhere = Random.Range(0, 22);
        noteClone[0] = Instantiate(notePrefab[0], spawnPoints[spawnWhere].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
        noteClone[0].GetComponent<NoteLogic>().setSpawnWhere(spawnWhere);
    }

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
        StartCoroutine(spawnRate());
    }
}
