using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Astronot_hareket : MonoBehaviour
{
    //Public yapilan degiskenler Unity arayüzünde ilgili nesnede görüntülenir
    public float hiz = 1f;
    public int tas_sayisi;
    public int buyukTasSayisi;
    public bool indi_mi = false;
    public Animator benimAnimator;
    private float yatay;
    private float dikey;
    public Text toplananTasSayisi;
    public Text toplananBuyukTasSayisi;
    public GameObject oyunSonuPaneli;
    public Text oyunSonuTasSayisi;
    public int saglik = 100;
    public Text SaglikText;
    public static bool oyunumuzBasladiMi = false;
    public GameObject oyunBasiPaneli;
    public AudioSource tasToplamaSesi;
    public AudioSource ziplamaSesi;
    public AudioSource yaralanmaSesi;
    public AudioSource gameOverSesi;


    // Start is called before the first frame update
    void Start()
    {
        SaglikText.text = saglik.ToString();
        oyunumuzBasladiMi = false;
        gameOverSesi.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {

    }

    void FixedUpdate()
    {

        if (oyunumuzBasladiMi == false)
        {
            return;
        }


        yatay = Input.GetAxis("Horizontal"); // Horizontal(yataydaki) hareket girdisi algilar, (sol-sag yon tuslari veya A-D) 
        // Debug.Log(yatay);
        transform.position += new Vector3(yatay * hiz, 0, 0);//sadece x ekseninde karaktere yatay*hiz kadar hareket verir


        dikey = Input.GetAxis("Vertical"); // Vertical(dikeydeki) hareket girdisi algilar, (asagi-yukari yon tuslari veya W-S) 
        // Debug.Log(yatay);
        transform.position += new Vector3(0, dikey * hiz, 0);//sadece x ekseninde karaktere yatay*hiz kadar hareket verir

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
            toplananTasSayisi.text = tas_sayisi.ToString();
            toplananTasSayisi.text = "00" + toplananTasSayisi.text;
            Debug.Log("Tas toplandi"); //ekrana yaz
            Destroy(collision.gameObject); //toplanan nesneyi sil Destroy (collision.gameObject,0.05F); --> gecikmeli
            tasToplamaSesi.Play();
        }

        if (collision.tag == "BuyukTas")  //Tag'i Stone olan nesnelere temas ederse
        {
            buyukTasSayisi++;  //tas sayisini bir arttir
            toplananBuyukTasSayisi.text = buyukTasSayisi.ToString();
            toplananBuyukTasSayisi.text = "00" + toplananBuyukTasSayisi.text;
            Debug.Log("Tas toplandi"); //ekrana yaz
            Destroy(collision.gameObject); //toplanan nesneyi sil
            tasToplamaSesi.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //OnTriggerExit>>Temas kesildikten sonra tetikler. Astronot tasin sonuna dokundugunda burasi calisir
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
            //yaralanmaSesi.Play();
            Debug.Log("Ahhhhhhh!!!");//ekrana yazar
            saglik -= 20;
            SaglikText.text = saglik.ToString();
            if (saglik <= 0)
            {
                gameOverSesi.Play();
                Destroy(this.gameObject); //bagli oldugu nesneyi yokeder (burada Astro yokolur)
                oyunSonuPaneli.SetActive(true);
                oyunSonuTasSayisi.text = tas_sayisi.ToString();
            }
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


    public void OyunBasladi()
    {
        oyunumuzBasladiMi = true;
        oyunBasiPaneli.SetActive(false);
        oyunSonuTasSayisi.text = tas_sayisi.ToString();
    }
}

