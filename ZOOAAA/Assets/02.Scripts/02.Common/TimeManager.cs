using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private Image nightSky;

    private Color nightColor;

    [SerializeField]
    private Text TimerText;

    public float fMaxTime = 5;

    public float overallTime;

    private int timeFrame;

    private int moveTime;

    public bool time;

    public GameObject pause;
    public GameObject end;

    const string str = "TIME : ";
    

    // Use this for initialization
    void Start()
    {
        overallTime = fMaxTime;
        TimerText.text = "TIME : 80";

        pause.SetActive(false);
        end.SetActive(false);

        Time.timeScale = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        //img_TimeGage.fillAmount = overallTime / fMaxTime;

        if (GameManager.Instance.bRB.velocity == Vector2.zero)
            overallTime -= Time.deltaTime;


        TimerText.text = str + overallTime.ToString("N2");

        nightColor = nightSky.color;

        nightColor.a += 1.0f/fMaxTime * Time.deltaTime;

        nightSky.color = nightColor;


        if (moveTime >= 11)
        {
            moveTime = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            pause.SetActive(true);
            Time.timeScale = 0;

        }

        if (overallTime <= 0)
        {
            if(GameManager.Instance.gameEnd == false)
                GameManager.Instance.gameEnd = true;


            if (GameManager.Instance.gameEnd == true && overallTime < -10f)
            {
                end.SetActive(true);
                Time.timeScale = 0;

            }
        }


        if (time && timeFrame % 40 == 0)
        {

            moveTime += 1;

        }

        if (moveTime == 11)
            time = false;

        if (Input.GetMouseButtonDown(0))
        {

            if (moveTime < 11)
                time = true;

        }

        if (Input.GetMouseButtonUp(0))
        {

            time = false;
            moveTime = 0;
            timeFrame = 0;

        }
    }

    public void Continue()
    {

        Time.timeScale = 1;
        pause.SetActive(false);

    }

    public void reStart()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("DY_Scene");
        

    }

    public void Quit()
    {

        Application.Quit();

    }
}
