using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class XuLyVaCham : MonoBehaviour
{
    public int Mau = 3;
    public int Coin = 0;
    public TextMeshProUGUI VangText;
    public TextMeshProUGUI MauText;
    void Start()
    {
        VangText.SetText(VangText.ToString());
        MauText.SetText(Mau.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Coin++;
            Destroy(collision.gameObject);
            VangText.SetText(VangText.ToString());
            Destroy(collision.gameObject);
        }
        if(collision.CompareTag("GaiNhon"))
        {
            Mau--;
            MauText.SetText(Mau.ToString());
        }    
    }
}
