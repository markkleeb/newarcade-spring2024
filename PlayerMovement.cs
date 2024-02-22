using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public KeyCode moveLeft;
    public KeyCode moveRight;
    public float speed = 10.0f;
    public float jumpForce = 10.0f;

    private SpriteRenderer marioSR;
    private Rigidbody2D marioRB;

    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        marioSR = gameObject.GetComponent<SpriteRenderer>();
        marioRB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(moveLeft))
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed );
            facingRight = false;
        }


        //if (Input.GetKeyDown(moveRight))
        if (Input.GetAxisRaw("Horizontal")> 0)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
            facingRight = true;
        }

        if(Input.GetAxisRaw("Jump") > 0)
        {
            marioRB.AddForce(Vector2.up*Time.deltaTime*jumpForce, ForceMode2D.Impulse);
        }


        if (facingRight)
        {
            marioSR.flipX = false;
        }
        else
        {
            marioSR.flipX = true;
        }

    }
}
