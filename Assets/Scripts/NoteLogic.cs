using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteLogic : MonoBehaviour
{
    public NoteSpawn noteSpawn;
    public float speed = 2;
    private Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;
    GameLogic gameLogic;
    TextSpawn textSpawn;
    CapsuleCollider2D noteCollider;
    Vector2 lastVelocity;
    GameObject actionBar;
    public int spawnWhere = -1;
    public float notePosition;
    public bool firstNote;
    public string myName;
    public bool active;
    public float noteValue;

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
        Debug.Log(rigidBody.velocity);
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
        if(active)
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
        if (firstNote == true)
        {
            if (gameLogic.correct == true)
            {
                gameLogic.addScore = noteValue;
                Destroy(this.gameObject);
                gameLogic.progress += 1;
                textSpawn.whichText = notePosition;
                gameLogic.correct = false;
                gameLogic.firstPosition = 10;
                gameLogic.launch = false;
            }
            else
            {
                launchCheck();
            }
        }
    }

    //This should destroy notes that were missed
    void missed()
    {
        if(notePosition <= -6)
        {
            noteCollider.isTrigger = false;
            rigidBody.AddForce(Vector2.left * 10);
            rigidBody.gravityScale = 1;
            rigidBody.AddTorque(1);
            gameLogic.firstPosition = 10;
            //Change this so it only happens ONCE! Not every update!
            //gameLogic.addScore = -250;
            firstNote = false;
            active = false;
        }
    }

    void launchCheck()
    {
        if(firstNote == true)
        {
            if(gameLogic.launch == true)
            {
                noteCollider.isTrigger = false;
                rigidBody.AddForce(Vector2.up * 1000);
                rigidBody.AddForce(Vector2.right * 1500);
                rigidBody.gravityScale = 1;
                rigidBody.AddTorque(-10);
                gameLogic.firstPosition = 10;
                gameLogic.addScore = -500;
                gameLogic.correct = false;
                gameLogic.launch = false;
                firstNote = false;
                active = false;
            }
        }
        else
        {
            
        }
    }
        
    void OnCollisionEnter2D(Collision2D noteCollide)
    {
        if (noteCollide.gameObject.name == "OutOfBounds_Down")
        {
            Destroy(this.gameObject);
        }
        else
        {
            rigidBody.velocity = Vector2.Reflect(lastVelocity, noteCollide.contacts[0].normal);
        }
    }

    void valueCalculation()
    {
        noteValue = (12-(Vector2.Distance(transform.localPosition, actionBar.transform.localPosition)))*100;
    }

    void Start()
    {
        gameLogic = GameObject.Find("DoubleStaff").GetComponent<GameLogic>();
        actionBar = GameObject.Find("ActionBar");
        textSpawn = GameObject.Find("TextSpawnPoints").GetComponent<TextSpawn>();
        noteCollider = GetComponent<CapsuleCollider2D>();
        noteRotate();
        nameCheck();
        active = true;
        gameLogic.launch = false;
        speed = 10f;
    }

    private void FixedUpdate()
    {
        lastVelocity = rigidBody.velocity;
    }

    void Update()
    {
        firstNoteCheck();
        positionReport();
        clickCheck();
        missed();
        valueCalculation();
    }
}
