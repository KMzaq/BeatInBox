using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class system : MonoBehaviour
{
    public SpriteRenderer playersprite;
    public Sprite[] sprites;
    public SpriteRenderer mapsprite;
    public Sprite[] mapsprites;
    public AudioClip[] sound;

    public AudioSource gamesound; 
    
    public Color[] colors;
    public TrailRenderer trail;
    //컬러 색상 저장
    private void Start()
    {
        SaveManager.skinload(SaveManager.Load());
        for (int idx = 0; idx < SaveManager.Sskinlist.Count; idx++)
        {
            if (SaveManager.Sskinlist[idx] == 2)
            {
                playersprite.sprite = sprites[idx];
                // 캐릭터 불러오는 곳
                // 꼬리 참조  color 
                trail.startColor = colors[idx];
                trail.endColor = colors[idx];
                trail.endColor = new Color(trail.endColor.r, trail.endColor.g, trail.endColor.b, trail.endColor.a - 4f);
                break;
            }
        }
        SaveManager.mapskinload(SaveManager.Load());
        for (int idx = 0; idx < SaveManager.smapskin.Count; idx++)
        {
            if (SaveManager.smapskin[idx] == 2)
            {
                mapsprite.sprite = mapsprites[idx];
               gamesound.clip= sound[idx];

                //사운드
                break;
            }
        }

    }
}
