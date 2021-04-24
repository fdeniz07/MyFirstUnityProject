using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yerde_miyiz : MonoBehaviour
{
    //LayerMask t�r�ndeki unity katmanimizi burada tanimliyoruz, unity tarafinda da ilgili objeyi bu degiskene sabitliyoruz.

    public LayerMask layer; //unity ortaminda aitlik katmanini secebilmek icin tanimladik
    public bool yerdemiy�z; //kontrol degiskeni
    public Rigidbody2D rb; //astronun rigidbodysini baglamak icin tanimladik

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //transform.position : isinin baslangic konumu
    //Vector2.down : isinin gidecegi yonu belirliyor, asagidaki nesnelere degip degmedigini tespit icin down yapiyoruz (ziplama durumunda)
    //0.1f : isinin b�y�kl�g� , yani astronotun yer katmanin neredeyse temas ettigi noktadan ziplamasini saglar
    //layer: Yer katmanini baglayacagiz. hangi katmanlarda ziplama olayi gerceklestirilecek (�rnegin astronot kayada ziplayabilir, kum ve bataklikta ziplayamaz)

    void Update()
    {
        RaycastHit2D carpis = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, layer);
        if (carpis.collider!=null) //isinin yere carpip carpmamasi
        {
            //isin yere carptiysa --> yerdeyiz
            yerdemiy�z = true;
        }
        else
        {
            //isin bir yere carpmiyorsa --> havadayiz
            yerdemiy�z = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && yerdemiy�z==true)  //space'e bastiysak ve astro yerde ise
        {
            rb.velocity += new Vector2(0,15f); //y ekseninde hizlanma yani ziplama hizi degeri
        }
    }
}
