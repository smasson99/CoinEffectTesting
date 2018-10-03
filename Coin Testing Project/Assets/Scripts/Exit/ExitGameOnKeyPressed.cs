using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameOnKeyPressed : MonoBehaviour
{
    [Tooltip("The key to press to exit")] [SerializeField]
    private string keyToPressToExit = KeyCode.Escape.ToString();
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}