using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongDichChuyen : MonoBehaviour
{
    [SerializeField] Transform diemdichChuyenToi;
    public Transform GetDiemDichChuyenToi()
    {
        return diemdichChuyenToi;
    }
}
