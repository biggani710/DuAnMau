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
    Animator animator;
    private bool isAlive;
    public GameObject bulletPrefabs;
    public Transform FirePoint;
    public float FireRate = 0.5f;
    private float nextFỉreTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        isAlive = true;
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckObject.position, 0.2f, LayerMask.GetMask("Ground"));
        float moveInput = Input.GetAxisRaw("Horizontal");
        bool havemove = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        animator.SetBool("isRunning", havemove);


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
            if (!isAlive)
            {
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            hasJump = true;
            if (!isAlive)
            {
                return;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && hasJump)
        {
            Dash();
            hasJump = false;
            if (!isAlive)
            {
                return;
            }
        }

        if (Input.GetMouseButtonDown(0) && Time.time >= nextFỉreTime)
        {
            Shoot();
            nextFỉreTime = Time.time + FireRate;
            if (!isAlive)
            {
                return;
            }
        }

        Die();
    }

    void Dash()
    {
        float dashDirection = spriteRenderer.flipX ? -1f : 1f;
        rb.velocity = new Vector2(dashForce * dashDirection, rb.velocity.y);
        isDashing = true;
        dashEffectObject.SetActive(true);
        StartCoroutine(StopDash());
        if (!isAlive)
        {
            return;
        }
    }

    IEnumerator StopDash()
    {
        yield return new WaitForSeconds(dashTime);
        rb.velocity = new Vector2(0f, rb.velocity.y);
        isDashing = false;
        dashEffectObject.SetActive(false);
    }

    void Die()
    {
        var isTouchingEnemy = rb.IsTouchingLayers(LayerMask.GetMask("Enemy", "Trap"));
        if (isTouchingEnemy)
        {
            isAlive = false;
            animator.SetTrigger("Die");
            rb.velocity = new Vector2(0, 0);
            //Xu ly die
            FindObjectOfType<GameController>().ProcessPlayerDeath();
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefabs, FirePoint.position, FirePoint.rotation, FirePoint.transform);
        if (transform.localScale.x < 1f)
        {
            bulletPrefabs.GetComponent<Rigidbody2D>().velocity = new Vector2(x: -15, y: 0);
        }
        else
        {
            bulletPrefabs.GetComponent<Rigidbody2D>().velocity = new Vector2(x: 15, y: 0);
        }
    }
}