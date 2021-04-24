using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronot_hareket : MonoBehaviour
{
    public float hiz=1f;
    public int tas_sayisi;
    public bool indi_mi = false;
    public Animator benimAnimator;
    private float yatay;
    private float dikey;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        yatay = Input.GetAxis("Horizontal"); // Horizontal(yataydaki) hareket girdisi algilar, (sol-sag yon tuslari veya A-D) 
        // Debug.Log(yatay);
        transform.position += new Vector3(yatay * hiz, 0, 0);//sadece x ekseninde karaktere yatay*hiz kadar hareket verir


        //alttaki if yapisinda karakterin Transform komponentinde Scale'e erisip yonunu degistiriyoruz
        //scale'de yatay icin x'i, dikey icin y'yi eksi ile carpiyoruz

        YonDegistir(); //yon degistirme fonksiyonunu cagiriyoruz
        
        bool yuruyormuyuz = false; //yuruyup yurumedigini kontrol etmek icin atanan degisken

        if (yatay != 0) //sag veya sola tiklanmissa
        {
            yuruyormuyuz = true;
        }

        if (yatay == 0) //yatayda hareket etmiyorsa
        {
            yuruyormuyuz = false; 
        }

        benimAnimator.SetBool("yuruyormu", yuruyormuyuz); //animator ile kod baglantisini yapiyor
    }


    private void OnTriggerEnter2D(Collider2D collision) // carpisma olaylari,OnTriggerEnter>>Temas ettigi anda tetikler - Astronot tasa dokunur dokunmaz burasi calisir  -- (collider, collider eklendiginde)
    {
        if (collision.tag == "Stone")  //Tag'i Stone olan nesnelere temas ederse
        {
            tas_sayisi++;  //tas sayisini bir arttir
            Debug.Log("Tas toplandi"); //ekrana yaz
            Destroy(collision.gameObject); //toplanan nesneyi sil
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // //OnTriggerExit>>Temas kesildikten sonra tetikler. Astronot tasin sonuna dokundugunda burasi calisir
    {

    }

    private void OnCollisionEnter2D(Collision2D collision) // carpisma olaylari,OnTriggerEnter>>Temas ettigi anda tetikler. Astronot tasin sonuna dokundugunda burasi calisir --Collision (trigger degerleri girdiginde)
    {
        if (collision.gameObject.tag == "platform") //platform tag'ine sahip nesne ile temas ederse
        {
            if (indi_mi == false) //Astro'nun platforma inip inmedigini kontrol eder,
            {
                Debug.Log("Astronot gezegene indi!"); //indiginde ekrana bir kere yazar
            }
            indi_mi = true; //tekrar tekrar yazdirmamak icin kontrolu true yapar
        }

        if (collision.gameObject.tag == "engel")  //engel tag'ine sahip nesne ile temas edrse
        {
            Debug.Log("Ahhhhhhh!!!");//ekrana yazar
            Destroy(this.gameObject); //bagli oldugu nesneyi yokeder (burada Astro yokolur)
        }

    }

    void YonDegistir()
    {
        if (yatay > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);  //karakter saga giderse yonu saga bakar
        }
        else if (yatay < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); //sola gidiyorsa sola doner
        }
        if (dikey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (dikey < 0)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
    }
}

