using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Grab the ship object
    public GameObject ship;

    //Grab the invader object
    public GameObject invader;

    public int score = 0;
    public TMP_Text scoreText;



    // Start is called before the first frame update
    void Start()
    {
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddScore()
    {
        score += 1;
        scoreText.text = "Score: " + score;
    }
}
