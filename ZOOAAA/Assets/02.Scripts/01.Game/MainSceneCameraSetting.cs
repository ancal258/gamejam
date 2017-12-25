using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class MainSceneCameraSetting : MonoBehaviour {

    float currentTime = 0f;

    float speed = 2f;

    int animLevel = 0;

    public Image fadeIn;

    public Text tapToStart;

    public ParticleSystem explosion;
    
    public RectTransform imageRect;
   
    bool isFadeIn = false;

    bool isTitle = false;

    [SerializeField]private PlayableDirector director;



    void Update () {
        currentTime += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && !isTitle)
        {
            director.time = 17.0f;
            currentTime = 15.5f;
            isTitle = true;
        }

        if (currentTime > 15.5f && animLevel == 0)
        {
            explosion.Play();
            animLevel++;
            isTitle = true;
        }
        else if (currentTime > 17.5f && animLevel == 1)
        {
            imageRect.sizeDelta += new Vector2(525, 336) * Time.deltaTime * speed;
            speed += Time.deltaTime * 2;

            if (imageRect.sizeDelta.x >= 1100f)
                animLevel++;
        }
        else if (currentTime > 17.5f && animLevel == 2)
        {
            imageRect.sizeDelta -= new Vector2(525, 336) * Time.deltaTime * 2f;

            if (imageRect.sizeDelta.x <= 1000f)
                animLevel++;
        }
        else if (currentTime > 17.5f && animLevel == 3)
        {
            tapToStart.color += new Color(0, 0, 0, 1) * Time.deltaTime;
            Debug.Log(tapToStart.color.a);
            if (tapToStart.color.a >= 1)
                animLevel++;
        }
        else if (currentTime > 17.5f && animLevel == 4)
        {
            tapToStart.color -= new Color(0, 0, 0, 1) * Time.deltaTime;
            if (tapToStart.color.a <= 0)
                animLevel--;
        }
        if (animLevel >= 3 && Input.GetMouseButtonDown(0))
            isFadeIn = true;

        if (isFadeIn)
        {
            fadeIn.color += new Color(0, 0, 0, 1) * Time.deltaTime;
        }

        if(fadeIn.color.a >= 1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("DY_Scene");
        }

	}
}
