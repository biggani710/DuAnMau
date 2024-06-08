using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float movespeed = -1f;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(x:movespeed, y:0);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        movespeed = 1f;
        //xoay huong
        transform.localScale = new Vector2(x:Mathf.Sign(rb.velocity.x), y:1f);
    }
}
