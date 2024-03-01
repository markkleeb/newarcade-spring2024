using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //Grab the ship object
    public GameObject ship;

    //Grab the invader object
    public GameObject invader;

    //UI for scorekeeping
    public int score = 0;
    public TMP_Text scoreText;
    private int highScore;

    //variables for tracking lives
    private int lives = 3;
    public GameObject life;
    public bool isDead = false;




    // Start is called before the first frame update
    void Start()
    {

        highScore = PlayerPrefs.GetInt("HighScore");

        Instantiate(ship, new Vector2(0, -3), Quaternion.identity);

        //draw 10 invaders across
        for (int i = -5; i < 5; i++)
        {
            //draw 3 rows down
            for (int j = 2; j < 5; j++)
            {
                Instantiate(invader, new Vector2(i, j), Quaternion.identity);
            }
        }

        //Draw 3 Life Sprites
        for (int i=0; i< 3; i++)
        {
            Instantiate(life, new Vector2(i + 6, 4), Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == true && Input.anyKeyDown)
        {
            Instantiate(ship, new Vector2(0, -3), Quaternion.identity);
            isDead = false;

        }
    }


    public void AddScore()
    {
        score += 1;
        scoreText.text = "Score: " + score;

        if(score > highScore)
        {
            highScore = score;
        }

    }

    public void killed()
    {
        isDead = true;
        lives -= 1;
        GameObject[] lifeSprites = GameObject.FindGameObjectsWithTag("Life");
        Destroy(lifeSprites[0]);

        if (lives < 0)
        {
            PlayerPrefs.SetInt("HighScore", highScore);
            SceneManager.LoadScene("TitleScene");
        }
    }
}
