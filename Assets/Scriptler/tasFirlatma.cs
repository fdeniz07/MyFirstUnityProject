using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tasFirlatma : MonoBehaviour
{

    public Rigidbody2D tas_rb2D;
    private bool egerClick = false;
    public Rigidbody2D baglantiNoktasi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (egerClick)
        {
             tas_rb2D.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void OnMouseDown() //Mouse ile tasa tiklandiginda
    {
        egerClick = true;
    }

    void OnMouseUp()
    {
        egerClick = false;
    }
}
