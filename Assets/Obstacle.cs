using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    PlayerState playerState;
    // Start is called before the first frame update
    void Start()
    {
        playerState = FindObjectOfType<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            playerState.Die();
        }
    }
}
