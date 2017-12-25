using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public AudioClip spongebob;
    public bool b_score = false;
    [SerializeField] private Text ScoreText;
    AudioSource audio;
    bool isPlaying = false;
    void Start()
    {
        audio = this.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update () {
        ScoreText.text = "SCORE : " + GameManager.Instance.score;

        if(GameManager.Instance.gameEnd == true && isPlaying == false && b_score == false)
        {
            audio.Stop();
            audio.PlayOneShot(spongebob);
            isPlaying = true;
        }
	}
}
