using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text HighScoreText;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("highscoreeeeeeeeee " +PlayerPrefs.GetFloat("Highscore"));
        HighScoreText.text = "HighScore : " + PlayerPrefs.GetFloat("Highscore");
    }

    void Update()
    {
        Debug.Log("highscoreeeeeeeeee " +PlayerPrefs.GetFloat("Highscore"));
        HighScoreText.text = "HighScore : " + PlayerPrefs.GetFloat("Highscore");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Game");
    }
}
