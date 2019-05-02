using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    //This should take you to the game scene
    private void OnMouseDown()
    {
        SceneManager.LoadScene(1);
    }
}
