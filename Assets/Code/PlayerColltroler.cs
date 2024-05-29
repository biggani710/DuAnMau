using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 25f;
    public float dashForce = 20f;
    public float DashTime = 0.3f;
    private Rigidbody2D rb;
    public Transform groundCheckObject;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;
    private bool isDashing = false;
    private bool hasJump = false;
    public GameObject DashEffectObject;
    //private Animator animator;
    private Vector2 moveInput;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckObject.position, 0.2f, LayerMask.GetMask("Ground"));
        float moveInput = Input.GetAxisRaw("Horizontal");
        if (!isDashing)
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
            if (moveInput > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (moveInput < 0)
            {
                spriteRenderer.flipX = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            hasJump = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && hasJump)
        {
            Dash();
            hasJump = false;
        }

        //UpdateAnimationState();
    }

    void Dash()
    {
        float dashDirection = spriteRenderer.flipX ? -1f : 1f;
        rb.velocity = new Vector2(dashForce * dashDirection, rb.velocity.y);
        isDashing = true;
        DashEffectObject.SetActive(true);
        StartCoroutine(StopDash());
    }

    IEnumerator StopDash()
    {
        yield return new WaitForSeconds(DashTime);
        rb.velocity = new Vector2(0f, rb.velocity.y);
        isDashing = false;
        DashEffectObject.SetActive(false);
    }

    //void UpdateAnimationState()
    //{
        //if (moveInput.magnitude > 0)
        //{
            //animator.SetBool("isRunning", true);
        //}
        //else
        //{
            //animator.SetBool("isRunning", false);

        //}
    //}
}