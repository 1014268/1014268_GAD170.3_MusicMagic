using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteLogic : MonoBehaviour
{
    public NoteSpawn noteSpawn;
    public float speed = 10.0f;
    private Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;
    GameLogic gameLogic;
    public int spawnWhere = -1;
    public float notePosition;
    public bool firstNote;
    public string myName;

    public bool spawnIsSet = false;


    public void setSpawnWhere(int spawn)
    {
        spawnWhere = spawn;
    }

    //This should rotate notes to correct position
    void noteRotate()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(-speed, 0);
        noteSpawn = gameObject.GetComponent<NoteSpawn>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spawnWhere > 5 && spawnWhere < 11)
        {
            spriteRenderer.flipX = true;
            spriteRenderer.flipY = true;
        }
        else if (spawnWhere > 18)
        {
            spriteRenderer.flipX = true;
            spriteRenderer.flipY = true;
        }
    }

    //This should assign notes their correct names
    void nameCheck()
    {
        if(gameLogic.spawnName<= 10)
        {
            bassNameCheck();
        }
        else if (gameLogic.spawnName >= 11)
        {
            trebleNameCheck();
        }

        void bassNameCheck()
        {
            if(gameLogic.spawnName == 0)
            {
                myName = "F2";
            }
            else if (gameLogic.spawnName == 1)
            {
                myName = "G2";
            }
            else if (gameLogic.spawnName == 2)
            {
                myName = "A2";
            }
            else if (gameLogic.spawnName == 3)
            {
                myName = "B2";
            }
            else if (gameLogic.spawnName == 4)
            {
                myName = "C3";
            }
            else if (gameLogic.spawnName == 5)
            {
                myName = "D3";
            }
            else if (gameLogic.spawnName == 6)
            {
                myName = "E3";
            }
            else if (gameLogic.spawnName == 7)
            {
                myName = "F3";
            }
            else if (gameLogic.spawnName == 8)
            {
                myName = "G3";
            }
            else if (gameLogic.spawnName == 9)
            {
                myName = "A3";
            }
            else if (gameLogic.spawnName == 10)
            {
                myName = "B3";
            }
        }

        void trebleNameCheck()
        {
            if (gameLogic.spawnName == 11)
            {
                myName = "C4";
            }
            else if (gameLogic.spawnName == 12)
            {
                myName = "D4";
            }
            else if (gameLogic.spawnName == 13)
            {
                myName = "E4";
            }
            else if (gameLogic.spawnName == 14)
            {
                myName = "F4";
            }
            else if (gameLogic.spawnName == 15)
            {
                myName = "G4";
            }
            else if (gameLogic.spawnName == 16)
            {
                myName = "A4";
            }
            else if (gameLogic.spawnName == 17)
            {
                myName = "B4";
            }
            else if (gameLogic.spawnName == 18)
            {
                myName = "C5";
            }
            else if (gameLogic.spawnName == 19)
            {
                myName = "D5";
            }
            else if (gameLogic.spawnName == 20)
            {
                myName = "E5";
            }
            else if (gameLogic.spawnName == 21)
            {
                myName = "F5";
            }
            else if (gameLogic.spawnName == 22)
            {
                myName = "G5";
            }
        }
    }

    //This checks which note is closest to the action bar
    void firstNoteCheck()
    {
        notePosition = this.transform.localPosition.x;

        if (notePosition < gameLogic.firstPosition)
        {
            firstNote = true;
            gameLogic.targetNote = myName;
        }
        else
        {
            firstNote = false;
        }
    }

    //This trakcs the position of the target note
    void positionReport()
    {
        if(firstNote)
        {
            gameLogic.firstPosition = notePosition;
        }
        else
        {

        }
    }

    void clickCheck()
    {
        if (gameLogic.correct == true)
        {
            Destroy(this.gameObject);
            gameLogic.correct = false;
            gameLogic.firstPosition = 10;
        }
        else
        {
            gameLogic.correct = false;
        }
        
    }

    //This should destroy notes that were missed
    void missed()
    {
        if(notePosition <= -6)
        {
            Debug.Log(myName + " was missed!");
            Destroy(this.gameObject);
            gameLogic.firstPosition = 10;
        }
    }


    void Start()
    {
        gameLogic = GameObject.Find("DoubleStaff").GetComponent<GameLogic>();
        noteRotate();
        nameCheck();
    }

    void Update()
    {
        firstNoteCheck();
        positionReport();
        clickCheck();
        missed();
    }
}
