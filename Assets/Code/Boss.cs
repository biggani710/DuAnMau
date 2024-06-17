using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Transform playerTransform;

    void Start()
    {
        GameObject playerobject = GameObject.FindGameObjectWithTag("Player");
        if (playerobject == null)
        {
            playerobject = FindObjectOfType<GameObject>();
        }
        if (playerobject != null)
        {
            playerTransform = playerobject.transform;
        }
        else
        {
            Debug.Log("No player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }

}
