using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLogic : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Color c_pressed;
    public Color c_unpressed;
    public bool pressed;
    


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    

    private void OnMouseOver()
    {
        if(Input.GetMouseButton(0))
        {
            spriteRenderer.color = c_pressed;
            pressed = true;
        }
        else
        {
            pressed = false;
            spriteRenderer.color = c_unpressed;
        }
    }
    private void OnMouseExit()
    {
        spriteRenderer.color = c_unpressed;
        pressed = false;
    }
}
