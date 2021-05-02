using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tasFirlatma : MonoBehaviour
{

    public Rigidbody2D tas_rb2D;
    private bool egerClick = false;
    public Rigidbody2D baglantiNoktasi;
    public float enBuyukUzaklik;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (egerClick)
        {
            //tas_rb2D.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);//sistemde gözüken mouse pozisyonunu ana kameranin görüntüsüne esitliyor
            Vector2 mouseKonum = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(mouseKonum, baglantiNoktasi.position) > enBuyukUzaklik)
            {
                tas_rb2D.position = baglantiNoktasi.position +
                                    (mouseKonum - baglantiNoktasi.position).normalized * enBuyukUzaklik; // (mouseKonum - baglantiNoktasi.position) : Yön hesabi
            }
            else
            {
                tas_rb2D.position = mouseKonum;
            }
        }
    }

    void OnMouseDown() //Mouse ile tasa tiklandiginda
    {
        egerClick = true;
    }

    void OnMouseUp() //Mouse dan parmagimizi kaldirdigimizda
    {
        egerClick = false;
    }
}
