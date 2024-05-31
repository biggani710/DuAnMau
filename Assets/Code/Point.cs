using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
   // [SerializeField] AudioClip pointPickUp;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           // AudioSource.PlayClipAtPoint(pointPickUp, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
