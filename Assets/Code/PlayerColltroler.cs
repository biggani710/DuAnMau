using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 25f;
    public float dashForce = 20f;
    public float dashTime = 0.3f;
    private Rigidbody2D rb;
    public Transform groundCheckObject;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;
    private bool isDashing = false;
    private bool hasJump = false;
    public GameObject dashEffectObject;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckObject.position, 0.2f, LayerMask.GetMask("Ground"));
        float moveInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("isRunning", Mathf.Abs(moveInput));

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
    }

    void Dash()
    {
        float dashDirection = spriteRenderer.flipX ? -1f : 1f;
        rb.velocity = new Vector2(dashForce * dashDirection, rb.velocity.y);
        isDashing = true;
        dashEffectObject.SetActive(true);
        StartCoroutine(StopDash());
    }

    IEnumerator StopDash()
    {
        yield return new WaitForSeconds(dashTime);
        rb.velocity = new Vector2(0f, rb.velocity.y);
        isDashing = false;
        dashEffectObject.SetActive(false);
    }

    // Hàm này được gọi từ animation event khi kết thúc animation nhảy
    public void EndJump()
    {
        animator.SetBool("isJump", false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isJump", false);
        }
    }
}