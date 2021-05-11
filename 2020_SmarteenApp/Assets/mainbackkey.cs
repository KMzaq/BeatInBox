using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainbackkey : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
           if (Input.GetKey(KeyCode.Escape))
            {
                //back button

                Application.Quit(); // 어플리케이션 종료
            }
    
        }

    }

   
}
