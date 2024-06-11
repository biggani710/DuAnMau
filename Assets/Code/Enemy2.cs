using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Transform playerTransform;

    void Start()
    {
        GameObject playerobject = GameObject.FindGameObjectWithTag("Player");
        if(playerobject == null)
        {
            playerobject = FindObjectOfType<GameObject>();
        }
        if(playerobject != null)
        {
            playerTransform =playerobject.transform;
        }
        else
        {
            Debug.Log("No player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform != null)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") 
        {
            collision.gameObject.SetActive(false);
        }
        if (collision.tag == "Bullet")
        {
            Destroy(gameObject);
            //collision.tag == "Enemy";
        }
    }
}
