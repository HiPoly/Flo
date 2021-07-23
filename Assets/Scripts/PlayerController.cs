using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveAcceleration;
    public float moveSpeedMax;
    public float jumpHeight;
    public float footDepth;

    private Rigidbody2D rb;
    private bool onGround;
    private RaycastHit2D footRay;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CastFeet();
        CharacterPrimaryControl();

    }

    private void CastFeet()
    {
        RaycastHit2D hit;
        //if (Physics2D.Raycast(transform.position, new Vector2(0f, -1f), footDepth, out hit, )
    }

    private void CharacterPrimaryControl()
    {
        float move = Input.GetAxis("Horizontal");
        bool jump = Input.GetKeyDown(KeyCode.Space);
        if (Mathf.Abs(rb.velocity.x) < moveSpeedMax) rb.velocity += new Vector2(move * moveAcceleration, 0f);
        if (jump) rb.velocity += new Vector2(0f, 1f) * jumpHeight;
    }
}