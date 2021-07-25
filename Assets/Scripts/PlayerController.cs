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
    public int coyoteFrames;
    public float footDepth;

    public bool USBModule;
    public bool JackLauncherModule;
    public bool redToothModule;

    public AudioSource speaker { get; set; }
    private Rigidbody2D rb;
    private bool onGround;
    private bool moving;
    private int coyoteTimer;
    bool wasGrounded;
    bool wasMoving;
    private RaycastHit2D footRay;
    Animator animator;
    SpriteRenderer sprite;
    private float moveInput;

    public bool isPlayerControlling = true;
    public ParticleSystem landingParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speaker = GetComponent<AudioSource>();
        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        onGround = false;
        moveInput = 0f;
        moving = false;
        wasMoving = false;
        USBModule = false;
        JackLauncherModule = false;
        redToothModule = false;
        wasGrounded = false;
        coyoteTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CastFeet();
        
        if (isPlayerControlling)
        {
            CharacterPrimaryControl();
        }
        if (onGround)
        {
            if (coyoteTimer == 0 && rb.velocity.y < 0f) GroundImpact();
            coyoteTimer = coyoteFrames;
        }
        else if (coyoteTimer != 0) coyoteTimer--;
    }

    private void GroundImpact()
    {
        speaker.PlayOneShot(AudioManager.instance.impact);
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
        if(onGround == true && wasGrounded == false)
        {
            animator.SetBool("Grounded", true);
            landingParticleSystem.Play();
        }
        if (onGround == false && wasGrounded == true)
        {
            animator.SetBool("Grounded", false);
        }
        wasGrounded = onGround;
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

        animator.SetFloat("MoveInput", Mathf.Abs(move));

        if (jump && (onGround || coyoteTimer != 0))
        {
            rb.velocity += new Vector2(0f, 1f) * jumpHeight;
            animator.SetBool("Grounded", false);
            coyoteTimer = 0;
            speaker.PlayOneShot(AudioManager.instance.jump);
        }
        wasMoving = moving;

        if (move == -1)
        {
            sprite.flipX = true;
        }
        if (move == 1)
        {
            sprite.flipX = false;
        }
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