using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteLogic : MonoBehaviour
{
    public NoteSpawn noteSpawn;
    public float speed = 10.0f;
    private Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public int spawnWhere = -1;

    public bool spawnIsSet = false;


    public void setSpawnWhere(int a)
    {
        spawnWhere = a;
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(-speed, 0);

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
}
