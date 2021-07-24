﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePlatform : MonoBehaviour
{

    public bool isPlayerControlling = false;
    public bool horizontalMovment = false;
    public bool verticalMovement = false;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerControlling == true)
        {
            if (horizontalMovment == true)
            {
                transform.position = new Vector2(transform.position.x + Input.GetAxisRaw("Horizontal")*speed*Time.deltaTime, transform.position.y);
            }

            if (verticalMovement == true)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + Input.GetAxisRaw("Vertical") * speed * Time.deltaTime);
            }

        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            isPlayerControlling = true;
        }
    }
    
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            isPlayerControlling = false;
        }
    }

}
