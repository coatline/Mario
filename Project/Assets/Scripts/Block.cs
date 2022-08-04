using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool isSpecial;
    bool finished;

    public bool top;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !top)
        {
            var rb = other.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, (-rb.velocity.y + (rb.velocity.y / 2.5f)));

            if (other.GetComponent<Player>().isBig && !isSpecial)
            {
                Destroy(transform.parent.gameObject);
                Destroy(this);
            }
            else if (isSpecial)
            {

            }
        }
    }
}
