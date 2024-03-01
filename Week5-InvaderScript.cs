using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderScript : MonoBehaviour
{
    public static float speed = 5.0f;

    private GameManager gm;
    
   

    void Start()

    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //check to see if we collide with the wall
        if (collision.gameObject.tag == "Wall")
        {
            speed = speed*-1; //reverse speed

            //move all invaders down at once:
            GameObject[] invaders = GameObject.FindGameObjectsWithTag("Invader");

            foreach (GameObject i in invaders)
            {
                i.transform.Translate(Vector2.down * 10 * Time.deltaTime);
            }
        }

        //check to see if we collide with the Player
        if (collision.gameObject.tag == "Player")
        {
            gm.killed();
            Destroy(collision.gameObject); //destroy the ship

        }

            


    }

}
