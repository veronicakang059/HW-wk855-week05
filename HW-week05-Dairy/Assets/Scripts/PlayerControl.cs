using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveForce = 5;
    public Rigidbody2D rb2D;
    public static PlayerControl Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this; 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb2D.AddForce(Vector2.up*moveForce);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb2D.AddForce(Vector2.down*moveForce);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2D.AddForce(Vector2.left*moveForce);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.AddForce(Vector2.right*moveForce);
        }
        
    }
}
