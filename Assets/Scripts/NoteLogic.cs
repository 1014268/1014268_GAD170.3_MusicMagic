using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteLogic : MonoBehaviour
{
    private NoteSpawn noteSpawn;
    public float speed = 10.0f;
    private Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (noteSpawn.spawnWhere>5 && noteSpawn.spawnWhere<11)
        {
            SpriteRenderer.flipX;

        }

    }
}
