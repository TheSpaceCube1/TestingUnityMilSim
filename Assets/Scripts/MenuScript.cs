using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void SinglePlayer()
    {
        Debug.Log("Playing Single Player");
        SceneManager.LoadScene("Test Scene");
    }

    public void Exit()
    {
        Debug.Log("Exiting Aplication");
        Application.Quit();
    }
}
