using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLogic : MonoBehaviour
{
    public string keyName;
    public string target;
    Color c_pressed;
    Color lerpedColor;
    public Color[] randomColor;
    private SpriteRenderer spriteRenderer;
    int colorRoll;
    float fadeAmount = 0f;
    float fadeSpeed = 0.05f;
    GameLogic gameLogic;
    GameObject actionBar;
    TextSpawn textSpawn;
    NoteLogic noteLogic;
    
    //This should change the key colours
    void ColorChange()
    {
        StopCoroutine("FadeToWhite");
        colorRoll = Random.Range(0, 6);
        spriteRenderer.color = randomColor[colorRoll];
    }

    //This should trigger the Coroutine
    public void Fade()
    {
        StartCoroutine("FadeToWhite");
    }

    //This should fade the key back to white
    IEnumerator FadeToWhite()
    {
        for (float i = 1f; i >= fadeAmount; i += 0.05f)
        {
            Color c = spriteRenderer.material.color;  
            c.r = i;
            c.g = i;
            c.b = i;

            spriteRenderer.material.color = c;
            yield return new WaitForSeconds(fadeSpeed);
        }
    }

    void targetCheck()
    {
        target = gameLogic.targetNote;
        if(target == keyName)
        {
            gameLogic.correct = true;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Correct/MusicMagic_" + keyName);
            
        }
        else
        {
            gameLogic.correct = false;
            gameLogic.launch = true;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Wrong/MusicMagic_" + keyName);
        }
    }

    //This should trigger functions when key is clicked
    private void OnMouseDown()
    {
        ColorChange();
        targetCheck();
    }

    //This should trigger functions after key click has resolved
    private void OnMouseUp()
    {
        Fade();
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameLogic = GameObject.Find("DoubleStaff").GetComponent<GameLogic>();
        textSpawn = GameObject.Find("TextSpawnPoints").GetComponent<TextSpawn>();
    }

    private void Update()
    {
        
    }
}
