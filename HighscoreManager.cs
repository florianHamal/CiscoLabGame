using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    public TextMeshPro highscoreText;
    void Start()
    {
               
    }

    void Update()
    {
        readHighscore();
    }

    public void readHighscore()
    {
        string highscore = PlayerPrefs.GetString("highscore");
        setText(highscore);
    }

    public void setText(string highscore)
    {
        highscoreText.text = "Highscore: \n" + highscore;
    }
}
