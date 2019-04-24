using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLogic : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    Vector2 lastVelocity;
    float range = 200;

    void OnCollisionEnter2D(Collision2D textCollide)
    {
        if (textCollide.gameObject.name == "OutOfBounds_Up")
        {
            Destroy(this.gameObject);
        }
        else
        {
            rigidBody.velocity = Vector2.Reflect(lastVelocity, textCollide.contacts[0].normal);
        }
    }

        // Start is called before the first frame update
        void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddTorque(Random.Range(-range,range));
        rigidBody.AddForce(Vector2.right * (Random.Range(-range, range)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        lastVelocity = rigidBody.velocity;
    }
}
