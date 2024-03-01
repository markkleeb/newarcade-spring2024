using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleScript : MonoBehaviour
{
    public int highScore;
    public TMP_Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "High Score : " + highScore;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("SpaceScene");
        }

    }
}
