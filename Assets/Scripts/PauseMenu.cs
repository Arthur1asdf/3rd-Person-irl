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
        if ((OVRInput.Get(OVRInput.Button.PrimaryHandTrigger)) || (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger)))
        {
            Scene scene = SceneManager.GetActiveScene();
            Debug.Log($"Scene name: {scene.name}");

            //switch between pause/main scene
            if (scene.name == "PauseMenu")
            {
                SceneManager.LoadScene("newscene");
            }
            else
            {
                SceneManager.LoadScene("PauseMenu");
            }
        }

    }
}
