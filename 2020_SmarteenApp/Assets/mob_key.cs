using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mob_key : MonoBehaviour
{

public pause pause;
    void Update()
    {
  
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Home))
            {
                //home button
                pause.Pauseseting();
            }
            else if (Input.GetKey(KeyCode.Escape))
            {
                //back button
                if (Time.timeScale ==0)
                {
                    pause.Restart();
                }
                else
                {
                    pause.Pauseseting();
                }
            }
            else if (Input.GetKey(KeyCode.Menu))
            {
                //menu button
                pause.Pauseseting();
            }
        }
    }
}
