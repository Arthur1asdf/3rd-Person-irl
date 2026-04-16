using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if side hand button is pressed
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            Scene scene = SceneManager.GetActiveScene();

            //switch between pause/main scene
            if (scene.name == "PauseMenu")
            {
                SceneManager.LoadScene("MainScene");
            }
            else
            {
                SceneManager.LoadScene("PauseMenu");
            }
        }

    }
}
