using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveAcceleration;
    public float moveSpeedMax;
    public float arialControl;
    public float drag;
    public float jumpHeight;
    public float footDepth;

    public bool USBModule;
    public bool JackLauncherModule;
    public bool redToothModule;

    private Rigidbody2D rb;
    private PlayerInteraction interaction;
    private bool onGround;
    private bool moving;
    private RaycastHit2D footRay;

    private float moveInput;

    public bool isPlayerControlling = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        interaction = GetComponent<PlayerInteraction>();
        onGround = false;
        moveInput = 0f;
        moving = false;
        USBModule = false;
        JackLauncherModule = false;
        redToothModule = false;
    }

    // Update is called once per frame
    void Update()
    {
        CastFeet();
        
        if (isPlayerControlling)
        {
            CharacterPrimaryControl();
        }
    }

    private void FixedUpdate()
    {
        ApplySideMovement();
    }

    private void ApplySideMovement()
    {
        rb.velocity += new Vector2(moveInput, 0f);
        if (onGround && moveInput == 0f && !moving) rb.velocity *= new Vector2(drag, 1f);
    }

    private void CastFeet()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(0f, -1f), footDepth);
        if (hit.collider != null)
        {
            onGround = true;
            footRay = hit;
        }
        else onGround = false;
    }

    private void CharacterPrimaryControl()
    {
        float move = Input.GetAxisRaw("Horizontal");
        bool jump = Input.GetKeyDown(KeyCode.Space);
        float modSpeed = 1f;
        moving = (move != 0f);
        if (!onGround) modSpeed = arialControl;
        if ((move > 0f && rb.velocity.x < moveSpeedMax) || (move < 0f && rb.velocity.x > -moveSpeedMax))
        {
            float adjustVel = move * modSpeed * moveAcceleration;
            float maxDiff = moveSpeedMax - Mathf.Abs(rb.velocity.x) + Mathf.Abs(adjustVel);
            if (maxDiff > 0f)
            {
                if (adjustVel > maxDiff) adjustVel = maxDiff;
                if (adjustVel < -maxDiff) adjustVel = -maxDiff;
            }
            moveInput = adjustVel;
        }
        else moveInput = 0f;
        if (onGround && jump) rb.velocity += new Vector2(0f, 1f) * jumpHeight;
    }

    public void ActivateControl()
    {
        isPlayerControlling = true;
    }
    
    public void DectivateControl()
    {
        isPlayerControlling = false;
    }
}