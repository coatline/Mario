using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{

    int dir;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        var newDir = 0;

        for(int i = 0; newDir == 0; i = Random.Range(-1, 2))
        {
            newDir = i;
        }

        dir = newDir;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(dir, rb.velocity.y, 0);
    }
}
