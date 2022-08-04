using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    int size;
    public float speed = 1000;
    public float jumpHeight = 7000;
    Rigidbody2D rb;
    public bool canJump;
    public bool isBig;
    Vector3 scale;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (isBig)
            {
                scale = new Vector3(4, 4.5f, 1);
            }
            else
            {
                scale = new Vector3(3, 2, 1);
            }
        }
        else
        {
            if (isBig)
            {
                scale = new Vector3(4, 6, 1);
            }
            else
            {
                scale = new Vector3(3, 3, 1);
            }
        }

        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = false;
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Top"))
        {
            canJump = true;
        }
        else if (collision.gameObject.CompareTag("Mushroom"))
        {
            isBig = true;
            transform.localScale = new Vector3(4, 6, 1);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("Mystery Block"))
        {
            var script = collision.gameObject.GetComponent<MysteryBlock>();
            if (script.isActive)
            {
                script.SpawnItem();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Top"))
        {
            canJump = false;
        }
    }

}
