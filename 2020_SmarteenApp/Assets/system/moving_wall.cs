using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class moving_wall : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public pointsystem pointsystem;
    //

    public GameObject pung;
    public GameObject pung2;
    //
  
    private void OnTriggerStay2D(Collider2D collision)
    {
        spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
        //Debug.Log(collision.name);
        if (collision.tag == "obj" || collision.tag == "obj_intrail")
        {
            if (spriteRenderer.color.a >0.5f) {
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
                pointsystem.Point += 1;

                if (collision.TryGetComponent<IObstacle>(out var comp)){
                    comp.End();
                }

                //점수추가
                Destroy(collision.gameObject);
                
                try { Destroy(collision.gameObject.GetComponent<obj_1>().Ttrace); }
                catch(NullReferenceException) { }
               
            }
        }
    }
}
