using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class Player : MonoBehaviour {

  
	public float deger = 0;

    public Image GucKutusu;
    public Image GucArkaplan;
    public Image ipucu;
    public Image Tripucu;

    public GameObject PlayerMaymun;
    public GameObject Woood;
    public GameObject OyunSonuArkaPlan;
    public GameObject konmaEfekt;
    public Text OyunSonuScore;

    public Text Score;

    public AudioClip ZiplamaSound;
    public AudioClip gameOverSound;

    private AudioSource ses_source;

    float yuzde;
    int sfxAcikMi;
    public float kutuMax = 200;
    public float kutuMin = 0;
    public float kutuHizi = 0.25f;
  
    public static int Skor = 0;
   public bool grounded = false;
   public static int yerdemi = 0;
   bool Doldumu = false;
   bool Bipucu = true;
    public GoogleMobileAdsDemoScript Reklam;

	// Use this for initialization
	void Start () {
        UpdateKutu();
        Tripucu.enabled = false;
       
       // PlayerMaymun.transform.rotation = Quaternion.identity;
        ses_source = GetComponent<AudioSource>();
        sfxAcikMi = PlayerPrefs.GetInt("SFXBit");

        Debug.Log("Dil kontrol : " + string.Compare(PlayerPrefs.GetString("Dil"), "TR"));
        if(string.Compare(PlayerPrefs.GetString("Dil"),"TR") == 0 ){
            ipucu.enabled = false;
            Tripucu.enabled = true;

        }

        Reklam.RequestInterstitial();
        Reklam.HideBanner();
	}
	
	// Update is called once per frame
	void Update () {
        
		StartCoroutine(mouseDown());

        KutuTakip();
        Score.text = Skor.ToString();

		if (Input.GetMouseButtonUp(0) && grounded == true ){
            if(sfxAcikMi == 1)
            ses_source.PlayOneShot(ZiplamaSound, 0.4f);

            if (Bipucu == true)
            {
                ipucu.enabled = false;
                Tripucu.enabled = false;
                Bipucu = false;
            }

          Vector2 j = new Vector2(Mathf.Cos(45)*deger*2, Mathf.Sin(45)*deger*3);
           GetComponent<Rigidbody2D>().AddForce(j);
           ZiplamaEfektiVer();
           

			if (deger >= 10) {
				grounded = false;
				kipirda.gezinme = 0;
			}
            Skor += (int)deger/ 5;
			deger = kutuMin;
            UpdateKutu();
            
		}
       

        if (PlayerMaymun.transform.position.y < -5.25f) {
            Reklam.ShowInterstitial();
            OyunSonuArkaPlan.SetActive(true);
            GucArkaplan.enabled = false;
            Score.enabled = false;
            OyunSonuScore.text = Skor.ToString();
            HighScoreMu();

            if (sfxAcikMi == 1)
            ses_source.PlayOneShot(gameOverSound, 0.4f);

         // PlayerMaymun.SetActive(false);
        }

        if (grounded == false)
        {
            yerdemi = 0;
        }
        else {
            yerdemi = 1;
        }


	}

	IEnumerator mouseDown()
	{
        /*
		while(Input.GetMouseButton(0) && grounded == true)
		{
            if (grounded == false) {
                deger = 0;
                break;
            }


            if (deger < kutuMax) {
                deger += 2;
                UpdateKutu();
            }

            if (deger == kutuMax) {
                while (deger > kutuMin) {
                    deger -= 2;
                    UpdateKutu();
                    yield return new WaitForSeconds(kutuHizi);
                }

            
            }

			yield return new WaitForSeconds(kutuHizi);
		}
         */

        while (Input.GetMouseButton(0) && Doldumu == false && grounded == true) {

            if (deger < kutuMax) {
                deger += 2;
                UpdateKutu();
                yield return new WaitForSeconds(kutuHizi);
            }
            else if (deger == kutuMax) {
                Doldumu = true;
            }
        }

        while (Input.GetMouseButton(0) && Doldumu == true && grounded == true) {
            if (deger > kutuMin) {
                deger -= 2;
                UpdateKutu();
                yield return new WaitForSeconds(kutuHizi);
            }
            else if (deger == kutuMin) {
                Doldumu = false;
            }
        
        }

        yield return new WaitForSeconds(kutuHizi);

	}

    void UpdateKutu() {
        yuzde = deger / kutuMax;
        GucKutusu.rectTransform.localScale = new Vector3(yuzde, 1, 1);
    }

    void KutuTakip() {
    GucArkaplan.transform.position = new Vector3(PlayerMaymun.transform.position.x, PlayerMaymun.transform.position.y + 1, PlayerMaymun.transform.position.z);
    }


    void ZiplamaEfektiVer() {
        Vector2 pos = new Vector2(PlayerMaymun.GetComponent<Rigidbody2D>().position.x, PlayerMaymun.GetComponent<Rigidbody2D>().position.y-0.5f);
        GameObject instantiated;
        instantiated = (GameObject)Instantiate(konmaEfekt, pos, Quaternion.identity);
        Destroy(instantiated, 0.2f);
    
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        
        if (col.gameObject.tag == "odun")
        {
            PlayerMaymun.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            PlayerMaymun.transform.rotation = new Quaternion(0, 0, 0, 0);
            grounded = true;
           
        }

        if (col.gameObject.tag == "Dest")
            grounded = false;

       
        
       

    }

    void HighScoreMu() {
        int LastHighScore = PlayerPrefs.GetInt("HighScore");

        if (Skor > LastHighScore) {
            PlayerPrefs.SetInt("HighScore", Skor);
        }
    
    }

  

}
