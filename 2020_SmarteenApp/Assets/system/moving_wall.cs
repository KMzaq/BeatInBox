using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class moving_wall : MonoBehaviour
{

    //

    public GameObject pung;
    public GameObject pung2;
    //
  
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "obj" || collision.tag == "obj_intrail")
        {
            //if (spriteRenderer.color.a >0.5f) 
            {
                /////////////////////////
                
                
                if(this.transform.position.x == 0)
                    Instantiate(pung2, new Vector3(collision.transform.position.x,transform.position.y,1), Quaternion.identity);
                if (this.transform.position.y == 0)
                    Instantiate(pung2, new Vector3(transform.position.x, collision.transform.position.y, 1), Quaternion.identity);

                if (this.transform.position.x == 0)
                    Instantiate(pung, new Vector3(collision.transform.position.x, transform.position.y, 1), Quaternion.identity);
                if (this.transform.position.y == 0)
                    Instantiate(pung, new Vector3(transform.position.x, collision.transform.position.y, 1), Quaternion.identity);

                Vibration.Vibrate((long)(10 * GameManager.vibe));
                /////////////////////////////
                ///

                
                if (GameManager.Char_dead == false)
                    Pointsystem.Point += 1;



               
            }
        }
    }
}
