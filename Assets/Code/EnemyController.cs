using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float start, end, speed;
    Rigidbody2D rig;
    int isRight = 1;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        Run();
        Flip();
        anim.SetFloat("run", Mathf.Abs(start));
    }
    void Run()
    {
        var x_enemy = transform.position.x;//x cua enemy
        if (x_enemy < start)
            isRight = 1;
        if (x_enemy > end)
            isRight = -1;
        transform.Translate(new Vector3(isRight * speed * Time.deltaTime, 0, 0));
    }
    void Flip()
    {
        transform.localScale = new Vector3(isRight, 1f);
    }
}
