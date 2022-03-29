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
        HighScoreText.text = "HighScore : " + (int)PlayerPrefs.GetFloat("HighScore");
    }


    public void ToMenu()
    {
        SceneManager.LoadScene("Game");
    }
}
