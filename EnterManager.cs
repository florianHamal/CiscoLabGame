using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterManager : MonoBehaviour
{
    private int count = 0;
    private bool started = false;
    public TextMesh countText;

    void Start()
    {
        this.countText.gameObject.SetActive(false);
        PlayerPrefs.SetInt("finished", 0);
    }

    void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        IEnumerator countdown = CountdownCoroutine();
        if (other.gameObject.name == "Main Camera")
        {
            if (other.gameObject.transform.position.z >= 3)
            {
                if (!started)
                {
                    StartCoroutine(countdown);
                    started = true;
                    GameObject spawner = GameObject.Find("Spawner");
                    spawner.GetComponent<Spawner>().enabled = true;
                }
            } else
            {
                reload();
            }
        }
    }

    IEnumerator CountdownCoroutine()
    {
        this.countText.gameObject.SetActive(true);
        while (PlayerPrefs.GetInt("finished") != 1)
        {
            count++;
            this.countText.text = (count / 60).ToString("00") + ":" + (count % 60).ToString("00");
            yield return new WaitForSeconds(1);
        }
        checkHighscore(count);
    }

    public void reload()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void checkHighscore(int count)
    {
        string highscore = PlayerPrefs.GetString("highscore");
        if (!highscore.Equals(""))
        {
            int score = Int32.Parse(highscore.Split(':')[1]) + Int32.Parse(highscore.Split(':')[0]) * 60;
            if (count < score)
            {
                PlayerPrefs.SetString("highscore", (count / 60).ToString("00") + ":" + (count % 60).ToString("00"));
                countText.text = "Highscore";
            }
            else
            {
                this.countText.gameObject.SetActive(false);
            }
        } else
        {
            PlayerPrefs.SetString("highscore", (count / 60).ToString("00") + ":" + (count % 60).ToString("00"));
            countText.text = "Highscore";
        }        
    }
}
