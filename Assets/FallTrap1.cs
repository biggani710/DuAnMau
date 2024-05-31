using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallTrap1 : MonoBehaviour
{

    private Rigidbody2D rb;
    private bool daRoi = false;
    public Transform diemkhoiphuc;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb.isKinematic = false;
        daRoi = true;
        Invoke("Khoi phuc", 2f);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Scene 2");
        }
    }
    private void KhoiPhuc()
    {
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        rb.angularDrag = 0;
        transform.position = diemkhoiphuc.position;
        daRoi = false;
    }
}
