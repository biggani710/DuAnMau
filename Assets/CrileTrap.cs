using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrileTrap : MonoBehaviour
{
    public float tocDoXoay = 5f;
    public float tocdoDichuyen = 5f;
    public Transform diemA;
    public Transform diemB;
    private Vector3 diemMucTieu;
    void Start()
    {
        diemMucTieu = diemA.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, diemMucTieu, tocdoDichuyen * Time.deltaTime);
        if (Vector3.Distance(transform.position, diemMucTieu)<0.1f)
        {
            if (transform.position == diemA.position)
            {
                diemMucTieu = diemB.position;
            }
            else
            {
                diemMucTieu = diemA.position;
            }
        }
    }
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, tocDoXoay);
    }
}
