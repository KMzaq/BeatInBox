using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamestart : MonoBehaviour
{
    public Image panel;
    public Canvas canvas;
    public Button startbutton;
    public Canvas canvas2;


    float time = 0f;
    float F_time = 0.3f;
    //bool timer = true;

    float startsize;
    float maxsize;


    public void StartButton()
    {
        startsize = startbutton.image.rectTransform.rect.width;
        maxsize = canvas.GetComponent<RectTransform>().rect.width * 0.79f;
        print(maxsize);
        print(canvas.pixelRect.width);
        StartCoroutine(start());
    }
    IEnumerator start()
    {
        canvas.gameObject.SetActive(false);
        panel.gameObject.SetActive(true);

        while (panel.rectTransform.sizeDelta.x < canvas2.GetComponent<RectTransform>().rect.width * 0.785 - 10)
        {
            time += Time.deltaTime / F_time;
            panel.rectTransform.sizeDelta = new Vector2(Mathf.Lerp(startsize, maxsize, time), Mathf.Lerp(startsize, maxsize, time));

            yield return null;
        }
        SceneManager.LoadScene("InGame");
        yield return null;
    }


}

