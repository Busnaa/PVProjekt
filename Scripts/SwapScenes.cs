using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScenes : MonoBehaviour
{
    void Update()
    {

        // Check if the active scene is "LoadingScreen" and pause the music
        if (SceneManager.GetActiveScene().name == "LoadingScreen")
            Music.instance.GetComponent<AudioSource>().Pause();
        

    }
}